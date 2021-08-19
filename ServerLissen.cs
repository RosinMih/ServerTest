using System;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;


namespace ServerTest
{
    public class ServerLissen
    {
        public static void Lissen(object obj)
            //This method creates a socket,
            //listens to this socket,
            //sends a response message when receiving messages,
            //and transmits information to the main form.

        {
            parameters_to_serverLissen parameters_from_MainFirm = (parameters_to_serverLissen)obj;
            string IP_adress = parameters_from_MainFirm.IP_to_serverLissen;
            int Port = parameters_from_MainFirm.Port_to_serverLissen;
            try
            {
                IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(IP_adress), Port);
                Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                listenSocket.Bind(ipPoint); 
                listenSocket.Listen(10);
                MainFormServer.StringBuilder_message.Clear();
                MainFormServer.StringBuilder_message = MainFormServer.StringBuilder_message.Append("Сервер запущен IP: " + IP_adress + "PORT:  " + Port.ToString() + "...\r\n");
                while (true)
                {
                    Socket Socket_server = listenSocket.Accept();
                    StringBuilder received_data = new StringBuilder();
                    int received_byte_number = 0;
                    byte[] received_byte = new byte[256];
                    do
                    {
                        received_byte_number = Socket_server.Receive(received_byte);
                        received_data.Append(Encoding.UTF8.GetString(received_byte, 0, received_byte_number));
                    }
                    while (Socket_server.Available > 0);
                    string response_message = DateTime.Now.ToString() + "  Получено сообщение:  " + received_data.ToString();
                    byte[] response_message_is_byte = Encoding.UTF8.GetBytes(response_message);
                    Socket_server.Send(response_message_is_byte);
                    MainFormServer.StringBuilder_message.Clear();
                    MainFormServer.StringBuilder_message = MainFormServer.StringBuilder_message.Append(response_message + "\r\n Отправлен ответ \r\n "); 
                    Socket_server.Shutdown(SocketShutdown.Both);
                    Socket_server.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString() + "\r\n Программа завершена");
                Environment.Exit(0);
            }
        }
    }
}
