using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Packaging;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CardFlip.Database
{
    public static class Tcp
    {
        public static event EventHandler StartGame;
        public static event EventHandler StopGame;
        private static string systemIpAddress;
        private static string hostName;
        private static Socket clientSocket;
        private static byte[] sizeBuffer;
        public static string SystemIpAddress
        {
            set
            {
                systemIpAddress = value;
            }
            get
            {
                return systemIpAddress;
            }
        }
        public static string HostName
        {
            set
            {
                hostName = value;
            }
            get
            {
                return hostName;
            }
        }
       
        public static void initialize()
        {
            HostName=Environment.MachineName;
            SystemIpAddress = GetMachineIPAddress(HostName);
        }

        [DefaultValue(false)]
        public static bool IsConnected { get; set; }

        private static string GetMachineIPAddress(string hostName)
        {
            foreach (var ip in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "192.0.0.1";
        }
        public static void TcpConnect(string parentIP)
        {
            sizeBuffer = new byte[5];

            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.BeginConnect(new IPEndPoint(IPAddress.Parse(parentIP), 22334), new AsyncCallback(ConnectCallBack), parentIP);

        }

        private static void ConnectCallBack(IAsyncResult ar)
        {
            string parentIP = (string)ar.AsyncState;
            try
            {
                clientSocket.EndConnect(ar);
                clientSocket.BeginSend(new byte[] { 1, 1, 1, 1, 1 }, 0, 5, SocketFlags.None, new AsyncCallback(SendCallBack), null);
                clientSocket.BeginReceive(sizeBuffer, 0, 5, SocketFlags.None, new AsyncCallback(ClientReceiveSizeCallBack), clientSocket);
                IsConnected = true;
            }
            catch
            {
                IsConnected = false;
                if (clientSocket != null)
                    clientSocket.BeginConnect(new IPEndPoint(IPAddress.Parse(parentIP), 22334), new AsyncCallback(ConnectCallBack), parentIP);
            }
        }

        private static void SendCallBack(IAsyncResult ar)
        {
            try
            {
                clientSocket.EndSend(ar);
            }
            catch
            {
            }
        }

        private static void ClientReceiveSizeCallBack(IAsyncResult ar)
        {
            try
            {
                clientSocket.EndReceive(ar);
                if (sizeBuffer[0] == 1)
                {
                    StartGame?.Invoke(null, EventArgs.Empty);
                }
                else if (sizeBuffer[0] == 0)
                {
                    StopGame?.Invoke(null, EventArgs.Empty);
                }
                clientSocket.BeginReceive(sizeBuffer, 0, 5, SocketFlags.None, new AsyncCallback(ClientReceiveSizeCallBack), clientSocket);
            }
            catch
            {
            }

        }

        public static void Close()
        {
            SendCloser();
            if (clientSocket!=null&&clientSocket.Connected)
                clientSocket.Shutdown(SocketShutdown.Receive);
            clientSocket?.Dispose();
            clientSocket = null;
        }

        private static void SendCloser()
        {
            try
            {
                clientSocket?.BeginSend(new byte[] { 0, 0, 0, 0, 0 }, 0, 5, SocketFlags.None, new AsyncCallback(SendCallBack), null);
            }
            catch
            {
            }
        }
    }
}
