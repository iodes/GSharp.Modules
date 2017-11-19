using GSharp.Extension.Abstracts;
using GSharp.Extension.Attributes;
using System.Net;
using System.Net.NetworkInformation;

namespace GSharp.Modules.System
{
    public class Network : GModule
    {
        [GCommand("IPv4 주소")]
        public static string ShowIPv4()
        {
            var host = Dns.GetHostByName(Dns.GetHostName());
            var ipv4 = host.AddressList[0].ToString();

            return ipv4;
        }

        [GCommand("네트워크 연결 여부")]
        public static bool isConnected()
        {
            return NetworkInterface.GetIsNetworkAvailable();
        }
    }
}
