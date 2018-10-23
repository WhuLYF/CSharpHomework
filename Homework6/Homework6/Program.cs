using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework6
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Customer customer1 = new Customer(1, "Customer1");
                Customer customer2 = new Customer(2, "Customer2");

                Goods milk = new Goods(1, "Milk", 69.9);
                Goods eggs = new Goods(2, "eggs", 4.99);
                Goods apple = new Goods(3, "apple", 5.59);

                OrderDetail orderDetails1 = new OrderDetail(1, apple, 8);
                OrderDetail orderDetails2 = new OrderDetail(2, eggs, 2);
                OrderDetail orderDetails3 = new OrderDetail(3, milk, 1);

                Order order1 = new Order(1, customer1);
                Order order2 = new Order(2, customer2);
                Order order3 = new Order(3, customer2);
                order1.AddDetails(orderDetails1);
                order1.AddDetails(orderDetails2);
                order1.AddDetails(orderDetails3);
                //order1.AddOrderDetails(orderDetails3);
                order2.AddDetails(orderDetails2);
                order2.AddDetails(orderDetails3);
                order3.AddDetails(orderDetails3);

                OrderService os = new OrderService();
                os.AddOrder(order1);
                os.AddOrder(order2);
                os.AddOrder(order3);


                //查询所有订单
                Console.WriteLine("GetAllOrders");
                List<Order> orders = os.QueryAllOrders();
                foreach (Order od in orders)
                    Console.WriteLine(od.ToString());


                /*
                //用Linq查询订单
                List<Order> ordersForLinq = new List<Order>();
                ordersForLinq.Add(order1);
                ordersForLinq.Add(order2);
                ordersForLinq.Add(order3);

                //根据订单号查询
                Console.WriteLine("UseLinqToGetOrdersById:'2'");
                var result = from a in ordersForLinq where a.Id == 2 select a;
                foreach (var a in result)
                {
                    Console.WriteLine(a.ToString());
                }

                //根据客户名查询
                Console.WriteLine("UseLinqToGetOrdersByCustomerName:Customer1");
                var result2 = from b in ordersForLinq where b.Customer.Name == "Customer1" select b;
                foreach (var b in result2)
                {
                    Console.WriteLine(b.ToString());
                }

                //根据商品名查询
                Console.WriteLine("UseLinqToGetOrdersByGoodsName:Milk");
                var result3 = from c in ordersForLinq where c.Goods.Name == "Milk" select c;
                foreach (var c in result2)
                {
                    Console.WriteLine(c.ToString());
                }
                */
                



                //根据客户名查询
                Console.WriteLine("GetOrdersByCustomerName:'Customer2'");
                orders = os.QueryByCustomerName("Customer2");
                foreach (Order od in orders)
                    Console.WriteLine(od.ToString());

                Console.WriteLine("GetOrdersByGoodsName:'apple'");
                orders = os.QueryByGoodsName("apple");
                foreach (Order od in orders)
                    Console.WriteLine(od.ToString());

                Console.WriteLine("Remove order(id=2) and qurey all");
                os.RemoveOrder(2);
                os.QueryAllOrders().ForEach(
                    od => Console.WriteLine(od));

                
                //Xml序列化
                OrderService.ordersForXml.Add(order1);
                OrderService.ordersForXml.Add(order2);
                OrderService.ordersForXml.Add(order3);
                os.Export("D:/XmlForText.xml");
                //显示XML文本
                os.Import("F:/XmlForText.xml");









            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
