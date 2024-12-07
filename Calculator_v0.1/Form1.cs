using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Calculator_v0._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private double firstNum;
        private string sign = "";
        private void numberEnter(object sender, EventArgs e)
        {
            string number = ((Button)sender).Text;
            if ((number == "," && (Output.Text.Contains(number) || Output.Text.Length == 0)) || (number != "," && Output.Text == "0"))
            {
                return;
            }
            Output.Text += number;
        }
        private void deleteLine(object sender, EventArgs e)
        {
            Output.Text = "";
        }
        private void backSpace(object sender, EventArgs e)
        {
            if(Output.Text.Length != 0)
            {
                Output.Text = Output.Text.Substring(0, Output.Text.Length - 1);
            }
        }
        private void SignUse(object sender, EventArgs e)
        {
            if(Output.Text.Length == 0)
            {
                return;
            }
            firstNum = Convert.ToDouble(Output.Text);
            sign = ((Button)sender).Text;
            Output.Text = "";
        }
        private void Equal(object sender, EventArgs e)
        {
            if(sign == "" || Output.Text == "")
            {
                return;
            }
            double secondNum = Convert.ToDouble(Output.Text);
            double result = 0;
            switch(sign)
            {
                case "+":
                    result = firstNum + secondNum;
                    break;
                case "-":
                    result = firstNum - secondNum;
                    break;
                case "*":
                    result = firstNum * secondNum;
                    break;
                case "/":
                    if(secondNum != 0)
                    {
                        result = firstNum / secondNum;
                    }
                    else
                    {
                        MessageBox.Show("Dividing by zero is morally wrong");
                        result = 0;
                    }
                    break;
                case "^":
                    result = Math.Pow(firstNum, secondNum);
                    break;
                case "y√x":
                    result = Math.Pow(firstNum, 1 / secondNum);
                    break;
                case "logy(x)":
                    result = Math.Log(firstNum) / Math.Log(secondNum);
                    break;
            }
            Output.Text = result.ToString();
            firstNum = 0;
            sign = "";
        }
        private void SingleNum(object sender, EventArgs e)
        {
            if(Output.Text.Length == 0)
            {
                return;
            }
            double SingleNum = Convert.ToDouble(Output.Text);
            double result = 0;
            switch(((Button)sender).Text)
            {
                case "x^2":
                    result = SingleNum * SingleNum;
                    break;
                case "+/-":
                    result = 0 - SingleNum;
                    break;
                case "%":
                    result = SingleNum / 100;
                    break;
                case "1/x":
                    if (SingleNum != 0)
                    {
                        result = 2 / SingleNum;
                    }
                    else
                    {
                        MessageBox.Show("Dividing by zero is morally wrong");
                        result = 0;
                    }
                    break;
                case "√x":
                    result = Math.Sqrt(SingleNum);
                    break;
                case "log10(x)":
                    result = Math.Log10(SingleNum);
                    break;
                case "ln(x)":
                    result = Math.Log(SingleNum);
                    break;
            }
            Output.Text = result.ToString();
        }
    }
}