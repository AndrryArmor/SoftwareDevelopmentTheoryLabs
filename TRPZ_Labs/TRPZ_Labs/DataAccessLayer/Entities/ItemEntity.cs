using System.ComponentModel.DataAnnotations;

namespace OrderingGoods.DataAccessLayer.Entities
{
    public class ItemEntity
    {
        public int Id { get; set; }

        [Required]
        public GoodEntity Good { get; set; }
        [Required]
        public ShopEntity Shop { get; set; }
        [Required]
        public double Price { get; set; }
    }
}