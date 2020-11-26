using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace PortoboxManager
{
    static class Program
    {
        public static Version version = new Version(1, 0, 0);
        public static Config config = new Config();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Config));
            if (File.Exists("Config.xml"))
                using (var reader = File.OpenRead("Config.xml"))
                    config = xmlSerializer.Deserialize(reader) as Config;
            else
            {
                config.Username = "root";
                config.Password = "portobox";
                config.IPAddress = "10.0.1.1";
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new UserPass());
            if (PortoboxManager.Validated)
            {
                Application.Run(new Manager());
            }
        }
    }
}
