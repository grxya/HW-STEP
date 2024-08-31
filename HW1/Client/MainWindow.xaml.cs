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

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IPAddress _ipAddr;
        private IPEndPoint _ipEndPoint;
        private readonly Socket _sListener;

        public MainWindow()
        {
            InitializeComponent();
            _sListener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _ipAddr = IPAddress.Parse(IpAddressTextBox.Text);
                _ipEndPoint = new IPEndPoint(_ipAddr, Convert.ToInt32(PortTextBox.Text));
                _sListener.Connect(_ipEndPoint);
            }
            catch (Exception ex) { MessageBox.Show("Couldn't connect!"); }
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            if (_ipAddr != null && _ipEndPoint != null)
            {
                if (MessageTextBox.Text == "Bye")
                {
                    _sListener.Shutdown(SocketShutdown.Both);
                    _sListener.Close();
                    _ipAddr = null;
                    _ipEndPoint = null;
                }
                else
                {
                    byte[] messageBytes = Encoding.UTF8.GetBytes(MessageTextBox.Text);

                    _sListener.Send(messageBytes);

                    byte[] bytes = new byte[1024];

                    int bytesRec = _sListener.Receive(bytes);
                    string message = Encoding.UTF8.GetString(bytes, 0, bytesRec);

                    if (message == "bye")
                    {
                        _sListener.Shutdown(SocketShutdown.Both);
                        _sListener.Close();
                        _ipAddr = null;
                        _ipEndPoint = null;
                    }
                }
            }
            else
            {
                MessageBox.Show("Connection wasn't found!");
            }
        }
    }
}