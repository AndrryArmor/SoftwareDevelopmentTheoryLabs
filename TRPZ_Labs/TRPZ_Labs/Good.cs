namespace TRPZ_Labs
{
    public class Good
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Model { get; private set; }
        public string Manufacturer { get; private set; }
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