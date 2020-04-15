using System;

namespace OrderingGoods.DataAccessLayer.Entities
{
    public class OrderEntity : BaseEntity
    {
        public int Item { get; set; }
        public DateTime Date { get; set; }
        public int Term { get; set; }
    }
}
