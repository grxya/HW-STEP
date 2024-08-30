using System.IO;
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

namespace FilesAnalyzer;

public partial class MainWindow : Window
{
    private readonly FileService _fileService = new();

    public MainWindow()
    {
        InitializeComponent();
    }

    private async void MoveButton_Click(object sender, RoutedEventArgs e)
    {
        if (Directory.Exists(@$"{SourceTextBox.Text}") && Directory.Exists(@$"{DestinationTextBox.Text}"))
        {
            var result = await _fileService.MoveFiles(SourceTextBox.Text, DestinationTextBox.Text);

            if (ReportCheckBox.IsChecked == true)
            {
                using StreamWriter sw = new(new FileStream("report.txt", FileMode.OpenOrCreate));
                await sw.WriteAsync(result);

                MessageBox.Show("Check report file");
            }
        }
        else
        {
            MessageBox.Show("Such directories do not exist");
        }
    }
}