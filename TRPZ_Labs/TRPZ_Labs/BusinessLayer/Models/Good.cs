using System.Runtime.Serialization;

namespace OrderingGoods.BusinessLayer
{
    [DataContract]
    public class Good
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Model { get; set; }
        [DataMember]
        public string Manufacturer { get; set; }
        [DataMember]
        public string Description { get; set; }

        public Good(int id, string name, string model, string manufacturer, string description)
        {
            ID = id;
            Name = name;
            Model = model;
            Manufacturer = manufacturer;
            Description = description;
        }
    }
}