using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Homework6.Program;

namespace OrderManagement
{
    public partial class FormEdit : Form
    {
        public OrderItem orderItem { get; set; }

        public FormEdit()
        {
            InitializeComponent();

        }


        public FormEdit(OrderItem orderItem) : this()
        {
            this.orderItem = orderItem;          
            this.itembindingSource1.DataSource = orderItem;

        }

    }
}
