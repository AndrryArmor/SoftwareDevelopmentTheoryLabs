using System.ComponentModel.DataAnnotations;

namespace OrderingGoods.Entities
{
    public class GoodTypeEntity
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}