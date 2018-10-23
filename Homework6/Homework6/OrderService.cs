using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization; 

namespace Homework6
{
    [Serializable]
    public class OrderService
    {

        public Dictionary<int, Order> orderDict;

        public OrderService()
        {
            orderDict = new Dictionary<int, Order>();
        }

        //加入新的订单
        public void AddOrder(Order order)
        {
            if (orderDict.ContainsKey(order.Id))
                throw new Exception($"order-{order.Id} is already existed!");
            orderDict[order.Id] = order;
        }

        //删除订单 
        public void RemoveOrder(int orderId)
        {
            orderDict.Remove(orderId);
        }

        //所有订单
        public List<Order> QueryAllOrders()
        {
            return orderDict.Values.ToList();
        }

        //查询订单（按照订单号）
        public Order GetById(int orderId)
        {
            return orderDict[orderId];
        }

        //查询订单（按照商品名称）
        public List<Order> QueryByGoodsName(string goodsName)
        {
            List<Order> result = new List<Order>();
            foreach (Order order in orderDict.Values)
            {
                foreach (OrderDetail detail in order.Details)
                {
                    if (detail.Goods.Name == goodsName)
                    {
                        result.Add(order);
                        break;
                    }
                }
            }
            return result;
        }

        //查询订单（按照客户）
        public List<Order> QueryByCustomerName(string customerName)
        {
            var query = orderDict.Values
                .Where(order => order.Customer.Name == customerName);
            return query.ToList();
        }

        //修改订单
        public void UpdateCustomer(int orderId, Customer newCustomer)
        {
            if (orderDict.ContainsKey(orderId))
            {
                orderDict[orderId].Customer = newCustomer;
            }
            else
            {
                throw new Exception($"order-{orderId} is not existed!");
            }
        }

        //XML序列化
        static public List<Order> ordersForXml = new List<Order>();
        public void Export(string FileName)
        {
            XmlSerializer reader = new XmlSerializer(typeof(List<Order>));
            var fs = File.OpenWrite(FileName);
            reader.Serialize(fs, ordersForXml);
        }
        //显示XML文本
        public void Import(string FileName)
        {
            string xml = File.ReadAllText(FileName);
            Console.Write(xml);
        }
             
    }
}
