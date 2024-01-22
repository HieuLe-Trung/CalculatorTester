using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    public class Calculation
    {
        private int a, b;
        public Calculation(int a, int b)
        {
            this.a = a;
            this.b = b;
        }
        public double Execute(string operation)
        {
            double result = 0;
            switch (operation)
            {
                case "+":
                    result = a + b;
                    break;
                case "-":
                    result = a - b;
                    break;
                case "*":
                    result = a * b;
                    break;
                case "/":
                    if (b == 0)
                    {
                        throw new DivideByZeroException("Cannot divide by zero.");
                    }
                    result = (double)a/b;
                    break;
            }
            return result;
        }
    }
}
