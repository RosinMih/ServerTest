using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ServerTest
{

    public partial class Form1 : Form
    {
        static StringBuilder strb = new StringBuilder(200);    //Создаем стрингбилдер чрез который будет
                                                               //осуществляться обмен сообщениями
        param pr = new param();
        Thread Thr1 = new Thread(new ParameterizedThreadStart(ServerLissen));  //Создаем второй поток для сервера

        static void ServerLissen (object obj)   //Создаем метод, через который бедет осуществляться
                                                //сетовое взаимодействие
        {
            param p = (param)obj;
            try
            {
                    IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(p.i), Convert.ToInt32(p.p));
                    //IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("192.168.16.193"), Convert.ToInt32(111));
                    Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); // создаем сокет
                    listenSocket.Bind(ipPoint);  // связываем сокет с локальной точкой, по которой будем принимать данные
                    listenSocket.Listen(10);    // начинаем прослушивание
                strb.Clear();
                strb = strb.Append("Сервер запущен IP: " + p.i + "  Port: " + p.p.ToString() + "...\r\n"); 
                while (true)
                {
                    Socket handler = listenSocket.Accept();    //создаем сокет
                    // получаем сообщение
                    StringBuilder in_str = new StringBuilder();
                    int bytes = 0; // количество полученных байтов
                    byte[] data_in = new byte[256]; // буфер для получаемых данных
                    do
                    {
                        bytes = handler.Receive(data_in);
                        in_str.Append(Encoding.UTF8.GetString(data_in, 0, bytes));
                    }
                    while (handler.Available > 0);
                    string message = DateTime.Now.ToString() + "  Получено сообщение:  " + in_str.ToString();
                    byte[] mess_out = Encoding.UTF8.GetBytes(message);
                    handler.Send(mess_out);                       // отправляем ответ
                strb.Clear();
                strb = strb.Append(message + "\r\n Отправлен ответ \r\n ");                   //!!!!!
                handler.Shutdown(SocketShutdown.Both);          // закрываем сокет
                handler.Close();
                }
                //listenSocket.Close();
            }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString()+ "\r\n Программа завершена");
                    Environment.Exit(0);
            }
            finally
            {
                Thread.Sleep(500);
                strb.Clear();
                strb = strb.Append("Сервер остановлен...\r\n");                               //!!!!
            }
        }
        
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)      // При  наажатии на кнопку старт
        {
            string IP;
            int Prt;
            // Определяем является ли строка ip-адресом
            if (IPAddress.TryParse(IPAdr.Text, out IPAddress address))
            {
                //textBox3.Text = textBox3.Text + isIPAddres.ToString() + "\r\n";
                IP = IPAdr.Text;
            }
            else
            {
                textBox3.Text = textBox3.Text + "Ошибочно введен IP адрес \r\n";
                return;
            }
            try
            {
                // Проверяем, корректно ли введен порт
                Prt = Convert.ToInt32(Port.Text);
            }
             catch
            {
                //MessageBox.Show("Ошибочно введен номер порта");
                textBox3.Text = textBox3.Text + "Ошибочно введен номер порта \r\n";
                return;
            }

                // создаем новый поток
                pr.i = IP;
                pr.p = Prt;

                if (!Thr1.IsAlive)                  // если не запущен поток
                {
                    Thr1.Start(pr); // запускаем поток
                    Thr1.IsBackground = true;       //переводим в фоновый режим, для того чтобы завершилось
                                                    //вместе с основным приложением 
                    button1.BackColor = Color.Red;
                }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (strb.Length > 0)
            {
                textBox3.Text = textBox3.Text + strb.ToString();
                strb.Clear();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            textBox3.Height = this.Height - 230;
        }
    }

    public class param
    {
        public string i;
        public int p;
    }

}
