using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsoleApp3;

namespace OrderManagement
{
    public partial class Form1 : Form
    {
        OrderService orderService;
        public Form1()
        {
            InitializeComponent();
            orderService=new OrderService();
            OrderItem item1 = new OrderItem(1,"apple", 5.2, 1);
            OrderItem item2 = new OrderItem(2,"orange", 3.3, 2);
            OrderItem item3 = new OrderItem(3,"potato", 4.5, 3);
            OrderItem item4 = new OrderItem(4,"banana", 2.1, 4);
            OrderItem item5 = new OrderItem(5,"tomato", 3.2, 5);
            List<OrderItem> itemList1 = new List<OrderItem>();
            itemList1.Add(item1);
            itemList1.Add(item3);
            itemList1.Add(item5);
            List<OrderItem> itemList2 = new List<OrderItem>();
            itemList2.Add(item2);
            itemList2.Add(item3);
            itemList2.Add(item4);
            List<OrderItem> itemList3 = new List<OrderItem>();
            itemList3.Add(item2);
            itemList3.Add(item4);
            itemList3.Add(item5);
            List<OrderItem> itemList4 = new List<OrderItem>();
            itemList4.Add(item1);
            itemList4.Add(item3);
            itemList4.Add(item4);
            Order order1 = new Order(2001, "wuhan", "ZhangSan", itemList1);
            Order order2 = new Order(2002, "beijing", "LiSi", itemList2);
            Order order3 = new Order(2003, "shanghai", "WangWu", itemList3);
            Order order4 = new Order(2004, "hangzhou", "ZhaoLiu", itemList4);
            orderService.AddOrder(order1);
            orderService.AddOrder(order2);
            orderService.AddOrder(order3);
            orderService.AddOrder(order4);
            List<Order> orderList = new List<Order>();
            using (var context = new OrderContext())
            {
                orderList = context.Orders.ToList();
            }
            bindingSourceOrder.DataSource = orderList;

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            FormAdd form2 = new FormAdd(new Order());
            if (form2.ShowDialog() == DialogResult.OK)
            {
                orderService.AddOrder(form2.CurrentOrder);
                QueryAll();
            }

        }

        private void QueryAll()
        {
            List<Order> orderList = new List<Order>();
            using (var context = new OrderContext())
            {
                orderList = context.Orders.ToList();
            }
            bindingSourceOrder.DataSource = orderList;
            bindingSourceOrder.ResetBindings(false);
        }

        private void BtnChange_Click(object sender, EventArgs e)
        {
            EditOrder();
        }

        private void EditOrder()
        {
            Order order = bindingSourceOrder.Current as Order;
            if (order == null)
            {
                MessageBox.Show("请选择一个订单进行修改");
                return;
            }
            FormAdd form2 = new FormAdd(order, true);
            if (form2.ShowDialog() == DialogResult.OK)
            {
                orderService.UpdateOrder(form2.CurrentOrder);
                QueryAll();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Order order = bindingSourceOrder.Current as Order;
            if (order == null)
            {
                MessageBox.Show("请选择一个订单进行删除");
                return;
            }
            orderService.DeleteOrder(order.OrderID);
            QueryAll();
        }


        private void BtnExport_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                String fileName = saveFileDialog1.FileName;
                orderService.Export(fileName);
            }
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                String fileName = openFileDialog1.FileName;
                orderService.Import(fileName);
                QueryAll();
            }
        }

        private void BtnFind_Click(object sender, EventArgs e)
        {
            List<Order> orderList = new List<Order>();
            using (var context = new OrderContext())
            {
                orderList = context.Orders.ToList();
            }
            switch (cmbAccordItem.SelectedIndex)
            {
                case 0://所有订单
                    bindingSourceOrder.DataSource = orderList;
                    break;
                case 1://根据ID查询
                    Order orderList1 = orderService.FindOrder(Int32.Parse(txtAccordDtail.Text));
                    bindingSourceOrder.DataSource = orderList1;
                    break;
                case 2://根据顾客名查询
                    IEnumerable<Order> orderList2 = orderService.FindOrder(false, txtAccordDtail.Text);
                    bindingSourceOrder.DataSource = orderList2;
                    break;
                case 3://根据商品物查询
                    IEnumerable<Order> orderList3 = orderService.FindOrder(true, txtAccordDtail.Text);
                    bindingSourceOrder.DataSource = orderList3;
                    break;

            }
            bindingSourceOrder.ResetBindings(true);
        }
    }
}
