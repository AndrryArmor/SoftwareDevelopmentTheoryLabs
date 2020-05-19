using System.Collections.Generic;

namespace OrderingGoods.BusinessLayer.DomainModels
{
    public class Shop
    {
        public string Name { get; set; }

        public Shop() { }
        public Shop(string name)
        {
            Name = name;
        }
    }
}