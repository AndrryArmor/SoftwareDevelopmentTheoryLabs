namespace OrderingGoods.DataAccessLayer.Entities
{
    public class GoodEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public string Description { get; set; }
    }
}