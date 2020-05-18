using System.Collections.Generic;

namespace OrderingGoods.BusinessLayer.DomainModels
{
    public class Shop
    {
        public List<Item> Items { get; set; }
        public string Name { get; set; }

        public Shop() { }
        public Shop(string name, IEnumerable<Item> items)
        {
            Name = name;
            Items = new List<Item>(items);
        }
    }
}