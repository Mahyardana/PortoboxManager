using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace PortoboxManager
{
    public static class PortoboxManager
    {
        static HttpClient client;
        static HttpClientHandler clienthandler;
        static string adminURL = "";
        public static List<ServerStatus> Servers = new List<ServerStatus>();
        public static bool Validated { get; set; } = false;
        public static bool Validate(string username, string password, string ipaddress)
        {
            try
            {
                clienthandler = new HttpClientHandler();
                client = new HttpClient(clienthandler);
                var stringcontent = new StringContent($"luci_username={username}&luci_password={password}", Encoding.UTF8, "application/x-www-form-urlencoded");
                var response = client.PostAsync("http://" + ipaddress + "/cgi-bin/admin/", stringcontent).Result;
                var content = response.Content.ReadAsStringAsync().Result;
                if (content.Contains("<title>PortoBoxIntl - Admin"))
                {
                    adminURL = response.RequestMessage.RequestUri.AbsoluteUri;
                    Validated = true;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {

            }
            return false;
        }
        public static string[] GetRealtimeSpeed()
        {
            var status = client.GetStringAsync(adminURL + "/admin/status/get_realtime_speed").Result;
            var sp = status.Split(new string[] { "[\"", "\",\"", "\"]" }, StringSplitOptions.RemoveEmptyEntries);
            return sp;
        }
        public static string GetCurrentServer()
        {
            var status = client.GetStringAsync(adminURL + "/admin/services/porto/get_current_server").Result;
            var ret = (string)JObject.Parse(status)["ret"];
            return ret;
        }
        public static bool GetConnectionStatus(bool foreign)
        {
            var set = "";
            if (foreign)
                set = "www.facebook.com";
            else
                set = "109.110.160.170";
            var status = client.GetStringAsync(adminURL + "/admin/services/porto/check?set=" + set).Result;
            var ret = (string)JObject.Parse(status)["ret"];
            if (ret == "0")
                return true;
            else
                return false;
        }
        public static void UpdateServersList()
        {
            var status = client.GetStringAsync(adminURL + "/admin/services/porto/client/").Result;
            var matches = Regex.Matches(status, "value=\"([\\w\\d]+)\">\\[[\\w]+\\] ([\\w \\d]+)");
            var serverslist = new List<ServerStatus>();
            serverslist.Add(new ServerStatus());
            foreach (Match match in matches)
            {
                var first = match.Groups[1].Value;
                var second = match.Groups[2].Value;
                serverslist.Add(new ServerStatus() { Name = second, Code = first });
            }
            Servers = serverslist;
        }
        public static ServerStatus[] GetServersStatus()
        {
            var status = client.GetStringAsync(adminURL + "/admin/services/porto/checkport").Result;
            var ret = (string)JObject.Parse(status)["ret"];
            var matches = Regex.Matches(ret, "\\[([\\w \\d]+)\\] ([\\w]+)");
            var serverslist = new List<ServerStatus>();
            foreach (Match match in matches)
            {
                var first = match.Groups[1].Value;
                var second = match.Groups[2].Value;
                serverslist.Add(new ServerStatus() { Name = first, Status = second });
            }
            return serverslist.ToArray();
        }
        public static void ApplyConfig(int id)
        {
            var servercode = "nil";
            servercode = Servers[id].Code;
            var str = "-----------------------------25127443735106440553406024358\r\n" +
                "Content-Disposition: form-data; name=\"cbi.submit\"\r\n" +
                "\r\n" +
                "1\r\n" +
                "-----------------------------25127443735106440553406024358\r\n" +
                "Content-Disposition: form-data; name=\"cbid.porto.cfg3213pb.info_active_server_load\"\r\n" +
                "\r\n" +
                "GOOD\r\n" +
                "-----------------------------25127443735106440553406024358\r\n" +
                "Content-Disposition: form-data; name=\"cbid.porto.cfg3213pb.info_socks5_address\"\r\n" +
                "\r\n" +
                "10.0.1.1\r\n" +
                "-----------------------------25127443735106440553406024358\r\n" +
                "Content-Disposition: form-data; name=\"cbid.porto.cfg3213pb.info_socks5_port\"\r\n" +
                "\r\n8888\r\n-----------------------------25127443735106440553406024358\r\n" +
                "Content-Disposition: form-data; name=\"cbid.porto.cfg023fd6.global_server\"\r\n" +
                "\r\n" +
                servercode + "\r\n" +
                "-----------------------------25127443735106440553406024358\r\n" +
                "Content-Disposition: form-data; name=\"cbi.cbe.porto.cfg023fd6.enable_switch\"\r\n" +
                "\r\n" +
                "1\r\n" +
                "-----------------------------25127443735106440553406024358\r\n" +
                "Content-Disposition: form-data; name=\"cbid.porto.cfg023fd6.enable_switch\"\r\n" +
                "\r\n" +
                "1\r\n" +
                "-----------------------------25127443735106440553406024358\r\n" +
                "Content-Disposition: form-data; name=\"cbi.cbe.porto.cfg023fd6.ping_switch\"\r\n" +
                "\r\n" +
                "1\r\n" +
                "-----------------------------25127443735106440553406024358\r\n" +
                "Content-Disposition: form-data; name=\"cbid.porto.cfg023fd6.ping_switch\"\r\n" +
                "\r\n" +
                "1\r\n" +
                "-----------------------------25127443735106440553406024358\r\n" +
                "Content-Disposition: form-data; name=\"cbid.porto.cfg064417.wan_bp_list\"\r\n" +
                "\r\n" +
                "/dev/null\r\n" +
                "-----------------------------25127443735106440553406024358\r\n" +
                "Content-Disposition: form-data; name=\"cbi.apply\"\r\n" +
                "\r\n" +
                "Apply\r\n" +
                "-----------------------------25127443735106440553406024358--\r\n";
            var content = new StringContent(str);
            content.Headers.Remove("Content-Type");
            content.Headers.TryAddWithoutValidation("Content-Type","multipart/form-data; boundary=---------------------------25127443735106440553406024358");
            var response = client.PostAsync(adminURL + "/admin/services/porto/client", content).Result;
            if (response.IsSuccessStatusCode)
            {
                var strcontent = client.GetStringAsync(adminURL + "/servicectl/restart/porto").Result;
                while (strcontent != "finish")
                {
                    strcontent = client.GetStringAsync(adminURL + "/servicectl/status").Result;
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
