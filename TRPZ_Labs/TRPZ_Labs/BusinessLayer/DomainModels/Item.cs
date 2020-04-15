using System.Runtime.Serialization;

namespace OrderingGoods.BusinessLayer.DomainModels
{
    [DataContract]
    public class Item
    {
        [DataMember]
        public Good Good { get; set; }
        [DataMember]
        public string ShopName { get; set; }
        [DataMember]
        public float Price { get; set; }

        public Item(Good good, string shopName, float price)
        {
            Good = good;
            ShopName = shopName;
            Price = price;
        }
    }
}