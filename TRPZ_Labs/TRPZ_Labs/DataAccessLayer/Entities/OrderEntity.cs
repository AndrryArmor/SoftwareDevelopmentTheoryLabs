using System;
using System.ComponentModel.DataAnnotations;

namespace OrderingGoods.DataAccessLayer.Entities
{
    public class OrderEntity
    {
        public int Id { get; set; }

        [Required]
        public ItemEntity Item { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int Term { get; set; }
    }
}
