using System;
using System.ComponentModel.DataAnnotations;

namespace OrderingGoods.Entities
{
    public class OrderEntity
    {
        public int Id { get; set; }

        [Required]
        public ItemEntity Item { get; set; }
        public int ItemId { get; set; }

        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int Term { get; set; }
    }
}
