using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GoodsOrdering
{
    [DataContract]
    public class Order
    {        
        private static int id = 1;
        [DataMember]
        public int ID { get; private set; }
        [DataMember]
        public Item Item { get; private set; }
        [DataMember]
        public DateTime Date { get; private set; }
        [DataMember]
        public TimeSpan Term { get; private set; }

        public Order(Item item, DateTime date, TimeSpan term)
        {
            ID = id++;
            Item = item;
            Date = date;
            Term = term;
        }
    }
}
