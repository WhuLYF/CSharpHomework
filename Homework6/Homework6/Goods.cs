using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework6
{
    public class Goods
    {
        public Goods()
        {

        }
        public Goods(int id, string name, double value)
        {
            Id = id;
            Name = name;
            Price = value;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public override string ToString()
        {
            return $"Id:{Id}, Name:{Name}, Value:{Price}";
        }
    }
}
