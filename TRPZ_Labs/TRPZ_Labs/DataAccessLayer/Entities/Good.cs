using System.Runtime.Serialization;

namespace OrderingGoods.DataAccessLayer.Entities
{
    public class Good : BaseEntity
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public string Description { get; set; }
    }
}