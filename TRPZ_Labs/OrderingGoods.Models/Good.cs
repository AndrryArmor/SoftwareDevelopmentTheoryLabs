using System.Runtime.Serialization;

namespace OrderingGoods.Models
{
    public class Good
    {
        public int Id { get; set; }
        public GoodType Type { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public string Description { get; set; }

        public Good() { }
        public Good(GoodType type, string model, string manufacturer, string description)
        {
            Type = type;
            Model = model;
            Manufacturer = manufacturer;
            Description = description;
        }
    }
}