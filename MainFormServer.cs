using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Threading;

namespace ServerTest
{

    public partial class MainFormServer : Form
    {

        public MainFormServer()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public static StringBuilder StringBuilder_message = new StringBuilder(200);
        parameters_to_serverLissen Parameters_To_ServerLissen = new parameters_to_serverLissen();
        Thread Thread_to_serverLissen = new Thread(new ParameterizedThreadStart(ServerLissen.Lissen));


        private void button_Start_Click(object sender, EventArgs e)
        {
            string IP;
            int Prt;
            if (IPAddress.TryParse(textBox_IPAdr.Text, out IPAddress address))
            {
                IP = textBox_IPAdr.Text;
            }
            else
            {
                textBox_In_message.Text = textBox_In_message.Text + "Ошибочно введен IP адрес \r\n";
                return;
            }
            try
            {
                Prt = Convert.ToInt32(textBox_Port.Text);
            }
             catch
            {
                textBox_In_message.Text = textBox_In_message.Text + "Ошибочно введен номер порта \r\n";
                return;
            }

            Parameters_To_ServerLissen.IP_to_serverLissen = IP;
            Parameters_To_ServerLissen.Port_to_serverLissen = Prt;

                if (!Thread_to_serverLissen.IsAlive)
                {
                    Thread_to_serverLissen.Start(Parameters_To_ServerLissen);
                    Thread_to_serverLissen.IsBackground = true;
                    button_Start.BackColor = Color.Red;
                }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (StringBuilder_message.Length > 0)
            {
                textBox_In_message.Text = textBox_In_message.Text + StringBuilder_message.ToString();
                StringBuilder_message.Clear();
            }
        }


        private void button_Clear_Click(object sender, EventArgs e)
        {
            textBox_In_message.Clear();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            textBox_In_message.Height = this.Height - 230;
        }

    }
    internal class parameters_to_serverLissen
    {
        public string IP_to_serverLissen;
        public int Port_to_serverLissen;
    }
}
