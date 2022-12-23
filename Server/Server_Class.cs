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
        public int turn = 0;
        public int miss = 0;   
        

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


        public void Receive()
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
            var cord = Encoding.UTF8.GetString(response.ToArray());

            if (CheckPause(cord))
            {
                return;
            }

            switch(cord.Split(' ')[0])
            {
                case "PN1":
                    {
                        sockets[1].Send(Encoding.UTF8.GetBytes($"{cord.Split(' ')[1]} \n"));
                            break;
                    }
                case "PN2":
                    {
                        sockets[0].Send(Encoding.UTF8.GetBytes($"{cord.Split(' ')[1]} \n"));
                        break;
                    }
                    
            }


            if(cord.Contains('M') || miss == 1)
            {
                if(miss == 0)
                {
                    switch (turn)
                    {
                        case 0: { turn = 1; break; }
                        case 1: { turn = 0; break; }
                    }
                    Send_Miss(cord);
                    miss = 1;
                }
                else
                {
                    Send_Miss(cord);
                    miss = 0;                                        
                }                
            }
            else
            {
                switch (turn)
                {
                    case 0: { turn = 1; break; }
                    case 1: { turn = 0; break; }
                }
                Send(cord);
            }  
        }

        public void Send_Miss(string cord)
        {
            if (cord.Contains('W'))
            {
                sockets[turn].Send(Encoding.UTF8.GetBytes($"{turn} WIN \n"));
            }

            if(miss == 0)
            {
                sockets[turn].Send(Encoding.UTF8.GetBytes($"{turn} {cord.Split(' ')[1]} {cord.Split(' ')[2]} \n"));
            }
            else 
            {
                sockets[turn].Send(Encoding.UTF8.GetBytes($"{turn} {cord.Split(' ')[0]} {cord.Split(' ')[1]} \n"));
            }
        }
        public void Send(string cord)
        {
            if (cord.Contains('W'))
            {
                sockets[turn].Send(Encoding.UTF8.GetBytes($"{turn} WIN \n"));
            }
            sockets[turn].Send(Encoding.UTF8.GetBytes($"{turn} {cord.Split(' ')[0]} {cord.Split(' ')[1]} \n"));
        }

        public bool CheckPause(string message)
        {
            switch(message.Split(' ')[0])
            {
                case "P1":
                    {
                        sockets[1].Send(Encoding.UTF8.GetBytes($"P1 {message.Split(' ')[1]} \n"));
                        return true;
                    }
                case "P2":
                    {
                        sockets[0].Send(Encoding.UTF8.GetBytes($"P2 {message.Split(' ')[1]} \n"));
                        return true;
                    }
                default:
                    return false;
            }
        }
    }
}
