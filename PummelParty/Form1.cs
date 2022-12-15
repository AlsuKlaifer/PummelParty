using Microsoft.VisualBasic.ApplicationServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace PummelParty
{
    public partial class Form1 : Form
    {
        Player player1;
        int position = 0;
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
        }

        public int[] coordinatesX = coordinatesXInit();
        public int[] coordinatesY = coordinatesYInit();

        private void buttonStart_Click(object sender, EventArgs e)
        {
            buttonStart.Visible = false;
            buttonStart.Enabled = false;

            rollButon.Visible = true;
            rollButon.Enabled = true;
            //установка фона
            this.BackgroundImage = Image.FromFile(Path.Join(Directory.GetCurrentDirectory(), @"\images\background.jpg"));

            //появление игроков на старте
            player1 = new Player(new Point(coordinatesX[0], coordinatesY[0]));
            Controls.Add(player1.Draw());
        }

        private void rollButon_Click(object sender, EventArgs e)
        {
            labelCountSteps.Visible = true;
            Random random = new Random();
            var steps = random.Next(1, 13);
            position += steps;
            if (position > 101)
            {
                position = 101;
                player1.Body.Location = new Point(coordinatesX[position], coordinatesY[position]);
                youWon();
            }
            player1.Body.Location = new Point(coordinatesX[position], coordinatesY[position]);
            labelCountSteps.Text = $"{steps} {position}";
        }

        private void youWon()
        {
            labelWin.Visible = true;
            labelWin.Text = "You won!!!";
            labelCountSteps.Visible = false;
            rollButon.Visible = false;
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
    }
}