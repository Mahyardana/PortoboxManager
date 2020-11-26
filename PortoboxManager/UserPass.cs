using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace PortoboxManager
{
    public partial class UserPass : Form
    {
        public UserPass()
        {
            InitializeComponent();
        }

        private void UserPass_Load(object sender, EventArgs e)
        {
            usernameTextBox.Text = Program.config.Username;
            passwordTextBox.Text = Program.config.Password;
            ipaddressTextBox.Text = Program.config.IPAddress;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            Program.config.Username = usernameTextBox.Text;
            Program.config.Password = passwordTextBox.Text;
            Program.config.IPAddress = ipaddressTextBox.Text;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Config));
            using (var writer = File.OpenWrite("config.xml"))
                xmlSerializer.Serialize(writer, Program.config);
            var status = PortoboxManager.Validate(Program.config.Username, Program.config.Password, Program.config.IPAddress);
            if (status)
                this.Close();
        }
    }
}
