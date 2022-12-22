using System.Net.Sockets;
using System.Text;
using System.Timers;

namespace Server
{
    public partial class Form1 : Form
    {
        Server_Class sc = new Server_Class();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sc.Start_Server();
            MessageBox.Show("All connected");
        }

    }
}