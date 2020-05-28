using System.Collections.Generic;

namespace OrderingGoods.Models
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Shop() { }
        public Shop(string name)
        {
            Name = name;
        }
    }
}