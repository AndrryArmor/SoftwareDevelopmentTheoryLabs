using System.Runtime.Serialization;

namespace OrderingGoods.Models
{
    public class GoodType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public GoodType() { }
        public GoodType(string name)
        {
            Name = name;
        }
    }
}