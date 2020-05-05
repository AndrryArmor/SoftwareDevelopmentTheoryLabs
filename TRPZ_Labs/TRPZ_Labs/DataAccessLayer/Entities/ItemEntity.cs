using System.ComponentModel.DataAnnotations;

namespace OrderingGoods.DataAccessLayer.Entities
{
    public class ItemEntity
    {
        [Key]
        public int ID {get; set;}
        public GoodEntity Good { get; set; }
        public double Price { get; set; }
    }
}