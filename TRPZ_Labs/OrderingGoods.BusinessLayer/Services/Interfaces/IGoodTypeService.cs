using OrderingGoods.Models;
using System.Collections.Generic;

namespace OrderingGoods.BusinessLayer.Services
{
    public interface IGoodTypeService
    {
        IEnumerable<GoodType> GetAllGoodTypes();
    }
}
