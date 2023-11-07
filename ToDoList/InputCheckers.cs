using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    public class InputCheckers
    {
        public static bool IsDueDateValid(DateTime dueDate)
        {
            return dueDate > DateTime.Now;
        }
    }
}
