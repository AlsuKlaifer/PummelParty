using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PummelParty
{
    internal class Player
    {
        public int Width { get; set; } = 30;
        public int Height { get; set; } = 30;
        public Point StartLocation { get; set; }
        public PictureBox Body { get; private set; } = new PictureBox();

        public Player(Point startLocation)
        {
            StartLocation = startLocation;
            InitializeObject();
        }

        private void InitializeObject()
        {
            Body.Image = Image.FromFile(Path.Join(Directory.GetCurrentDirectory(), @"\images\player2.png"));
            Body.Location = StartLocation;
            Body.SizeMode = PictureBoxSizeMode.StretchImage;
            Body.Width = Width;
            Body.Height = Height;
        }

        public PictureBox Draw()
        {
            return Body;
        }
    }
}
