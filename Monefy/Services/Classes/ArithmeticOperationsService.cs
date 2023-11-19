using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.Services.Classes
{
    class ArithmeticOperationsService
    {
        public delegate double Operation(double num1, double num2);

        public static double Add(double num1, double num2)
        {
            return num1 + num2;
        }

        public static double Substract(double num1, double num2)
        {
            return num1 - num2;
        }

        public static double Multiply(double num1, double num2)
        {
            return num1 * num2;
        }

        public static double Divide(double num1, double num2)
        {
            return num1 / num2;
        }
    }
}
