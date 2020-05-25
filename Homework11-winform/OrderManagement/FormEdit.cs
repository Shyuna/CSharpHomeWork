using ConsoleApp3;
using System;
using System.Windows.Forms;


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

        private void Label1_Click(object sender, EventArgs e)
        {

        }
    }
}
