using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class OrderItem
    {
        public int OrderItemID { set; get; }
        public string ItemName { set; get; }
        [Required]
        public double Price { set; get; }
        public int Amount { set; get; }

        public int OrderID { set; get; }
        public Order Order { set; get; }
        public OrderItem(int id,string name, double price, int amount)
        {
            OrderItemID = id;
            ItemName = name;
            Price = price;
            Amount = amount;
        }
        public OrderItem()
        {
            OrderItemID = 0;
            ItemName = "";
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
            return "Item:" + OrderItemID + "  "
                + "Price:" + Price + "  "
                + "Amount:" + Amount + "\n";
        }
        public override bool Equals(object obj)
        {
            return obj is OrderItem item &&
                   OrderItemID == item.OrderItemID;
        }

        public override int GetHashCode()
        {
            return 1170927957 + OrderItemID.GetHashCode();
        }
    }
    public class Order
    {
        public int OrderID { set; get; }
        [Required]
        public string Address { set; get; }
        [Required]
        public string Customer { set; get; }
        public double TotalPrice
        {
            get
            {
                double total = 0;
                foreach (OrderItem item in OrderItems)
                {
                    total += item.Price * item.Amount;
                }
                return total;
            }
        }
        public List<OrderItem> OrderItems { get; set; }

        public Order(int orderNum, string address, string customer, List<OrderItem> itemList)
        {
            OrderID = orderNum;
            Address = address;
            Customer = customer;
            this.OrderItems = itemList;
        }
        public Order()
        {
            OrderID = 0;
            Address = "";
            Customer = "";
            List<OrderItem> list = new List<OrderItem>();
            this.OrderItems = list;
        }
        public Order DeepClone()
        {
            List<OrderItem> orderItem = new List<OrderItem>();

            foreach (OrderItem orderItems in OrderItems)
            {
                orderItem.Add(orderItems.DeepClone());
            }
            Order order = new Order(OrderID, Address, Customer, orderItem);
            return order;
        }

        public override string ToString()
        {
            string s = "";
            foreach (OrderItem item in OrderItems)
            {
                s += item.ToString();
            }
            return "OrderNum:" + OrderID + "\n"
                + "Address:" + Address + "\n"
                + "Customer:" + Customer + "\n"
                + s + "Total Price:" + TotalPrice + "\n";
        }
        public override bool Equals(object obj)
        {
            return obj is Order order &&
                   OrderID == order.OrderID;
        }
        public override int GetHashCode()
        {
            var hashCode = -227992339;
            hashCode = hashCode * -1521134295 + OrderID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Address);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Customer);
            hashCode = hashCode * -1521134295 + TotalPrice.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<List<OrderItem>>.Default.GetHashCode(OrderItems);
            return hashCode;
        }
    }
    class OrderService
    {

        public bool AddOrder(Order m)
        {
            using (var context = new OrderContext())
            {
                var order = context.Orders
                    .SingleOrDefault(o => o.OrderID == m.OrderID);
                if (order != null) return false;
            }
            
            using (var context = new OrderContext())
            {
                var order = m.DeepClone();              
                context.Orders.Add(order);
                context.SaveChanges();             
            }           
            return true;
        }
        public bool DeleteOrder(int orderNum)
        {
            using (var context = new OrderContext())
            {
                var order = context.Orders
                    .SingleOrDefault(o => o.OrderID == orderNum);
                if (order != null)
                {
                    context.Orders.Remove(order);
                    context.SaveChanges();
                    return true;
                }
            }
            return false;
        }
        public void UpdateOrder(Order m)
        {
            using (var context = new OrderContext())
            {
                var order = context.Orders
                    .SingleOrDefault(o => o.OrderID == m.OrderID);
                if (order == null)
                {
                    AddOrder(m);                    
                }
                else
                {
                    order = m.DeepClone();
                    context.SaveChanges();
                }
            }
        }
        public Order FindOrder(int orderNum)
        {
            using (var context = new OrderContext())
            {
                var order = context.Orders
                    .SingleOrDefault(o => o.OrderID == orderNum);
                if (order != null) return order.DeepClone();
                else return new Order();
            }

        }
        public List<Order> FindOrder(bool flag, string Name)
        {
            using (var context = new OrderContext())
            {
                if (flag)
                {
                    var pointOrderItem = context.OrderItems.Where(w => w.ItemName==Name).OrderBy(w => w.OrderID);
                    List<Order> returnOrder = new List<Order>();
                    foreach(OrderItem item in pointOrderItem)
                    {
                        returnOrder.Add(FindOrder(item.OrderID).DeepClone());
                    }
                    return returnOrder;
                }
                else
                {
                    var pointOrder = context.Orders.Where(w => w.Customer == Name).OrderBy(w => w.OrderID);
                    List<Order> returnOrder = new List<Order>();
                    foreach (Order o in pointOrder)
                    {
                        returnOrder.Add(o.DeepClone());
                    }
                    return returnOrder;
                }
            }
        }
        public List<Order> SortOrder()
        {
            using (var context = new OrderContext())
            {
                var query = context.Orders.OrderBy(o => o.OrderID);
                return query.ToList();
            }
        }
        public List<Order> SortOrder(Func<Order, Order, int> func)
        {
            using (var context = new OrderContext())
            {
                var query = context.Orders.ToList();
                query.Sort((a, b) => func(a, b));
                return query;
            }
        }
    }
}
