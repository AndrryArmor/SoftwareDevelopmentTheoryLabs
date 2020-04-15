using System.Runtime.Serialization;

namespace OrderingGoods.DataAccessLayer.Entities
{
    public class Item : BaseEntity
    {
        public int Good { get; set; }
        public int Shop { get; set; }
        public double Price { get; set; }
    }
}