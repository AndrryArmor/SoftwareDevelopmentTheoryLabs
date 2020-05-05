using System;
using System.ComponentModel.DataAnnotations;

namespace OrderingGoods.DataAccessLayer.Entities
{
    public class OrderEntity
    {
        [Key]
        public int ID { get; set; }
        public ItemEntity Item { get; set; }
        public ShopEntity Shop { get; set; }
        public DateTime Date { get; set; }
        public int Term { get; set; }
    }
}
