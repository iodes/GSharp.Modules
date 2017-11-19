using GSharp.Extension.Abstracts;
using GSharp.Extension.Attributes;
using System.Net;

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
    }
}
