using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace C_Sharp_Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void decimal_button_Click(object sender, EventArgs e)
        {
            textBox1.AppendText(".");
        }

        private void zero_button_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("0");
        }

        private void one_button_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("1");
        }

        private void two_button_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("2");
        }

        private void three_button_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("3");
        }

        private void four_button_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("4");
        }

        private void five_button_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("5");
        }

        private void six_button_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("6");
        }

        private void seven_button_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("7");
        }

        private void eight_button_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("8");
        }

        private void nine_button_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("9");
        }

        private void addition_button_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("+");
        }

        private void subtraction_button_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("-");
        }

        private void division_button_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("/");
        }

        private void multiplication_button_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("*");
        }

        private void equal_button_Click(object sender, EventArgs e)
        {
            textBox1.Text = Calculator.calculate(textBox1.Text);
        }

        private void event_keydown(object sender, KeyEventArgs e)
        {
            if (e.Shift)
            {
                switch(e.KeyCode)
                {
                    case Keys.OemMinus:
                        textBox1.AppendText("-");
                        break;
                    case Keys.Oemplus:
                        textBox1.AppendText("+");
                        break;
                    case Keys.D8:
                        textBox1.AppendText("*");
                        break;
                }
            } else
            {
                switch (e.KeyCode)
                {
                    case Keys.D0:
                        textBox1.AppendText("0");
                        break;
                    case Keys.NumPad0:
                        textBox1.AppendText("0");
                        break;
                    case Keys.D1:
                        textBox1.AppendText("1");
                        break;
                    case Keys.NumPad1:
                        textBox1.AppendText("1");
                        break;
                    case Keys.D2:
                        textBox1.AppendText("2");
                        break;
                    case Keys.NumPad2:
                        textBox1.AppendText("2");
                        break;
                    case Keys.D3:
                        textBox1.AppendText("3");
                        break;
                    case Keys.NumPad3:
                        textBox1.AppendText("3");
                        break;
                    case Keys.D4:
                        textBox1.AppendText("4");
                        break;
                    case Keys.NumPad4:
                        textBox1.AppendText("4");
                        break;
                    case Keys.D5:
                        textBox1.AppendText("5");
                        break;
                    case Keys.NumPad5:
                        textBox1.AppendText("5");
                        break;
                    case Keys.D6:
                        textBox1.AppendText("6");
                        break;
                    case Keys.NumPad6:
                        textBox1.AppendText("6");
                        break;
                    case Keys.D7:
                        textBox1.AppendText("7");
                        break;
                    case Keys.NumPad7:
                        textBox1.AppendText("7");
                        break;
                    case Keys.D8:
                        textBox1.AppendText("8");
                        break;
                    case Keys.NumPad8:
                        textBox1.AppendText("8");
                        break;
                    case Keys.D9:
                        textBox1.AppendText("9");
                        break;
                    case Keys.NumPad9:
                        textBox1.AppendText("9");
                        break;
                    case Keys.OemPeriod:
                        textBox1.AppendText(".");
                        break;
                    case Keys.Decimal:
                        textBox1.AppendText(".");
                        break;
                    case Keys.Multiply:
                        textBox1.AppendText("*");
                        break;
                    case Keys.Add:
                        textBox1.AppendText("+");
                        break;
                    case Keys.Subtract:
                        textBox1.AppendText("-");
                        break;
                    case Keys.Divide:
                        textBox1.AppendText("/");
                        break;
                    case Keys.Delete:
                        textBox1.Text = "";
                        break;
                    case Keys.Back:
                        if (textBox1.Text.Length != 0)
                        {
                            textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
                        }
                        break;
                    case Keys.Enter:
                        textBox1.Text = Calculator.calculate(textBox1.Text);
                        break;
                }
            }
        }
    }

    class Calculator
    {

        private static Regex operationRegex = new Regex("[/+*-]");
        private static Regex validationRegex = new Regex(@"^(\d+[\+\.\-\*\/]{1})+\d+$");

        public static string calculate(string input)
        {
            if (validationRegex.IsMatch(input))
            {
                string current = input;
                char[] operators = { '/', '*', '-', '+' };
                MatchCollection matches = operationRegex.Matches(input);
                for (int i = 0; i < matches.Count; i++)
                {
                    List<string> splitCurrent = Regex.Split(current, @"(\+)|(-)|(/)|(\*)").ToList();
                    if (splitCurrent.Contains("*"))
                    {
                        int index = splitCurrent.IndexOf("*");
                        splitCurrent[index] = (double.Parse(splitCurrent[index - 1]) * double.Parse(splitCurrent[index + 1])).ToString();
                        splitCurrent.RemoveAt(index - 1);
                        splitCurrent.RemoveAt(index);
                        current = String.Join("", splitCurrent);
                    }
                    else if (splitCurrent.Contains("/"))
                    {
                        int index = splitCurrent.IndexOf("/");
                        splitCurrent[index] = (double.Parse(splitCurrent[index - 1]) / double.Parse(splitCurrent[index + 1])).ToString();
                        splitCurrent.RemoveAt(index - 1);
                        splitCurrent.RemoveAt(index);
                        current = String.Join("", splitCurrent);
                    }
                    else if (splitCurrent.Contains("+"))
                    {
                        int index = splitCurrent.IndexOf("+");
                        splitCurrent[index] = (double.Parse(splitCurrent[index - 1]) + double.Parse(splitCurrent[index + 1])).ToString();
                        splitCurrent.RemoveAt(index - 1);
                        splitCurrent.RemoveAt(index);
                        current = String.Join("", splitCurrent);
                    }
                    else if (splitCurrent.Contains("-"))
                    {
                        int index = splitCurrent.IndexOf("-");
                        splitCurrent[index] = (double.Parse(splitCurrent[index - 1]) - double.Parse(splitCurrent[index + 1])).ToString();
                        splitCurrent.RemoveAt(index - 1);
                        splitCurrent.RemoveAt(index);
                        current = String.Join("", splitCurrent);
                    }
                }
                return current;
            }
            else
            {
                return "Error";
            }
        }
    }
}
