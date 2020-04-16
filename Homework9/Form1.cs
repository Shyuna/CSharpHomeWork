using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crawler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnCrawl_Click(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txtUrl.Text, @"http[s]?://"))
            {
                MessageBox.Show("输入的地址格式不正确，请重新输入！");
            }
            else
           {
                SimpleCrawler crawler = new SimpleCrawler(txtUrl.Text);
                crawler.startCrawl();
                detailBindingSource.DataSource = crawler;
                for (int i = 0; i < 100; i++)
                {                   
                    detailBindingSource.ResetBindings(false);
                    Thread.Sleep(50);
                }
            }                 
        }
    }
}
