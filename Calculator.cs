using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3
{
    class Calculator
    {
        private char action = 'x';

        //Constructor
        public Calculator() { }

        public void setAction(char x)
        {
            action = x;
        }

        //Method that calls the approriate calculation method based on the operator
        public double calculate(int op1, int op2)
        {
             double result;

            switch (action)
            {
                case '+':
                    result = add(op1, op2);
                    break;
                case '-':
                    result = subtract(op1, op2);
                    break;
                case '*':
                    result = multiply(op1, op2);
                    break;
                default:
                    result = divide(op1, op2);
                    break;
            }

            return result;
        }

        //private methods for handling the math

        private int add(int op1, int op2)
        {
            return op1 + op2;
        }

        private int subtract(int op1, int op2)
        {
            return op1 - op2;
        }

        private int multiply(int op1, int op2)
        {
            return op1 * op2;
        }

        private double divide(int op1, int op2)
        {
            
            return (double)op1 / (double)op2;
        }

    }
}
