using System.Runtime.Serialization;

namespace GoodsOrdering
{
    [DataContract]
    public class Item
    {
        [DataMember]
        public Good Good { get; private set; }
        [DataMember]
        public string ShopName { get; private set; }
        [DataMember]
        public float Price { get; private set; }

        public Item(Good good, string shopName, float price)
        {
            Good = good;
            ShopName = shopName;
            Price = price;
        }
    }
}