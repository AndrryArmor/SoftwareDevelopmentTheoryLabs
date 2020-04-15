using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingGoods.DataAccessLayer.Entities
{
    public class Order : BaseEntity
    {
        public int Item { get; set; }
        public DateTime Date { get; set; }
        public int Term { get; set; }
    }
}
