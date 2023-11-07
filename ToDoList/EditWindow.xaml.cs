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
using System.Windows.Shapes;

namespace ToDoList
{
    public partial class EditWindow : Window
    {
        public EditWindow()
        {
            InitializeComponent();
        }

        public void EditTask(Task task)
        {
            NameTextBox.Text = task.Name;
            DueDatePicker.SelectedDate = task.Due;
            DescriptionTextBox.Text = task.Description;
            StatusCheckBox.IsChecked = task.Status;
            this.ShowDialog();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (InputCheckers.IsDueDateValid(DueDatePicker.SelectedDate.Value))
            {
                Task tempTask = MainWindow.SelectedTask;

                tempTask.Name = NameTextBox.Text;
                tempTask.Due = DueDatePicker.SelectedDate.Value;
                tempTask.Description = DescriptionTextBox.Text;
                tempTask.Status = StatusCheckBox.IsChecked.Value;

                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid date input!");
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            App.tasks.Remove(MainWindow.SelectedTask);

            this.Close();
        }
    }
}
