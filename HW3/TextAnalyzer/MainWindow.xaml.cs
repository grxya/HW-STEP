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

namespace TextAnalyzer
{
    public partial class MainWindow : Window
    {
        private readonly TextReportService _textReportService = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var result = await ReportGenerator();

            using StreamWriter sw = new(new FileStream("report.txt", FileMode.OpenOrCreate));

            await sw.WriteAsync(result);
        }

        private async void ShowButton_Click(object sender, RoutedEventArgs e)
        {
            ReportTextBox.Text = await ReportGenerator();
        }

        private async Task<string> ReportGenerator()
        {
            if (FullCheckBox.IsChecked == true)
            {
                return await _textReportService.FullReport(MainTextBox.Text);
            }

            string result = "";

            if (SentencesCheckBox.IsChecked == true)
            {
                result += await _textReportService.NumberOfSentences(MainTextBox.Text);
            }
            if (SymbolsCheckBox.IsChecked == true)
            {
                result += await _textReportService.NumberOfSymbols(MainTextBox.Text);
            }
            if (WordsCheckBox.IsChecked == true)
            {
                result += await _textReportService.NumberOfWords(MainTextBox.Text);
            }
            if (ExclamatoryCheckBox.IsChecked == true)
            {
                result += await _textReportService.NumberOfExclamatory(MainTextBox.Text);
            }
            if (QuestionsCheckBox.IsChecked == true)
            {
                result += await _textReportService.NumberOfQuestions(MainTextBox.Text);
            }

            return result;
        }

    }
}