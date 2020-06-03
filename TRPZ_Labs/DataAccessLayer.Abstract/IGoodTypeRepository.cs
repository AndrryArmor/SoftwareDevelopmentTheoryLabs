using OrderingGoods.Entities;
using System.Collections.Generic;

namespace OrderingGoods.DataAccessLayer.Abstract
{
    public interface IGoodTypeRepository : IRepository<GoodTypeEntity, int>
    {
    }
}
