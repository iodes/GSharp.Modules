using GSharp.Extension.Abstracts;
using GSharp.Extension.Attributes;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;

namespace GSharp.Modules.System
{
    public class Network : GModule
    {
        [GCommand("IP 주소")]
        public static string ShowIP()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());

            return host.AddressList.FirstOrDefault().ToString();
        }

        [GCommand("네트워크 연결 여부")]
        public static bool isConnected()
        {
            return NetworkInterface.GetIsNetworkAvailable();
        }
    }
}
