using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework6
{
    [Serializable]
    public class Order
    {
        private List<OrderDetail> details = new List<OrderDetail>();
        public int Id;
        public Customer Customer;
        public Goods Goods;

        public Order()
        {

        }
        public Order(int orderId, Customer customer)
        {
            this.Id = orderId;
            this.Customer = customer;
        }

        public List<OrderDetail> Details
        {
            get => this.details;
        }

        public void AddDetails(OrderDetail orderDetail)
        {
            if (this.Details.Contains(orderDetail))
            {
                throw new Exception($"orderDetails-{orderDetail.Id}is already existed!");
            }
            details.Add(orderDetail);
        }

        public void RemoveDetails(uint orderDetailId)
        {
            details.RemoveAll(d => d.Id == orderDetailId);
        }

        public override string ToString()
        {
            string result = "================================================================================\n";
            result += $"orderId:{Id}, customer:({Customer})";
            details.ForEach(od => result += "\n\t" + od);
            result += "\n================================================================================";
            return result;

        }
    }
}