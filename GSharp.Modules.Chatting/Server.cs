using GSharp.Extension.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using GSharp.Extension.Attributes;
using System.Collections;
using System.Threading;

namespace GSharp.Modules.Chatting
{

    public class Server : GModule
    {
        private static int port = 9750;
        private static ArrayList clientList = new ArrayList();
        private static Socket ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        [GCommand("내 IP 주소 가져오기")]
        public static string MyIpAddress
        {
            get
            {
                return GetLocalIPAddress();
            }
        }

        /// <summary>
        /// 서버를 열고 클라이언트에 연결을 기다린다. 
        /// 연결된 클라이언트 1개당 ClientWorkerThread 를 생성하고 ArrayList 에 보관한다.
        /// </summary>
        [GCommand("서버 오픈")]
        public static void ServerOpen()
        {
            ServerSocket.Bind(new IPEndPoint(IPAddress.Any, port));
            ServerSocket.Listen(20);

            while (true)
            {
                Console.WriteLine("Waiting Client...");
                Socket clientSocket = ServerSocket.Accept();
                Console.WriteLine("Client Connected!!! " + clientSocket.LocalEndPoint.ToString());

                // Data 를 받는 Thread 를 시작
                ClientWorkerThread clientWorkerThread = new ClientWorkerThread(clientSocket);
                Thread workerThread = new Thread(new ThreadStart(clientWorkerThread.DoWork));
                workerThread.Start();

                // ArrayList 에 Thread 를 추가
                clientList.Add(clientWorkerThread);

                // Message 를 받았을 때 발생하는 이벤트를 추가
                clientWorkerThread.RaiseCustomEvent += DataLinstener;
            }
        }

        [GCommand("서버 닫기")]
        public static void ServerClose()
        {
            ServerSocket.Close();
            clientList.Clear();
        }

        /// <summary>
        /// Client Thread 로 부터 메세지를 받았을 때 이벤트가 호출된다.
        /// 접속 되어 있는 Client 에게 BroadCast
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void DataLinstener(object sender, CustomEventArgs e)
        {
            string msg = e.Message;
            // Test Print 
            Console.WriteLine("In DataLinstener// " + msg);
            

           foreach(ClientWorkerThread client in clientList){
                if (sender != client)
                {
                    byte[] msg_byte = Encoding.UTF8.GetBytes(msg);
                    client.socket.Send(msg_byte);
                }
            }
        }

        /// <summary>
        /// 자신의 ip 주소를 반환
        /// </summary>
        /// <returns></returns>
        private static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
    }
}
