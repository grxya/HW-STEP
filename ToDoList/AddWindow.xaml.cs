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
    public partial class AddWindow : Window
    {
        public AddWindow()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (DueDatePicker.SelectedDate.HasValue && InputCheckers.IsDueDateValid(DueDatePicker.SelectedDate.Value))
            {
                Task task = new Task
                {
                    Name = NameTextBox.Text,
                    Due = DueDatePicker.SelectedDate.Value,
                    Description = DescriptionTextBox.Text,
                    Status = false
                };

                AddWindowPresenter.AddTask(task);

                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid date input!");
            }
        }
    }
}
