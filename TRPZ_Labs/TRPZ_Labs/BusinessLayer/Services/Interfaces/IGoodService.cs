using OrderingGoods.BusinessLayer.DomainModels;
using System.Collections.Generic;

namespace OrderingGoods.BusinessLayer.Services
{
    public interface IGoodService
    {
        IEnumerable<string> GetAllGoodNames();
    }
}
