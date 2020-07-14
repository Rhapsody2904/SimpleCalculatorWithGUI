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

namespace Project3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Calculator myCalc;
        int op1 = -1; //since we're only using positive, one digit ints, -1 is an easy way to track if a value has been assigned.
        int op2 = -1; //realistically, I'd have boolean values to track changes for each operand
        char action = 'x';  //default (non-math) value for operator
        Boolean isOn = false; //track if calculator is on

        public MainWindow()
        {
            InitializeComponent();
        }

        private void on_Click(object sender, RoutedEventArgs e)
        {
            myCalc = new Calculator();
            screen.Text = "0";
            isOn = true;
        }

        private void off_Click(object sender, RoutedEventArgs e)
        {
            myCalc = null;
            isOn = false;
            screen.Text = "";
        }
               
        private void clear_Click(object sender, RoutedEventArgs e)
        {
            if (isOn)
            {
                screen.Text = "0";
                op1 = -1;
                op2 = -1;
                action = 'x';
            }
        }

        private void b0_Click(object sender, RoutedEventArgs e)
        {
            assign(0);
        }

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            assign(1);
        }

        private void b2_Click(object sender, RoutedEventArgs e)
        {
            assign(2);
        }

        private void b3_Click(object sender, RoutedEventArgs e)
        {
            assign(3);
        }

        private void b4_Click(object sender, RoutedEventArgs e)
        {
            assign(4);
        }

        private void b5_Click(object sender, RoutedEventArgs e)
        {
            assign(5);
        }

        private void b6_Click(object sender, RoutedEventArgs e)
        {
            assign(6);
        }

        private void b7_Click(object sender, RoutedEventArgs e)
        {
            assign(7);
        }

        private void b8_Click(object sender, RoutedEventArgs e)
        {
            assign(8);
        }

        private void b9_Click(object sender, RoutedEventArgs e)
        {
            assign(9);
        }

        private void div_Click(object sender, RoutedEventArgs e)
        {
            assignAction('/');
        }

        private void mult_Click(object sender, RoutedEventArgs e)
        {
            assignAction('*');
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            assignAction('+');
        }

        private void sub_Click(object sender, RoutedEventArgs e)
        {
            assignAction('-');
        }

        private void eq_Click(object sender, RoutedEventArgs e)
        {
            if (isOn)
            {

                if (action == '+' || action == '-') //check if equals was pressed before pressing an operatpr
                {
                    if (op1 == -1) //temporarilly assign 0 values
                        op1 = 0;
                    if (op2 == -1)
                        op2 = 0;

                    screen.Text = (myCalc.calculate(op1, op2)).ToString();
                }

                if (action == '*' || action == '/') //check if equals was pressed before pressing an operatpr
                {
                    if (op1 == -1) //temporarilly assign 0 values
                        op1 = 1;
                    if (op2 == -1)
                        op2 = 1;

                    if (action == '/' && op2 == 0) //handle division by 0
                        screen.Text = "ERROR";
                    else
                        screen.Text = (myCalc.calculate(op1, op2)).ToString();
                }

                action = 'x';
                op1 = -1;
                op2 = -1;
            }
        }

        //helper method for assigning operands
        private void assign (int a)
        {
            if (isOn)
            {
                if (action == 'x')
                    op1 = a;
                else
                    op2 = a;

                screen.Text = a.ToString();
            }
        }

        //helper method for assigning operators
        private void assignAction (char a)
        {
            if (isOn && op1 != -1)
            { 
                action = a;
                myCalc.setAction(action);
            }
        }
    }
}
