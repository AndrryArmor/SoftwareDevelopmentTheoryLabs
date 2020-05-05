using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace OrderingGoods.DataAccessLayer.Entities
{
    public class ShopEntity
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<ItemEntity> Items { get; set; }

        public ShopEntity()
        {
            Items = new Collection<ItemEntity>();
        }
    }
}