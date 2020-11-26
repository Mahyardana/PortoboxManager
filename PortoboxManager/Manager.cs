using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PortoboxManager
{
    public partial class Manager : Form
    {
        delegate void updateuldl(string ul, string dl);
        public Manager()
        {
            InitializeComponent();
        }

        public void UpdateULDL(string ul, string dl)
        {
            if (InvokeRequired)
            {
                this.Invoke(new updateuldl(UpdateULDL), new object[] { ul, dl });
            }
            else
            {
                ulLabel.Text = ul;
                dlLabel.Text = dl;
            }
        }

        public void statusthread()
        {
            while (true)
            {
                try
                {
                    var speed = PortoboxManager.GetRealtimeSpeed();
                    UpdateULDL(speed[0], speed[1]);
                }
                catch
                {

                }
                Thread.Sleep(1000);
            }
        }


        private void Manager_Load(object sender, EventArgs e)
        {
            this.Text += Program.version.ToString();
            currentserverLabel.Text = PortoboxManager.GetCurrentServer();
            new Thread(statusthread).Start();
            PortoboxManager.UpdateServersList();
            UpdateComboBox();
        }

        private void Manager_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }

        private void UpdateComboBox()
        {
            serversComboBox.Items.Clear();
            for (int i = 0; i < PortoboxManager.Servers.Count; i++)
            {
                var item = PortoboxManager.Servers[i];
                if (item.Status == "NaN")
                    serversComboBox.Items.Add(item.Name);
                else
                    serversComboBox.Items.Add(item.Name + " [" + item.Status + "]");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var checkedservers = PortoboxManager.GetServersStatus();
            foreach (var server in checkedservers)
            {
                var found = PortoboxManager.Servers.Find(x => server.Name == x.Name);
                if (found != null)
                {
                    found.Status = server.Status;
                }
            }
            UpdateComboBox();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PortoboxManager.ApplyConfig(serversComboBox.SelectedIndex);
            currentserverLabel.Text = PortoboxManager.GetCurrentServer();
            foreignLabel.Text = "";
            localLabel.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var status = PortoboxManager.GetConnectionStatus(true);
            if (status)
                foreignLabel.Text = "Success";
            else
                foreignLabel.Text = "Error";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var status = PortoboxManager.GetConnectionStatus(false);
            if (status)
                localLabel.Text = "Success";
            else
                localLabel.Text = "Error";
        }
    }
}
