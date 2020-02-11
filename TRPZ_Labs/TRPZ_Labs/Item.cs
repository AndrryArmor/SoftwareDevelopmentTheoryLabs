namespace TRPZ_Labs
{
    public class Item
    {
        public Good Good { get; private set; }
        public string ShopName { get; private set; }
        public float Price { get; private set; }

        public Item(Good good, string shopName, float price)
        {
            Good = good;
            ShopName = shopName;
            Price = price;
        }
    }
}