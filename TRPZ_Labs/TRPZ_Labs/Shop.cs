using System.Collections.Generic;

namespace GoodsOrdering
{
    public class Shop
    {
        private readonly List<Item> Items;

        public string Name { get; private set; }

        public Shop(string name, List<Item> items)
        {
            Name = name;
            Items = items;
        }

        public List<Item> GetItems()
        {
            return Items;
        }
    }
}