using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    public class AddWindowPresenter
    {
        public static void AddTask(Task task)
        {
            App.tasks.Add(task);
        }
    }
}
