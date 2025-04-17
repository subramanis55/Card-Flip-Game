using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;

namespace ScoreBoard.Model
{
    public class TCP
    {
        public event EventHandler OnClientListChanged;
        private Socket serverSocket;

        private List<Socket> clients;

        private byte[] sizeBuffer;
        private static string hostName;
        private static string systemIpAddress;

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
            HostName = Environment.MachineName;
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
        public TCP()
        {
            clients = new List<Socket>();
            sizeBuffer = new byte[5];
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            string myIpAddress = GetMachineIPAddress();
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse(myIpAddress), 22334);
            serverSocket.Bind(endpoint);
            serverSocket.Listen(10);
            serverSocket.BeginAccept(new AsyncCallback(AcceptCallBack), null);
            OnClientListChanged?.Invoke(null, EventArgs.Empty);
        }

        private void AcceptCallBack(IAsyncResult ar)
        {
            try
            {
                Socket clientSocket = serverSocket.EndAccept(ar);
                clientSocket.BeginReceive(sizeBuffer, 0, 5, SocketFlags.None, new AsyncCallback(ClientReceiveSizeCallBack), clientSocket);
            }
            finally
            {
                serverSocket.BeginAccept(new AsyncCallback(AcceptCallBack), null);
            }
        }

        private void ClientReceiveSizeCallBack(IAsyncResult ar)
        {
            Socket clientSocket = ar.AsyncState as Socket;
            try
            {
                clientSocket.EndReceive(ar);
                byte[] sizeBufferCpy = new byte[5];
                Array.Copy(sizeBuffer, sizeBufferCpy, 5);
                IPEndPoint endPoint = clientSocket.RemoteEndPoint as IPEndPoint;
                lock (clients)
                {
                    if (sizeBuffer[0] == 1)
                    {
                        clients.Add(clientSocket);
                    }
                    else if (sizeBuffer[0] == 0)
                    {
                        clients.Remove(clientSocket);
                    }
                    OnClientListChanged?.Invoke(null, EventArgs.Empty);
                }
                clientSocket.BeginReceive(sizeBuffer, 0, 1, SocketFlags.None, new AsyncCallback(ClientReceiveSizeCallBack), clientSocket);
            }
            catch { }
            finally
            {

            }
        }

        private string GetMachineIPAddress()
        {
            foreach (var ip in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        public void IsStart(bool isOn)
        {
            if(isOn)
            {
                SendToClients((byte)1);
            }
            else
            {
                SendToClients((byte)0);
            }
        }

        private void SendToClients(byte v)
        {
            foreach(Socket client in clients)
            {
                try
                {
                    byte[] temp = new byte[]
                    {
                        v,
                        v,
                        v,
                        v,
                        v
                    };
                    client.BeginSend(temp,0,5,SocketFlags.None,new AsyncCallback(SendCallBack),client);
                }
                finally
                {

                }
            }
        }

        private void SendCallBack(IAsyncResult ar)
        {
            Socket clientSocket = (Socket)ar.AsyncState;
            clientSocket.EndSend(ar);
        }

        public List<string> GetListOfIp()
        {
            List<string> list = new List<string>();

            foreach(Socket client in clients)
            {
                list.Add((client.RemoteEndPoint as IPEndPoint).Address.ToString());
            }

            return list;
        }
    }
}
