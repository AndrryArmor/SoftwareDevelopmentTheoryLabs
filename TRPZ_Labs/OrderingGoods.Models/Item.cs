using System.Runtime.Serialization;

namespace OrderingGoods.Models
{
    public class Item
    {
        public int Id { get; set; }
        public Good Good { get; set; }
        public Shop Shop { get; set; }
        public double Price { get; set; }

        public Item() { }
        public Item(Good good, Shop shop, float price)
        {
            Good = good;
            Shop = shop;
            Price = price;
        }
    }
}