using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApp3
{
    public class OrderItem
    {
        public int OrderItemID { set; get; }
        public string Name { set; get; }
        [Required]
        public double Price { set; get; }
        public int Amount { set; get; }

        public int OrderID { set; get; }
        public Order Order { set; get; }
        public OrderItem(int id, string name, double price, int amount)
        {
            OrderItemID = id;
            Name = name;
            Price = price;
            Amount = amount;
        }
        public OrderItem()
        {
            OrderItemID = 0;
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
                   OrderItemID == item.OrderItemID;
        }

        public override int GetHashCode()
        {
            return 1170927957 + OrderItemID.GetHashCode();
        }
    }
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None), Key]
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
                try
                {
                    using (var context = new OrderContext())
                    {
                        var orderItems = context.OrderItems.Where(item => item.OrderID == OrderID);

                        foreach (OrderItem item in orderItems)
                        {
                            total += item.Price * item.Amount;
                        }
                    }
                    return total;
                }
                catch(Exception e)
                {
                    return 0;
                }
            }
        }
        public List<OrderItem> OrderItems { get; set; }

        public Order(int orderNum, string address, string customer, List<OrderItem> itemList)
        {
            OrderID = orderNum;
            Address = address;
            Customer = customer;
            if (itemList != null) OrderItems = itemList;
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
        public bool AddItem(OrderItem m)
        {
            if (OrderItems.Contains(m))
                throw new ApplicationException($"添加错误：明细项已经存在!");
            OrderItems.Add(m);
            return true;
            
        }
        public void RemoveItem(OrderItem orderItem)
        {
            OrderItems.Remove(orderItem);
        }
        public override string ToString()
        {
            string s = "";
            using (var context = new OrderContext())
            {
                var orderItems = context.OrderItems.Where(item => item.OrderID == OrderID);

                foreach (OrderItem item in orderItems)
                {
                    s += item.ToString();
                }
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
    [Serializable]
    public class OrderService
    {
        public static List<Order> GetAllOrders()
        {
            try
            {
                using (var db = new OrderContext())
                {
                    if (AllOrders(db) == null)
                    {
                        
                        return new List<Order>();
                    }
                    else
                    {
                        return AllOrders(db).ToList();
                    }
                }
            }
            catch
            {
                return new List<Order>();
            }
            
        }
        private static IQueryable<Order> AllOrders(OrderContext context)
        {
            
            return context.Orders.Include("OrderItems");

        }
        public void AddOrder(Order m)
        {
            try
            {
                using (var context = new OrderContext())
                {
  
                    context.Orders.Add(m);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("addorder exception");
                //throw new ApplicationException($"添加错误: {e.Message}");
            }
           /* using (var context = new OrderContext())
            {
                var order = context.Orders
                    .SingleOrDefault(o => o.OrderID == m.OrderID);
                if (order != null) return false;
           
                var order1 = m.DeepClone();
                context.Orders.Add(order1);
                context.SaveChanges();
            }
            return true;*/
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
        public static void UpdateOrder(Order newOrder)
        {
            RemoveItems(newOrder.OrderID);
            using (var db = new OrderContext())
            {
                db.Entry(newOrder).State = EntityState.Modified;
                db.OrderItems.AddRange(newOrder.OrderItems);
                db.SaveChanges();
            }
        }
        private static void RemoveItems(int orderId)
        {
            using (var db = new OrderContext())
            {
                var oldItems = db.OrderItems.Where(item => item.OrderID== orderId);
                db.OrderItems.RemoveRange(oldItems);
                db.SaveChanges();
            }
        }
        public List<Order> FindOrder(int orderNum)
        {
            using (var db = new OrderContext())
            {
                var query = AllOrders(db)
                  .Where(o => o.OrderID == orderNum);
                return query.ToList();
            }          
        }
        public List<Order> FindOrder(bool flag, string Name)
        {
            using (var context = new OrderContext())
            {
                if (flag)
                {
                    using (var db = new OrderContext())
                    {
                        var query = AllOrders(db)
                          .Where(o => o.OrderItems.Count(i => i.Name == Name) > 0);
                        return query.ToList();
                    }
                    
                }
                else
                {
                    using (var db = new OrderContext())
                    {
                        var query = AllOrders(db)
                          .Where(o => o.Customer== Name);
                        return query.ToList();
                    }
                    
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
        public void Export(string fileName)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                List<Order> orderList = new List<Order>();
                using (var context = new OrderContext())
                {
                    orderList = context.Orders.ToList();
                }
                xmlSerializer.Serialize(fs, orderList);
            }
        }
        public void Import(string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                try
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
                    List<Order> orderList2 = (List<Order>)xmlSerializer.Deserialize(fs);
                    foreach (Order order in orderList2)
                    {
                        AddOrder(order);
                    }
                }
                catch (FileNotFoundException e)
                {
                    throw e;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
    }
}
