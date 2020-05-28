using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace OrderApi.Models
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None), Key]
        public int OrderID { set; get; }
        public string Address { set; get; }
        public string Customer { set; get; }
        public List<OrderItem> ItemList { get; set; }
        public double TotalPrice
        {
            get
            {
                double total = 0;
                 foreach (OrderItem item in ItemList)
                        {
                            total += item.Price * item.Amount;
                        }
                    
                    return total;               
            }
        }

        public Order(int orderNum, string address, string customer, List<OrderItem> itemList)
        {
            OrderID = orderNum;
            Address = address;
            Customer = customer;
            if (itemList != null) ItemList = itemList;
        }
        public Order()
        {
            OrderID = 0;
            Address = "";
            Customer = "";
            List<OrderItem> list = new List<OrderItem>();
            this.ItemList = list;
        }
        public Order DeepClone()
        {
            List<OrderItem> orderItem = new List<OrderItem>();

            foreach (OrderItem orderItems in ItemList)
            {
                orderItem.Add(orderItems.DeepClone());
            }
            Order order = new Order(OrderID, Address, Customer, orderItem);
            return order;
        }
        public bool AddItem(OrderItem m)
        {
            if (ItemList.Contains(m))
                throw new ApplicationException($"添加错误：明细项已经存在!");
            ItemList.Add(m);
            return true;

        }
        public void RemoveItem(OrderItem orderItem)
        {
            ItemList.Remove(orderItem);
        }
        public override string ToString()
        {
            string s = "";
            
                foreach (OrderItem item in ItemList)
                {
                    s += item.ToString();
                }
            
            return "OrderNum:" + OrderID + "\n"
                + "Address:" + Address + "\n"
                + "Customer:" + Customer + "\n"
                + s + "Total Price:" + TotalPrice + "\n";
        }
    }

        public class OrderItem
        {
            [Key]
            public int ItemID { set; get; }
            public string Name { set; get; }
            public double Price { set; get; }
            public int Amount { set; get; }
        public int OrderID { set; get; }
        [ForeignKey("OrderID")]
        public Order order;


        public OrderItem(int id, string name, double price, int amount)
        {
            ItemID = id;
            Name = name;
            Price = price;
            Amount = amount;
        }
        public OrderItem()
        {
            ItemID = 0;
            Name = "";
            Price = 0;
            Amount = 0;
        }
        public OrderItem DeepClone()
        {
            OrderItem orderItem = (OrderItem)this.MemberwiseClone();

            return orderItem;
        }
        public override string ToString()
        {
            return "Item:" + Name + "  "
                + "Price:" + Price + "  "
                + "Amount:" + Amount + "\n";
        }

        public override bool Equals(object obj)
        {
            return obj is OrderItem item &&
                   ItemID == item.ItemID;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ItemID);
        }
    }
}
