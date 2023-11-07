using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ToDoList
{
    public partial class App : Application
    {
        public static ObservableCollection<Task> tasks = new ObservableCollection<Task>();
    }
}
