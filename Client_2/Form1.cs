using Microsoft.VisualBasic.ApplicationServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;
using System.Net.Sockets;
using System.Text;
using System.Timers;
using Server;
using System;
using System.Xml.Linq;

//второй игрок
namespace PummelParty
{
    public partial class Form1 : Form
    {
        Label l = new Label();
        ListBox lb = new ListBox();

        Player player1;
        Player player2;

        int position = 0;
        bool a = false;
        bool pause_button = false;

        Socket tcpClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        System.Timers.Timer timer = new System.Timers.Timer(100);

        public Form1()
        {
            InitializeComponent();
            //this.MouseClick += new MouseEventHandler(Form1_MouseClick);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rollButon.Visible = false;
            labelWin.Visible = false;
            labelCountSteps.Visible = false;
            dicePictureBox.Visible = false;            
        }

        public int[] coordinatesX = coordinatesXInit();
        public int[] coordinatesY = coordinatesYInit();

        private async void buttonStart_Click(object sender, EventArgs e)
        {
            buttonStart.Visible = false;
            buttonStart.Enabled = false;

            rollButon.Visible = true;
            rollButon.Enabled = false;

            Pause.Enabled = true;
            Pause.Visible = true;

            textBox1.Visible = false;
            label1.Visible = false;
            //dicePictureBox.Visible = false;

            lb.Visible = false;
            lb.Location = new Point(519, 376);
            lb.Size = new Size(200, 200);
            Controls.Add(lb);

            l.Visible = false;
            l.Location = new Point(519, 376);
            l.Size = new Size(200, 200);
            Controls.Add(l);


            //установка фона
            this.BackgroundImage = Image.FromFile(Path.Join(Directory.GetCurrentDirectory(), @"\images\background.jpg"));
            this.BackgroundImageLayout = ImageLayout.None;
            await tcpClient.ConnectAsync("127.0.0.2", 80);

            //появление игроков на старте
            Random random = new Random();
            int positionSdvig = random.Next(10, 20);
            string name = textBox1.Text;
            if(name == "")
                name = "Player 2";
            player1 = new Player(name, new Point(coordinatesX[0] - positionSdvig, coordinatesY[0] - positionSdvig), 4);
            player2 = new Player($"Player", new Point(coordinatesX[0], coordinatesY[0]), 1);

            Controls.Add(player1.Draw());
            Controls.Add(player2.Draw());
            Receive();
        }

        private void rollButon_Click(object sender, EventArgs e)
        {
            labelCountSteps.Visible = true;
            rollButon.Enabled = false;

            Random random = new Random();
            var steps = random.Next(2, 13);
            dicePictureBox.Visible = true;
            dicePictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            string picture = $"\\images\\steps{steps}.png";
            dicePictureBox.Image = Image.FromFile(Path.Join(Directory.GetCurrentDirectory(), @picture));
            position = player1.Move(position, steps);


            if (CheckRed_Pos())
            {
                if (player1.IsWinner)
                {
                    position = 102;
                    Controls.Add(player1.Draw());
                    youWon();
                }
                Controls.Add(player1.Draw());
                labelCountSteps.Text = $"{steps} {position}";

                string message = $"{player1.Body.Location.X} {player1.Body.Location.Y} \n";
                byte[] buffer = Encoding.UTF8.GetBytes(message);
                tcpClient.Send(buffer);
                if (!a) { Receive(); }
            }
            else
            {
                string message = $"M {player1.Body.Location.X} {player1.Body.Location.Y} \n";
                tcpClient.Send(Encoding.UTF8.GetBytes(message));
                if (!a) { Receive(); }
            }


        }

        public int[] redX_Cord = new int[] { 79, 564, 1154, 861, 516, 84, 649, 1003 };
        public int[] redY_Cord = new int[] { 448, 755, 519, 405, 362, 258, 57, 205 };

        private bool CheckRed_Pos()
        {
            for (int i = 0; i < redX_Cord.Length; i++)
            {
                if (player1.Body.Location == new Point(redX_Cord[i], redY_Cord[i]))
                {
                    return false;
                }
            }
            return true;
        }

