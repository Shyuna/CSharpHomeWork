using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaylayTree
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        public Form1()
        {
            InitializeComponent();
        }

        private void TrbPer1_Scroll(object sender, EventArgs e)
        {
            lblPer1Num.Text = (trbPer1.Value/100.0).ToString();
        }

        private void TrbPer2_Scroll(object sender, EventArgs e)
        {
            lblPer2Num.Text = (trbPer2.Value/100.0).ToString();
        }

        private void TrbTh1_Scroll(object sender, EventArgs e)
        {
            lblTh1Num.Text = trbTh1.Value.ToString();
        }

        private void TrbTh2_Scroll(object sender, EventArgs e)
        {
            lblTh2Num.Text = trbTh2.Value.ToString();
        }


        private void BtnDraw_Click(object sender, EventArgs e)
        {           
            if (graphics == null) graphics = pnlDrawField.CreateGraphics();
            if(txtN.Text==""||txtLeng.Text==""||lblPer1Num.Text==""||lblPer2Num.Text==""
                ||lblTh1Num.Text==""||lblTh2Num.Text == "")
            {
                MessageBox.Show("请输入数据后再点击绘制按钮！");
                return;
            }
            else
            {
                graphics.Clear(pnlDrawField.BackColor);
                try
                {
                    if (Int32.Parse(txtN.Text) <= 0)
                    {
                        MessageBox.Show("输入的递归深度不是正数，请重新输入！");
                        return;
                    }
                    else if (Int32.Parse(txtLeng.Text) <= 0)
                    {
                        MessageBox.Show("输入的主干长度不是正数，请重新输入！");
                        return;
                    }
                    else
                    {
                        drawCayleyTree(Int32.Parse(txtN.Text), 135, 310, Int32.Parse(txtLeng.Text),
    -Math.PI / 2, Double.Parse(lblPer1Num.Text), Double.Parse(lblPer2Num.Text),
    Double.Parse(lblTh1Num.Text) * Math.PI / 180, Double.Parse(lblTh2Num.Text) * Math.PI / 180);
                        return;
                    }

                }
                catch
                {
                    MessageBox.Show("输入不是整数，请重新输入！");
                    return;
                }
            }

        }

        void drawCayleyTree(int n,double x0,double y0,double leng,double th,double per1,
            double per2,double th1,double th2)
        {
            if (n == 0) return;

            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);

            drawLine(x0, y0, x1, y1);

            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1,per1,per2,th1,th2);
            drawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2,per1,per2,th1, th2);
            return;
        }

        void drawLine(double x0,double y0,double x1,double y1)
        {
            int index = cmbPen.SelectedIndex;
            List<Pen> colorList = new List<Pen>{ Pens.Red,Pens.Blue, Pens.Yellow, Pens.Green, Pens.Black, Pens.Pink};
            graphics.DrawLine(colorList[index], (int)x0, (int)y0, (int)x1, (int)y1);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbPen.SelectedIndex = 0;
        }
    }
}
