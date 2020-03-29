using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Homework6.Program;

namespace Homework6.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        OrderService service = new OrderService();
        OrderItem apple = new OrderItem("apple", 5.2, 1);
        OrderItem orange = new OrderItem("orange", 3.3, 2);
        OrderItem potato = new OrderItem("potato", 4.5, 3);
        OrderItem banana = new OrderItem("banana", 2.1, 4);
        OrderItem tomato = new OrderItem("tomato", 3.2, 5);

        [TestInitialize()]
        public void init()
        {
            Order order1 = new Order(1, "Whuhan","Customer1", new List<OrderItem> { apple, potato, tomato });
            Order order2 = new Order(2, "Zhenzhou", "Customer2", new List<OrderItem> { potato, banana });
            Order order3 = new Order(3, "Fujian", "Customer2", new List<OrderItem> { apple, orange });
            service = new OrderService();
            service.AddOrder(order1);
            service.AddOrder(order3);
            service.AddOrder(order2);
        }

        [TestMethod()]
        public void AddOrderTest()
        {
            Order order4 = new Order(4, "Shandong", "Customer2", new List<OrderItem> { orange });
            service.AddOrder(order4);
            Assert.AreEqual(4, service.orderList.Count);
            CollectionAssert.Contains(service.orderList, order4);
        }

        [TestMethod()]
        public void AddOrderTest2()
        {
            Order order4 = new Order(3, "Suzhou", "Customer2", new List<OrderItem> { tomato });
            service.AddOrder(order4);
            Assert.AreEqual(3, service.orderList.Count);
            Order order6 = new Order(3, "Fujian", "Customer2", new List<OrderItem> { apple, orange });
            CollectionAssert.Contains(service.orderList, order6);
        }

        [TestMethod()]
        public void DeleteOrderTest()
        {
            service.DeleteOrder(3);
            Assert.AreEqual(2, service.orderList.Count);
            service.DeleteOrder(100);
            Assert.AreEqual(2, service.orderList.Count);
        }

        [TestMethod()]
        public void UpdateOrderTest()
        {
            Order order3 = new Order(3, "Nanjing", "Customer5", new List<OrderItem> { banana });
            service.UpdateOrder(order3);
            Assert.AreEqual(3, service.orderList.Count);
            for (int i = 0; i < service.orderList.Count; i++)
            {
                if (service.orderList[i].OrderNum.Equals(3))
                {
                    Order o = service.orderList[i];
                    Assert.AreEqual("Customer5", o.Customer);
                }
            }
        }
                      
        [TestMethod()]
        public void FindOrderTest1()
        {
            IEnumerable<Order> orderList2 = service.FindOrder(3);
            Order order1 = new Order(1, "Whuhan", "Customer1", new List<OrderItem> { apple, potato, tomato });
            Order order2 = new Order(2, "Zhenzhou", "Customer2", new List<OrderItem> { potato, banana });
            Order order3 = new Order(3, "Fujian", "Customer2", new List<OrderItem> { apple, orange });
            List<Order> orderlist = new List<Order> {order3 };
            Assert.AreEqual(1, orderList2.Count<Order>());
            int i = 0;
            foreach (Order order in orderList2)
            {
                Assert.AreEqual(order, orderlist[i]);
                i++;
            }
        }

        [TestMethod()]
        public void FindOrderTest2()
        {
            IEnumerable<Order> orderList2 = service.FindOrder(false,"Customer2");
            Order order1 = new Order(1, "Whuhan", "Customer1", new List<OrderItem> { apple, potato, tomato });
            Order order2 = new Order(2, "Zhenzhou", "Customer2", new List<OrderItem> { potato, banana });
            Order order3 = new Order(3, "Fujian", "Customer2", new List<OrderItem> { apple, orange });
            List<Order> orderlist = new List<Order> { order2,order3 };
            Assert.AreEqual(2, orderList2.Count<Order>());
            int i = 0;
            foreach (Order order in orderList2)
            {
                Assert.AreEqual(order, orderlist[i]);
                i++;
            }
        }

        [TestMethod()]
        public void FindOrderTest3()
        {
            IEnumerable<Order> orderList2 = service.FindOrder(true,"potato");
            Order order1 = new Order(1, "Whuhan", "Customer1", new List<OrderItem> { apple, potato, tomato });
            Order order2 = new Order(2, "Zhenzhou", "Customer2", new List<OrderItem> { potato, banana });
            Order order3 = new Order(3, "Fujian", "Customer2", new List<OrderItem> { apple, orange });
            List<Order> orderlist = new List<Order> { order1,order2 };
            Assert.AreEqual(2, orderList2.Count<Order>());
            int i = 0;
            foreach (Order order in orderList2)
            {
                Assert.AreEqual(order,orderlist[i]);
                i++;
            }
        }

        [TestMethod()]
        public void SortOrderTest1()
        {
            service.SortOrder();
            Order order1 = new Order(1, "Whuhan", "Customer1", new List<OrderItem> { apple, potato, tomato });
            Order order2 = new Order(2, "Zhenzhou", "Customer2", new List<OrderItem> { potato, banana });
            Order order3 = new Order(3, "Fujian", "Customer2", new List<OrderItem> { apple, orange });
            List<Order> orderlist = new List<Order> { order1, order2, order3 };
            Assert.AreEqual(3, service.orderList.Count<Order>());
            for (int i = 0; i < 3; i++)
                Assert.AreEqual(service.orderList[i], orderlist[i]);           
        }

        [TestMethod()]
        public void SortOrderTest2()
        {
            service.SortOrder(delegate (Order a, Order b) { return a.TotalPrice.CompareTo(b.TotalPrice); });
            Order order1 = new Order(1, "Whuhan", "Customer1", new List<OrderItem> { apple, potato, tomato });
            Order order2 = new Order(2, "Zhenzhou", "Customer2", new List<OrderItem> { potato, banana });
            Order order3 = new Order(3, "Fujian", "Customer2", new List<OrderItem> { apple, orange });
            List<Order> orderlist = new List<Order> { order3, order2, order1 };
            Assert.AreEqual(3, service.orderList.Count<Order>());
            for (int i = 0; i < 3; i++)
                Assert.AreEqual(service.orderList[i], orderlist[i]);
        }

        [TestMethod()]
        public void ExportTest()
        {
            String file = "temp.xml";
            service.Export(file);
            Assert.IsTrue(File.Exists(file));
            List<String> expectLines = File.ReadLines("expectedOrders.xml").ToList();
            List<String> outputLines = File.ReadLines(file).ToList();
            Assert.AreEqual(expectLines.Count, outputLines.Count);
            for (int i = 0; i < expectLines.Count; i++)
            {
                Assert.AreEqual(expectLines[i].Trim(), outputLines[i].Trim());
            }
        }

        [TestMethod()]
        public void ImportTest1()
        {
            OrderService os = new OrderService();
            os.Import("./expectedOrders.xml");
            Assert.AreEqual(3, os.orderList.Count);

            os.Import("./newOrders.xml");
            Assert.AreEqual(5, os.orderList.Count);
        }

        [TestMethod()]
        [ExpectedException(typeof(FileNotFoundException))]
        public void ImportTest2()
        {
            OrderService os = new OrderService();
            os.Import("./ordersNotExist.xml");
        }
    }
}