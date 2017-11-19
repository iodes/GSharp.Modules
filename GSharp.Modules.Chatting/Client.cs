using GSharp.Extension.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using GSharp.Extension.Attributes;
using System.Net;

namespace GSharp.Modules.Chatting
{
    public class Client : GModule
    {
        private static Socket sender;
        //private static byte[] buffer = new byte[1024];

        [GCommand("ip: {0}, port: {1} 로 연결")]
        public static void Connect(string ip, int port)
        {
            sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); 
            IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse(ip), port);
            sender.Connect(remoteEP);
        }

        [GCommand("메세지 받기")]
        public static string Received_msg
        {
            get
            {
                return Receive();
            }
        }

        private static string Receive()
        {
            string data = "";
            while (true)
            {
                byte[] bytes = new byte[1024];
                int size = sender.Receive(bytes);
                data += Encoding.UTF8.GetString(bytes, 0, size);
                if (data.IndexOf("<EOF>") > -1)
                {
                    break;
                }
            }

            return data.Substring(0, data.IndexOf("<EOF>"));
        }
        
        [GCommand("메세지: {0} 보내기")]
        public static void Send(string msg)
        {
            byte[] msg_byte = Encoding.UTF8.GetBytes(msg + "<EOF>");
            sender.Send(msg_byte);
        }
    }
}
