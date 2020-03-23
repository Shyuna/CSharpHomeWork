using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        class OrderItem
        {
            public string Name { set; get; }
            public double Price { set; get; }
            public int Amount { set; get; }
            public OrderItem(string name, double price,int amount)
            {
                Name = name;
                Price = price;
                Amount = amount;
            }
            public OrderItem()
            {
                Name = "";
                Price = 0;
                Amount = 0;
            }
            public override string ToString()
            {
                return "Item:"+Name+"  "
                    +"Price:"+Price+"  "
                    +"Amount:"+Amount+"\n";
            }
            public override bool Equals(object obj)
            {
                return obj is OrderItem item &&
                       Name == item.Name;
            }
            public override int GetHashCode()
            {
                var hashCode = -44027456;
                hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
                hashCode = hashCode * -1521134295 + Price.GetHashCode();
                return hashCode;
            }
        }
        class Order
        {
            public long OrderNum { set; get; }
            public string Address { set; get; }
            public string Customer { set; get; }
            public double TotalPrice
            {
                get
                {
                    double total=0;
                    foreach(OrderItem item in itemList)
                    {
                        total += item.Price * item.Amount;
                    }
                    return total;
                }
            }
            public List<OrderItem> itemList=new List<OrderItem>();
            public Order(long orderNum,string address,string customer,List<OrderItem> itemList){
                OrderNum = orderNum;
                Address = address;
                Customer = customer;
                this.itemList = itemList;
                }
            public Order()
            {
                OrderNum =0;
                Address ="";
                Customer = "";
                List<OrderItem> list = new List<OrderItem>();
                this.itemList = list;
            }
            public override string ToString()
            {
                string s = "";
                foreach(OrderItem item in itemList)
                {
                    s += item.ToString();
                }
                return "OrderNum:"+OrderNum+"\n"
                    +"Address:"+Address+"\n"
                    +"Customer:"+Customer+"\n"
                    +s+"Total Price:"+TotalPrice+"\n";
            }
            public override bool Equals(object obj)
            {
                return obj is Order order &&
                       OrderNum == order.OrderNum;
            }
            public override int GetHashCode()
            {
                var hashCode = -227992339;
                hashCode = hashCode * -1521134295 + OrderNum.GetHashCode();
                hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Address);
                hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Customer);
                hashCode = hashCode * -1521134295 + TotalPrice.GetHashCode();
                hashCode = hashCode * -1521134295 + EqualityComparer<List<OrderItem>>.Default.GetHashCode(itemList);
                return hashCode;
            }
        }
        class OrderService
        {
            public List<Order> orderList = new List<Order>();
            public bool AddOrder(Order m)
            {
                foreach(Order order in orderList)
                {
                    if (order.Equals(m))
                    {
                        return false;
                    }
                }
                orderList.Add(m);
                return true;
            }
            public bool DeleteOrder(int orderNum)
            {
                bool flag = false;
                for (int i = orderList.Count - 1; i >= 0; i--)
                {
                    if (orderList[i].OrderNum == orderNum)
                    {
                        orderList.Remove(orderList[i]);
                        flag = true;
                    }
                }
                return flag;
            }
            public bool UpdateOrder(int orderNum,Order m)
            {
                for (int i =0; i < orderList.Count; i++)
                {
                    if (orderList[i].OrderNum == orderNum)
                    {
                        orderList[i] = m;
                        return true;
                    }
                }
                return false;
            }
            public IEnumerable<Order> FindOrder(int orderNum)
            {
                var pointOrder = orderList.Where(w => w.OrderNum == orderNum);
                return pointOrder;
            }
            public IEnumerable<Order> FindOrder(bool flag,string Name)
            {
                if (flag)
                {
                    var pointOrder = orderList.Where(w => w.itemList.Exists(item=>item.Name==Name)).OrderBy(w => w.OrderNum);
                    return pointOrder;
                }
                else
                {
                    var pointOrder = orderList.Where(w => w.Customer==Name).OrderBy(w => w.OrderNum);
                    return pointOrder;
                }
            }
            public void SortOrder()
            {
                orderList.Sort(delegate (Order a, Order b) { return a.OrderNum.CompareTo(b.OrderNum); });
            }
            public void SortOrder(Func<Order, Order, int>func)
            {
                orderList.Sort((a,b)=>func(a,b));
            }
        }
        static void Main(string[] args)
        {
            OrderItem item1 = new OrderItem("apple", 5.2, 1);
            OrderItem item2 = new OrderItem("orange", 3.3, 2);
            OrderItem item3 = new OrderItem("potato", 4.5, 3);
            OrderItem item4 = new OrderItem("banana", 2.1, 4);
            OrderItem item5 = new OrderItem("tomato", 3.2, 5);
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
            OrderService test = new OrderService();
            test.AddOrder(order1);
            test.AddOrder(order4);
            test.AddOrder(order3);
            test.AddOrder(order2);
            Console.WriteLine("Now the orderlist is as below:\n");
            foreach (Order m in test.orderList)
            {
                Console.WriteLine(m);
            }
            Console.WriteLine("Please enter the number of the order that you want to delete:");
            string s;
            bool f = true;
            int temp=0;
            while (f)
            {
                s = Console.ReadLine();
                try
                {
                    temp = Int32.Parse(s);
                    f= false;
                }
                catch
                {
                    Console.WriteLine("Not a number, please input again:");
                }
            }

            bool flag=test.DeleteOrder(temp);
            if (flag)
            {
                Console.WriteLine($"Delete the No.{temp} order.\nNow the orderlist is as below:\n");
                foreach (Order m in test.orderList)
                {                   
                    Console.WriteLine(m);
                }
            }
            else
            {
                Console.WriteLine("Failed to delete, the order does not exist.\n");
                foreach (Order m in test.orderList)
                {                   
                    Console.WriteLine(m);
                }
            }
            Console.WriteLine("Please enter the number of the order that you want to find:");
            f = true;
            int temp2 = 0;
            while (f)
            {
                s = Console.ReadLine();
                try
                {
                    temp2 = Int32.Parse(s);
                    f = false;
                }
                catch
                {
                    Console.WriteLine("Not a number, please input again:");
                }
            }

            IEnumerable<Order> order = test.FindOrder(temp2);
            if (order.Count<Order>()!=0)
            {
                Console.WriteLine($"Find the No.{temp2} order:\n");
                foreach (Order m in order)
                {
                    Console.WriteLine(m);
                }
            }
            else
            {
                Console.WriteLine("Failed to find, the order does not exist.\n");
            }
            Console.WriteLine("Please enter the customer's name of the order that you want to find:");
            s = Console.ReadLine();
            order = test.FindOrder(false,s);
            if (order.Count<Order>() != 0)
            {
                Console.WriteLine($"Find {s}'s order:\n");
                foreach (Order m in order)
                {
                    Console.WriteLine(m);
                }
            }
            else
            {
                Console.WriteLine($"No {s}'s order here.\n");
            }
            Console.WriteLine("Please enter the product which is contained in the order you want to find:");
            s = Console.ReadLine();
            order = test.FindOrder(true, s);
            if (order.Count<Order>() != 0)
            {
                Console.WriteLine($"Find the order that contain {s}:\n");
                foreach (Order m in order)
                {
                    Console.WriteLine(m);
                }
            }
            else
            {
                Console.WriteLine($"No order contains {s}.\n");
            }
            test.SortOrder();
            Console.WriteLine("After sorted by ascend order, now the orderlist is as below:\n");
            foreach (Order m in test.orderList)
            {
                Console.WriteLine(m);
            }
            test.SortOrder(delegate (Order a, Order b) { return b.OrderNum.CompareTo(a.OrderNum); });
            Console.WriteLine("After sorted by decend order, now the orderlist is as below:");
            foreach (Order m in test.orderList)
            {
                Console.WriteLine(m);
            }
            Console.ReadLine();
        }
    }
}
