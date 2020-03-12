using System.Runtime.Serialization;

namespace OrderingGoods.BusinessLayer
{
    [DataContract]
    public class Good
    {
        [DataMember]
        public int ID { get; private set; }
        [DataMember]
        public string Name { get; private set; }
        [DataMember]
        public string Model { get; private set; }
        [DataMember]
        public string Manufacturer { get; private set; }
        [DataMember]
        public string Description { get; private set; }

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