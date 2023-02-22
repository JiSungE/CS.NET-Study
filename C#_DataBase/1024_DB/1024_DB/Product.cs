using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1024_DB
{
    // data
    internal class Product
    {
        public string Pid { get; private set; }
        public string Name { get; private set; }
        public int Price { get; private set; }
        public string Description { get; private set; }

        public Product(string pid, string name, int price, string description)
        {
            Pid = pid;
            Name = name;
            Price = price;
            Description = description;
        }
    }
}
