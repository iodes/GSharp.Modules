using GSharp.Extension.Abstracts;
using GSharp.Extension.Attributes;
using System.Net;

namespace Gsharp.Moudles.Ipv4
{
    public class IPv4 : GModule
    {
        [GCommand("IPv4 주소")]
        public static string ShowIPv4()
        {
            IPHostEntry host = Dns.GetHostByName(Dns.GetHostName());
            string ipv4 = host.AddressList[0].ToString();

            return ipv4;
        }
    }
}
