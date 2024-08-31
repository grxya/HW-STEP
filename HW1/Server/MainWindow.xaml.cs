using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Server
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IPAddress _ipAddr;
        private IPEndPoint _ipEndPoint;
        private readonly Socket _sListener;
        private readonly Socket _handler;

        public MainWindow()
        {
            InitializeComponent();
 
                _ipAddr = IPAddress.Parse("192.168.56.1");
                _ipEndPoint = new IPEndPoint(_ipAddr, 11000);
                _sListener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                _sListener.Bind(_ipEndPoint); // связываю прослушку с конечной точкой
                                              // начинаю прослушку.
                                              // backlog - максимальное количество клиентов, которые могут подключиться к серверу

                _sListener.Listen(10);
                _handler = _sListener.Accept();
            
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string? data = null;
            byte[] buffer = new byte[1024]; // буфер для получаемых данных

            _handler.Receive(buffer); // Receive возвращает количество полученных байтов

            data = Encoding.UTF8.GetString(buffer, 0, buffer.Length); // конвертирую байты в строку

            Console.WriteLine($"Received data: {data}\nEnter your message to client: ");

            _handler.Send(Encoding.UTF8.GetBytes(MessageTextBox.Text));
        }
    }
}