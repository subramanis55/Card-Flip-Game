using ScoreBoard.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialLibrary;

namespace ScoreBoard
{
    public partial class Form1 : MaterialForm
    {
        private Timer timer;
        private DataTable dataTable;
        TCP tcp;
        public Form1()
        {
            InitializeComponent();
            DBManager.Intialize(DBManager.ApplicationSetting);
            tcp = new TCP();
            timer = new Timer
            {
                Interval = 1000
            };
            timer.Tick += Timer_Tick;
            tcp.OnClientListChanged += Tcp_OnClientListChanged;
            InitializeTable();
            dataGridView1.DataSource = dataTable;
            timer.Start();
        }

        private void InitializeTable()
        {
            dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("IP"));
            dataTable.Columns.Add(new DataColumn("HostName"));
            dataTable.Columns.Add(new DataColumn("Name"));
            dataTable.Columns.Add(new DataColumn("Duration"));
            dataTable.Columns.Add(new DataColumn("Played"));
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void UpdateTable()
        {
            dataTable.Rows.Clear();
            var list = DBManager.GetAllData();
            dataTable.Rows.Clear();
            foreach(var item in list)
            {
                dataTable.Rows.Add(new object[]
                {
                    item.ip,
                    item.hostName,
                    item.name,
                    item.duration,
                    item.isPlayed
                });
            }
        }

        private void Tcp_OnClientListChanged(object sender, EventArgs e)
        {
            DataTable ipTable = new DataTable();
            ipTable.Columns.Add("IP");
            foreach (string client in tcp.GetListOfIp())
            {
                ipTable.Rows.Add(new object[]
                {
                    client
                });
            }
            Invoke(new Action(() =>
            {
                if (dataGridView2.DataSource != null)
                {
                    (dataGridView2.DataSource as DataTable).Dispose();
                    dataGridView2.DataSource = null;
                }
                dataGridView2.DataSource = ipTable;
            }));
        }

      

        private void materialIconButton1_Click(object sender, EventArgs e)
        {
            if (materialIconButton1.IconDisplayType == MaterialLibrary.IconType.Close)
                materialIconButton1.IconDisplayType = MaterialLibrary.IconType.Done;
            else
                materialIconButton1.IconDisplayType = MaterialLibrary.IconType.Close;
            SendMessage(materialIconButton1.IconDisplayType == MaterialLibrary.IconType.Done);
        }

        private void SendMessage(bool v)
        {
            tcp.IsStart(v);
        }

        protected override void OnClosed(EventArgs e)
        {
            timer.Stop();
            base.OnClosed(e);
        }

        private void ResetBtnClicked(object sender, EventArgs e)
        {
            DBManager.ResetPlay();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
