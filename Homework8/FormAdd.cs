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
    public partial class FormAdd : Form
    {
        public Order CurrentOrder { get; set; }

        public FormAdd()
        {
            InitializeComponent();

        }

        public FormAdd(Order order, bool editMode = false) : this()
        {
            CurrentOrder = order;
            orderBindingSource.DataSource = CurrentOrder;
            txtID.Enabled = !editMode;
            if (!editMode)
            {
                CurrentOrder.Customer = txtCuName.Text ;
                CurrentOrder.Address = txtAddr.Text;
            }
        }

        private void BtnAddItem_Click(object sender, EventArgs e)
        {
            FormEdit formEdit = new FormEdit(new OrderItem());
            try
            {
                if (formEdit.ShowDialog() == DialogResult.OK)
                {
                    CurrentOrder.AddItem(formEdit.orderItem);
                    ItembindingSource1.ResetBindings(false);
                }
            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.Message);
            }
        }

        private void BtnModifyItem_Click(object sender, EventArgs e)
        {
            OrderItem orderItem = ItembindingSource1.Current as OrderItem;
            if (orderItem == null)
            {
                MessageBox.Show("请选择一个订单项进行修改");
                return;
            }
            FormEdit formItemEdit = new FormEdit(orderItem);
            if (formItemEdit.ShowDialog() == DialogResult.OK)
            {
                ItembindingSource1.ResetBindings(false);
            }
        }

        private void BtnDeleteItem_Click(object sender, EventArgs e)
        {
            OrderItem orderItem = ItembindingSource1.Current as OrderItem;
            if (orderItem == null)
            {
                MessageBox.Show("请选择一个订单项进行删除");
                return;
            }
            CurrentOrder.RemoveItem(orderItem);
            ItembindingSource1.ResetBindings(false);
        }
    }
}
