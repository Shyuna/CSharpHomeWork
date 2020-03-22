using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework1_Pro2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string num1 = textBox1.Text.ToString();
                string num2 = textBox2.Text.ToString();

                int intNum1 = Convert.ToInt32(num1);        //将输入框的字符转化成整数
                int intNum2 = Convert.ToInt32(num2);        

                if (comboBox1.Text == "+")                  //根据选择的运算符，进行相应计算
                {
                    string result = (intNum1 + intNum2).ToString();
                    textBox3.Text = result;
                }
                else if (comboBox1.Text == "-")
                {
                    string result = (intNum1 - intNum2).ToString();
                    textBox3.Text = result;
                }
                else if (comboBox1.Text == "*")
                {
                    string result = (intNum1 * intNum2).ToString();
                    textBox3.Text = result;
                }
                else if (comboBox1.Text == "/")
                {
                    if (intNum2 == 0)
                    {
                        MessageBox.Show("除数不能为零，请重新输入！","提示");     //除数为零，弹出提示框
                    }
                    else
                    {
                        double douNum1 = intNum1;
                        string result = (douNum1 / intNum2).ToString();
                        textBox3.Text = result;
                    }
                }
            }

            catch (Exception m)
            {
                MessageBox.Show("输入不是整数，请重新输入！" ,"提示");      //输入不是整数，弹出提示框
            }
        }
    }
}
