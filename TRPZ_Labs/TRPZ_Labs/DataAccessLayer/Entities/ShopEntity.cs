using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace OrderingGoods.DataAccessLayer.Entities
{
    public class ShopEntity
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}