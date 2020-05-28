using OrderingGoods.DataAccessLayer.Entities;
using System.Collections.Generic;

namespace OrderingGoods.DataAccessLayer.Repository
{
    public interface IGoodRepository : IRepository<GoodEntity, int>
    {
    }
}
