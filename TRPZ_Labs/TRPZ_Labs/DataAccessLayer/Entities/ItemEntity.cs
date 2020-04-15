namespace OrderingGoods.DataAccessLayer.Entities
{
    public class ItemEntity : BaseEntity
    {
        public int Good { get; set; }
        public int Shop { get; set; }
        public double Price { get; set; }
    }
}