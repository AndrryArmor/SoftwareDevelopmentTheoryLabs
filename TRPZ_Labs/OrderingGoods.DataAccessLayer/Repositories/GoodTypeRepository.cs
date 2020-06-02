using Microsoft.EntityFrameworkCore;
using OrderingGoods.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;

namespace OrderingGoods.DataAccessLayer.Repository
{
    public class GoodTypeRepository : Repository<GoodTypeEntity, int>, IGoodTypeRepository
    {
        public GoodTypeRepository(OrderingGoodsContext appContext) : base(appContext) { }
    }
}
