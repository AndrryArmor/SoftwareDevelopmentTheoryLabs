using AutoMapper;
using OrderingGoods.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingGoods.BusinessLayer
{
    public interface IGoodService
    {
        IEnumerable<Good> GetAllGoods();
    }
}
