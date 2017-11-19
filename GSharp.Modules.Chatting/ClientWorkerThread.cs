using System;
using System.Net.Sockets;
using System.Text;

namespace GSharp.Modules.Chatting
{
    // Define a class to hold custom event info
    public class CustomEventArgs : EventArgs
    {
        public CustomEventArgs(string s)
        {
            message = s;
        }
        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; }
        }
    }

    class ClientWorkerThread
    {
        public Socket socket;

        private volatile bool shouldStop = false;
        public event EventHandler<CustomEventArgs> RaiseCustomEvent;

        public ClientWorkerThread(Socket socket)
        {
            this.socket = socket;
        }

        public void DoWork()
        {
            // Client 로 부터 data 를 수신한다.
            try
            {
                while (!shouldStop)
                {
                    string data = "";
                    while (true)
                    {
                        byte[] bytes = new byte[1024];
                        int size = socket.Receive(bytes);
                        data += Encoding.UTF8.GetString(bytes, 0, size);
                        if (data.IndexOf("<EOF>") > -1)
                        {
                            // 수신이 완료되었음을 Server 에 알림
                            OnRaiseCustomEvent(new CustomEventArgs(data));
                            Console.WriteLine("In DoWork,,,/// " + data);
                            break;
                        }
                    }
                }
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Stop()
        {
            shouldStop = true;
        }

        // Wrap event invocations inside a protected virtual method
        // to allow derived classes to override the event invocation behavior
        protected virtual void OnRaiseCustomEvent(CustomEventArgs e)
        {
            // Make a temporary copy of the event to avoid possibility of
            // a race condition if the last subscriber unsubscribes
            // immediately after the null check and before the event is raised.
            EventHandler<CustomEventArgs> handler = RaiseCustomEvent;

            // Event will be null if there are no subscribers
            if (handler != null)
            {
                // Format the string to send inside the CustomEventArgs parameter
               //  e.Message += String.Format(" at {0}", DateTime.Now.ToString());

                // Use the () operator to raise the event.
                handler(this, e);
            }
        }
    
    }
}
