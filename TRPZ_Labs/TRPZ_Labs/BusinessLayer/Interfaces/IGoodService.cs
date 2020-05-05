using OrderingGoods.BusinessLayer.DomainModels;
using System.Collections.Generic;

namespace OrderingGoods.BusinessLayer
{
    public interface IGoodService
    {
        IEnumerable<Good> GetAllGoods();
    }
}
