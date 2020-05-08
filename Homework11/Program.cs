using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        
        static void Main(string[] args)
        {
            OrderItem item1 = new OrderItem(1,"apple", 5.2, 1);
            OrderItem item2 = new OrderItem(2,"orange", 3.3, 2);
            OrderItem item3 = new OrderItem(3,"potato", 4.5, 3);
            OrderItem item4 = new OrderItem(4,"banana", 2.1, 4);
            OrderItem item5 = new OrderItem(5,"tomato", 3.2, 5);
            List<OrderItem> itemList1 = new List<OrderItem>();
            itemList1.Add(item1);
            itemList1.Add(item5);
            List<OrderItem> itemList2 = new List<OrderItem>();
            itemList2.Add(item2);
            itemList2.Add(item3);
            List<OrderItem> itemList3 = new List<OrderItem>();
            itemList3.Add(item4);


            Order order1 = new Order(2001, "wuhan", "ZhangSan", itemList1);
            Order order2 = new Order(2002, "beijing", "LiSi", itemList2);
            Order order3 = new Order(2003, "shanghai", "WangWu", itemList3);

            OrderService test = new OrderService();
            test.AddOrder(order1);
            test.AddOrder(order3);
            test.AddOrder(order2);
            
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

            Order order = test.FindOrder(temp2);
            if (order.OrderID!=0)
            {
                Console.WriteLine($"Find the No.{temp2} order:\n");

                    Console.WriteLine(order);
            }
            else
            {
                Console.WriteLine("Failed to find, the order does not exist.\n");
            }
            Console.WriteLine("Please enter the customer's name of the order that you want to find:");
            s = Console.ReadLine();
            List<Order> orders;
            orders = test.FindOrder(false,s);
            if (orders.Count<Order>() != 0)
            {
                Console.WriteLine($"Find {s}'s order:\n");
                foreach (Order m in orders)
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
            orders = test.FindOrder(true, s);
            if (orders.Count<Order>() != 0)
            {
                Console.WriteLine($"Find the order that contain {s}:\n");
                foreach (Order m in orders)
                {
                    Console.WriteLine(m);
                }
            }
            else
            {
                Console.WriteLine($"No order contains {s}.\n");
            }
            var output=test.SortOrder();
            Console.WriteLine("Sort the order by orderID ascending:\n");
            foreach(Order o in output)
            {
                Console.WriteLine(o);
            }
            Console.WriteLine("\nPlease input any letter to continue.");
            Console.ReadKey();

            output=test.SortOrder(delegate (Order a, Order b) { return b.OrderID.CompareTo(a.OrderID); });
            Console.WriteLine("\nSort the order by orderID descending:\n");
            foreach (Order o in output)
            {
                Console.WriteLine(o);
            }
            Console.WriteLine("\nPlease input any letter to quit.");
            Console.ReadKey();
        }
    }
}
