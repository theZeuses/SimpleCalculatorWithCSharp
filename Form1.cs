using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace calculaterWithCS
{
    public partial class Form1 : Form
    {
        string inputed,resulted;
        double firstVariable, secondVariable, ans=0;
        int operatorPos;
        byte operation=0;
        bool flag = false;
        bool start = true;
        double memory = 0;
        bool memOk = false;

        public Form1()
        {
            InitializeComponent();
            inputed = "";
            input.Text = "";
            result.Text = "0";
            label1.Text = "";
        }

        private void offBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            inputed =inputed+ "1";
            input.Text = inputed;
            flag = false;
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            inputed = inputed + "2";
            input.Text = inputed;
            flag = false;
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            inputed = inputed + "3";
            input.Text = inputed;
            flag = false;
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            inputed = inputed + "4";
            input.Text = inputed;
            flag = false;
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            inputed = inputed + "5";
            input.Text = inputed;
            flag = false;
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            inputed = inputed + "6";
            input.Text = inputed;
            flag = false;
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            inputed = inputed + "7";
            input.Text = inputed;
            flag = false;
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            inputed = inputed + "8";
            input.Text = inputed;
            flag = false;
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            inputed = inputed + "9";
            input.Text = inputed;
            flag = false;
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if (!inputed.Equals(""))
            {
                inputed = inputed + "0";
                input.Text = inputed;
                flag = false;
            }
        }

        private void btnPoint_Click(object sender, EventArgs e)
        {
            inputed = inputed + ".";
            input.Text = inputed;
            
        }

        private void bckSpcBtn_Click(object sender, EventArgs e)
        {
            if(inputed.Length!=0)
                inputed = inputed.Remove(inputed.Length - 1);
            input.Text = inputed;
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            inputed = "";
            resulted = "0";
            input.Text = inputed;
            printResult();
            ans = 0;
            label1.Text = "";
            memOk = false;
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            Operation(1, "/");

        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            doMath();
            flag = true;
        }

        private void printResult()
        {
            int length = resulted.Length;
            result.Text = resulted;
            result.Location = new Point(296 - (9 * (length-1)), 62);
        }

        private void btnMul_Click(object sender, EventArgs e)
        {
            Operation(2, "*");
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            Operation(3, "+");
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            Operation(4, "-");
        }

        public void Operation(byte opt, string sign)
        {
            try
            {
                firstVariable = Double.Parse(inputed);
                operatorPos = inputed.Length + 1;
                operation = opt;
                inputed = inputed + sign;
                input.Text = inputed;
            }
            catch (FormatException ex)
            {
                if (!start && !flag)
                {

                    doMath();
                    operation = opt;
                    inputed = ans.ToString() + sign;
                    operatorPos = inputed.Length;
                    input.Text = inputed;
                    firstVariable = ans;
                }
                else if (!start && flag)
                {
                    operation = opt;
                    inputed = ans.ToString() + sign;
                    operatorPos = inputed.Length;
                    input.Text = inputed;
                    firstVariable = ans;
                    flag = false;
                }
                else
                {
                    doMath();
                    operation = opt;
                    inputed = ans.ToString() + sign;
                    operatorPos = inputed.Length;
                    input.Text = inputed;
                }
            }
        }

        public void doMath()
        {
            if (inputed.Length != 0)
            {
                try
                {
                    secondVariable = Double.Parse(inputed.Substring(operatorPos));
                    if (operation != 0)
                    {
                        if (operation == 1)
                            resulted = (firstVariable / secondVariable).ToString();
                        else if (operation == 2)
                            resulted = (firstVariable * secondVariable).ToString();
                        else if (operation == 3)
                            resulted = (firstVariable + secondVariable).ToString();
                        else if (operation == 4)
                            resulted = (firstVariable - secondVariable).ToString();

                        ans = Convert.ToDouble(resulted);
                        firstVariable = ans;
                        printResult();
                        inputed = "";
                        start = false;
                    }
                }
                catch (NullReferenceException ex) { }
                catch (FormatException ex) { }
            }
            else
            {
                if (operation != 0)
                {
                    if (operation == 1)
                        resulted = (firstVariable / secondVariable).ToString();
                    else if (operation == 2)
                        resulted = (firstVariable * secondVariable).ToString();
                    else if (operation == 3)
                        resulted = (firstVariable + secondVariable).ToString();
                    else if (operation == 4)
                        resulted = (firstVariable - secondVariable).ToString();

                    ans = Convert.ToDouble(resulted);
                    firstVariable = ans;
                    printResult();
                    inputed = "";
                }
            }
        }

        private void btnMPos_Click(object sender, EventArgs e)
        {
            memory += ans;
            label1.Text = "M";
            memOk = true;
        }

        private void btnMNeg_Click(object sender, EventArgs e)
        {
            if (memOk)
            {
                memory -= ans;
                label1.Text = "M";
            }
        }

        private void btnMR_Click(object sender, EventArgs e)
        {
            if (memOk)
            {
                resulted = memory.ToString();
                input.Text = "Memory";
                ans = memory;
                printResult();
                label1.Text = "M";
            }
        }

        private void btnMC_Click(object sender, EventArgs e)
        {
            memory = 0;
            input.Text = "";
            label1.Text = "";
            memOk = false;
        }
      
    }
}
