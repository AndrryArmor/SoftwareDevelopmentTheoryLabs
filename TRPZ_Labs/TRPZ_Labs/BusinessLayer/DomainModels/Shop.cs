using System.Collections.Generic;

namespace OrderingGoods.BusinessLayer.DomainModels
{
    public class Shop
    {
        private readonly List<Item> items;

        public string Name { get; set; }

        public Shop(string name, List<Item> items)
        {
            Name = name;
            this.items = items;
        }

        public List<Item> GetItems()
        {
            return items;
        }
    }
}