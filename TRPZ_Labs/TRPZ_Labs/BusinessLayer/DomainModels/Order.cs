using System;
using System.Runtime.Serialization;

namespace OrderingGoods.BusinessLayer.DomainModels
{
    [DataContract]
    public class Order
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public Item Item { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public TimeSpan Term { get; set; }

        public Order(Item item, DateTime date, TimeSpan term)
        {
            ID = Math.Abs(date.GetHashCode() % 1000);
            Item = item;
            Date = date;
            Term = term;
        }
    }
}
