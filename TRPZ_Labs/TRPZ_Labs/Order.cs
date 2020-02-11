using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPZ_Labs
{
    public class Order
    {
        private static int id = 1;
        public int ID { get; private set; }
        public Item Item { get; private set; }
        public DateTime Date { get; private set; }
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
