using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework6
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Customer() { }

        public Customer(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public override string ToString()
        {
            return $"customerId:{Id}, CustomerName:{Name}";
        }

    }
}
