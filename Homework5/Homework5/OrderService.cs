using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework5
{
    class OrderService
    {

        private Dictionary<int, Order> orderDict;

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
        
        //查询所有订单
        public List<Order> QueryAllOrders()
        {
            return orderDict.Values.ToList();
        }

        //查询订单（按照订单号）
        public Order QueryById(int orderId)
        {
            //return orderDict[orderId];
            var query = orderDict.Where(a => orderId == a.Key);
            Order query2 = (Order)query;
            return query2;
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

    }
}
