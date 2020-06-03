using System.ComponentModel.DataAnnotations;

namespace OrderingGoods.Entities
{
    public class ItemEntity
    {
        public int Id { get; set; }

        [Required]
        public GoodEntity Good { get; set; }
        public int GoodId { get; set; }

        [Required]
        public ShopEntity Shop { get; set; }
        public int ShopId { get; set; }

        [Required]
        public double Price { get; set; }
    }
}