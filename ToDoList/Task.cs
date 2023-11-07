using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    public class Task
    {
        public string Name { get; set; }
        public DateTime Due { get; set; }
        public string Description { get; set; }

        public bool Status { get; set; }

        public override string ToString()
        {
            if (Status)
            {
                return $"{Name} - {Due.ToShortDateString()} - Done";
            }
            else
            {
                return $"{Name} - {Due.ToShortDateString()} - Not done";
            }
        }
    }
}
