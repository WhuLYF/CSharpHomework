using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework6.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        [TestMethod()]
        public void AddOrderTest()
        {
            Customer customer1 = new Customer(1, "Customer1");
            Order order1 = new Order(1, customer1);
            OrderService osForTest = new OrderService();
            osForTest.AddOrder(order1);
            Assert.IsTrue(osForTest.orderDict.Count == 1);
        }

        [TestMethod()]
        public void RemoveOrderTest()
        {
            Customer customer1 = new Customer(1, "Customer1");
            Customer customer2 = new Customer(1, "Customer1");
            Order order1 = new Order(1, customer1);
            Order order2 = new Order(2, customer2);
            OrderService osForTest = new OrderService();
            osForTest.AddOrder(order1);
            osForTest.AddOrder(order2);
            osForTest.RemoveOrder(2);
            Assert.IsTrue(osForTest.orderDict.Count == 1);
        }

        [TestMethod()]
        public void QueryAllOrdersTest()
        {
            Customer customer1 = new Customer(1, "Customer1");
            Customer customer2 = new Customer(2, "Customer2");
            Order order1 = new Order(1, customer1);
            Order order2 = new Order(2, customer2);
            OrderService osForTest = new OrderService();
            osForTest.AddOrder(order1);
            osForTest.AddOrder(order2);
            List<Order> orders = osForTest.QueryAllOrders();
            /*Dictionary<int, Order> ordersForCompare = new Dictionary<int, Order>();
            ordersForCompare[1] = order1;
            ordersForCompare[2] = order2;*/
            List<Order> ordersForCompare = new List<Order>();
            ordersForCompare.Add(order1);
            ordersForCompare.Add(order2);
            Assert.AreEqual(orders.Count, ordersForCompare.Count);
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            Customer customer1 = new Customer(1, "Customer1");
            Customer customer2 = new Customer(2, "Customer2");
            Order order1 = new Order(1, customer1);
            Order order2 = new Order(2, customer2);
            OrderService osForTest = new OrderService();
            osForTest.AddOrder(order1);
            osForTest.AddOrder(order2);
            Order orderForTest=osForTest.GetById(2);
            Assert.IsTrue(orderForTest == order2);

        }

        [TestMethod()]
        public void QueryByGoodsNameTest()
        {
            Customer customer1 = new Customer(1, "Customer1");
            Customer customer2 = new Customer(2, "Customer2");
            Goods apple = new Goods(1, "apple", 5.59);
            Goods eggs = new Goods(2, "eggs", 4.99);
            

            OrderDetail orderDetails1 = new OrderDetail(1, apple, 8);
            OrderDetail orderDetails2 = new OrderDetail(2, eggs, 2);

            Order order1 = new Order(1, customer1);
            Order order2 = new Order(2, customer2);
            order1.AddDetails(orderDetails1);
            order1.AddDetails(orderDetails2);
            order2.AddDetails(orderDetails1);

            OrderService os = new OrderService();
            os.AddOrder(order1);
            os.AddOrder(order2);
            List<Order> orderListForTest1 = os.QueryByGoodsName("eggs");
            List<Order> orderListForTest2 = new List<Order>();
            orderListForTest2.Add(order1);

            Assert.IsTrue(orderListForTest1.All(orderListForTest2.Contains) && 
                orderListForTest1.Count == orderListForTest2.Count);

        }

        [TestMethod()]
        public void QueryByCustomerNameTest()
        {
            Customer customer1 = new Customer(1, "Customer1");
            Customer customer2 = new Customer(2, "Customer2");
            Goods apple = new Goods(1, "apple", 5.59);
            Goods eggs = new Goods(2, "eggs", 4.99);


            OrderDetail orderDetails1 = new OrderDetail(1, apple, 8);
            OrderDetail orderDetails2 = new OrderDetail(2, eggs, 2);

            Order order1 = new Order(1, customer1);
            Order order2 = new Order(2, customer2);
            order1.AddDetails(orderDetails1);
            order1.AddDetails(orderDetails2);
            order2.AddDetails(orderDetails1);

            OrderService os = new OrderService();
            os.AddOrder(order1);
            os.AddOrder(order2);
            List<Order> orderListForTest1 = os.QueryByCustomerName("Customer2");
            List<Order> orderListForTest2 = new List<Order>();
            orderListForTest2.Add(order2);

            Assert.IsTrue(orderListForTest1.All(orderListForTest2.Contains) &&
               orderListForTest1.Count == orderListForTest2.Count);

        }

        [TestMethod()]
        public void UpdateCustomerTest()
        {
            Customer customer1 = new Customer(1, "Customer1");
            Customer customer2 = new Customer(2, "Customer2");
            Order order1 = new Order(1, customer1);
            OrderService osForTest = new OrderService();
            osForTest.AddOrder(order1);
            osForTest.UpdateCustomer(1, customer2);
            Assert.IsTrue(order1.Customer == customer2);
        }
    }
}