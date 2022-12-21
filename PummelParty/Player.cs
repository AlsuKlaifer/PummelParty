using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PummelParty
{
    internal class Player
    {
        public string Name { get; set; }
        public int Width { get; set; } = 30;
        public int Height { get; set; } = 30;
        public Point StartLocation { get; set; }
        public PictureBox Body { get; private set; } = new PictureBox();
        public bool IsWinner { get; set; } = false;
        public Player(string name, Point startLocation)
        {
            Name = name;
            StartLocation = startLocation;
            InitializeObject();
        }

        private void InitializeObject()
        {
            Random random = new Random();
            int numberOfImage = random.Next(1, 3);

            string imagePath = $"\\images\\player{numberOfImage}.png";

            //круглые аватарки
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, 30, 30);
            Region rgn = new Region(path);
            Body.Region = rgn;
            Body.BackColor = SystemColors.ActiveCaption;

            Body.Image = Image.FromFile(Path.Join(Directory.GetCurrentDirectory(), @imagePath));
            Body.Location = StartLocation;
            Body.SizeMode = PictureBoxSizeMode.StretchImage;
            Body.Width = Width;
            Body.Height = Height;
        }

        public PictureBox Draw()
        {
            return Body;
        }

        public int[] coordinatesX = coordinatesXInit();
        public int[] coordinatesY = coordinatesYInit();
        
        public void Move(int position, int steps)
        {
            Random random = new Random();
            int positionSdvig = random.Next(5, 20);
            position += steps;
            if (position > 101)
            {
                position = 101;
                Body.Location = new Point(coordinatesX[position] - positionSdvig, coordinatesY[position] - positionSdvig);
                IsWinner = true;
            }
            Body.Location = new Point(coordinatesX[position] - positionSdvig, coordinatesY[position] - positionSdvig);
        }

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
