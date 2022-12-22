using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Timers;

namespace Server
{
    public  class Server_Class
    {        
        Socket tcpListener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        List<Socket> sockets = new List<Socket>();
        System.Timers.Timer timer = new System.Timers.Timer(1);
        public int turn = 0;
        

        public  void Start_Server()
        {
            tcpListener.Bind(new IPEndPoint(IPAddress.Any, 80));
            tcpListener.Listen();    // запускаем сервер
            sockets.Add((  tcpListener.Accept()));
            sockets.Add((  tcpListener.Accept()));


            
                     
            while(true)
            {
                Receive();
            }
        }


        public void Receive(/*Object source, ElapsedEventArgs e*/)
        {           
            
            // буфер для накопления входящих данных
            var response = new List<byte>();
                // буфер для считывания одного байта
                var bytesRead = new byte[1];
                //считываем данные до конечного

                while (true)
                {
                    var count = sockets[turn].Receive(bytesRead);
                    // смотрим, если считанный байт представляет конечный символ, выходим
                    if (count == 0 || bytesRead[0] == '\n') break;
                    // иначе добавляем в буфер
                    response.Add(bytesRead[0]);
                }

                switch(turn)
            {
                case 0: { turn = 1; break; }
                case 1: { turn = 0; break; }
            }

            var cord = Encoding.UTF8.GetString(response.ToArray());

            if ( cord.Contains('W'))
            {
                sockets[turn].Send(Encoding.UTF8.GetBytes($"{turn} WIN \n"));
            }
            else
            {
                sockets[turn].Send(Encoding.UTF8.GetBytes($"{turn} {cord} \n"));
            }
        }
    }
}
