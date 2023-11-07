using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ToDoList
{
    public partial class MainWindow : Window
    {
        public static Task SelectedTask = new Task();
        public MainWindow()
        {
            InitializeComponent();
            TasksListBox.ItemsSource = App.tasks;
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow();
            addWindow.ShowDialog();
        }

        private void TasksListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            EditWindow editWindow = new EditWindow();
            SelectedTask = TasksListBox.SelectedItem as Task;
            editWindow.EditTask(SelectedTask);
            TasksListBox.Items.Refresh();
        }
    }
}
