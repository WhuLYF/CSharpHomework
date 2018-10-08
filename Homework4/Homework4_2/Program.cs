using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4_2
{
     static public class Order
    {
        static public string[] number = new string[10];
        static public string[] goodsName = new string[10];
        static public string[] customerName = new string[10];
    }
    public class OrderService
    {
        //添加订单
        public void addOrder(int idx,string insertNumber,string insertGoodsName,string insertCustomerName)
        {
           if (idx >= 0 && idx <= Order.number.Length)
            {
                Order.number[idx] = insertNumber;
                Order.goodsName[idx] = insertGoodsName;
                Order.customerName[idx] = insertCustomerName;
            }

 
    
        }
        //查询订单
        public string searchOrder(string s)
        {
            for (int i = 0; i < Order.number.Length; i++)
            {
                if ((Order.number[i] == s) || (Order.goodsName[i] == s) || (Order.customerName[i] == s))
                {
                   Console.WriteLine(s + " has been find in " + Order.number[i]);
                   return Order.number[i];
                }
            }

            Console.WriteLine("Can't find!!");
            return null;
        }
        //删除订单
        public void deleteOrder(int deleteNumber)
        {
            try
            {
                Order.number[deleteNumber] = null;
                Order.customerName[deleteNumber] = null;
                Order.goodsName[deleteNumber] = null;
            }
            catch
            {
                Console.WriteLine(" Wrong number!!");
            }
        }
        //修改订单
        public void reviseOrder(int i,string type,string s)
        {
            for(int j = 0; j < Order.number.Length; j++)
            {
                if (type == "number")
                {
                    Order.number[i] = s;
                }
                if (type == "goodsName")
                {
                    Order.goodsName[i] = s;
                }
                if (type == "customerName")
                {
                    Order.customerName[i] = s;
                }
            }           
        }
        //打印订单
        public void showOrder()
        {
            for(int i = 0; i < Order.number.Length; i++)
            {
                Console.WriteLine(Order.number[i] + "  " + Order.goodsName[i] + "  " + Order.customerName[i]);
            }
           
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            OrderService myTest = new OrderService();
            myTest.addOrder(1, "No.1524", "apple", "Alan");
            myTest.addOrder(3,"No.1845","orange","LiHua");
            myTest.deleteOrder(1);
            myTest.reviseOrder(3, "customerName", "Miles");
            myTest.searchOrder("Miles");
            myTest.showOrder();
            //异常测试
            myTest.searchOrder("Rita");
            myTest.deleteOrder(15);
        }
    }
}


