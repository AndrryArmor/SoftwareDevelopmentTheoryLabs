using System.ComponentModel.DataAnnotations;

namespace OrderingGoods.DataAccessLayer.Entities
{
    public class GoodEntity
    {
        public int Id { get; set; }

        [Required]
        public GoodTypeEntity Type { get; set; }
        public int TypeId { get; set; }

        public string Model { get; set; }
        [Required]
        public string Manufacturer { get; set; }
        public string Description { get; set; }
    }
}