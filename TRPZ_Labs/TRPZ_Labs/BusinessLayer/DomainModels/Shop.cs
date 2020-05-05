using System.Collections.Generic;

namespace OrderingGoods.BusinessLayer.DomainModels
{
    public class Shop
    {
        private readonly List<Item> items;

        public string Name { get; set; }

        public Shop(string name, IEnumerable<Item> items)
        {
            Name = name;
            this.items = new List<Item>(items);
        }

        public IEnumerable<Item> GetItems()
        {
            return items;
        }
    }
}