        private void Receive()
        {
            string turn = Read();

            if (turn.Split(' ')[0] == "P1")
            {                
                l.Enabled = true;
                l.Visible = true;
                l.Text = $"Паузу поставил {turn.Split(' ')[1]}";
                Thread.Sleep(3000);
                tcpClient.Send(Encoding.UTF8.GetBytes($"PN2 {player1.Name} \n"));
                rollButon.Enabled = false;
                return;
            }
            else
            {
                rollButon.Enabled = true;
            }

            if (turn.Split(' ')[0] == "1")
            {
                rollButon.Enabled = true;
            }
            else { rollButon.Enabled = false; }

            if (turn.Split(' ')[1] == "WIN")
            {
                Lose();
            }
            else
            {
                player2.Body.Location = new Point(Convert.ToInt32(turn.Split(' ')[1]),
                                              Convert.ToInt32(turn.Split(' ')[2]));
            }
        }

        public void Lose()
        {
            labelWin.Visible = true;
            labelWin.Text = $"you are looser!!!";
            labelCountSteps.Visible = false;
            rollButon.Visible = false;
        }

        private void youWon()
        {
            a = true;
            labelWin.Visible = true;
            labelWin.Text = $"You are winner!!!";
            labelCountSteps.Visible = false;
            rollButon.Visible = false;
            tcpClient.Send(Encoding.UTF8.GetBytes("WIN"));
        }

        //метод для нахождения координат
        //private void Form1_MouseClick(object sender, MouseEventArgs e)
        //{
        //    textBox1.Text = Convert.ToString(e.X);
        //    textBox2.Text = Convert.ToString(e.Y);
        //}

        static private int[] coordinatesXInit()
        {
            int[] array = new int[102]
            {
                135,
                96, 84, 79, 86, 107, 140, 182, 229, 227, 325,
                372, 418, 465, 513, 564, 612, 664, 715, 768, 820,
                874, 926, 976, 1028, 1077, 1120, 1154, 1158, 1140, 1117,
                1088, 1046, 1000, 956, 910, 861, 810, 775, 752, 742,
                722, 708, 678, 626, 584, 555, 538, 528, 516, 509,
                477, 426, 371, 321, 268, 214, 166, 121, 84, 56,
                47, 40, 54, 82, 120, 171, 224, 270, 310, 354,
                407, 456, 509, 557, 605, 649, 695, 742, 785, 835,
                887, 936, 988, 1038, 1083, 1118, 1148, 1155, 1158, 1148,
                1127,1092, 1050, 1003, 956, 909, 883, 887, 903, 937,
                1008
            };

            return array;
        }
        static private int[] coordinatesYInit()
        {
            int[] array = new int[102]
            {
                362,
                300, 250, 205, 157, 116, 79, 52, 35, 35, 37,
                42, 54, 65, 69, 57, 50, 40, 36, 35, 33,
                33, 33, 38, 43, 60, 87, 128, 181, 230, 273,
                305, 338, 363, 383, 400, 405, 400, 370, 326, 278,
                231, 183, 141, 137, 165, 207, 258, 308, 362, 411,
                449, 462, 460, 446, 434, 439, 452, 479, 519, 567,
                620, 670, 719, 763, 795, 814, 807, 783, 753, 728,
                713, 712, 713, 720, 736, 755, 774, 794, 815, 824,
                827, 828, 821, 812, 793, 760, 720, 671, 622, 572,
                528, 491, 468, 448, 449, 462, 507, 557, 600, 638,
                669

            };

            return array;
        }

        private void Pause_Click(object sender, EventArgs e)
        {
            if (!pause_button)
            {
                lb.Enabled = true;
                lb.Visible = true;
                lb.Items.Add(player1.Name);
                rollButon.Enabled = false;
                tcpClient.Send(Encoding.UTF8.GetBytes($"P1 {player1.Name} \n"));

                string decision = Read();
                lb.Items.Add(decision);
                pause_button = true;
            }
            else
            {
                lb.Enabled = false;
                lb.Visible = false;
                rollButon.Enabled = true;

                pause_button = false;
                lb.Items.Clear();

            }
        }

        private string Read()
        {
            string answer;
            var response = new List<byte>();
            byte[] bytesRead = new byte[1];
            while (true)
            {
                var count = tcpClient.Receive(bytesRead);
                // смотрим, если считанный байт представляет конечный символ, выходим
                if (count == 0 || bytesRead[0] == '\n') break;
                // иначе добавляем в буфер
                response.Add(bytesRead[0]);
            }
            return answer = Encoding.UTF8.GetString(response.ToArray());
        }
    }
}