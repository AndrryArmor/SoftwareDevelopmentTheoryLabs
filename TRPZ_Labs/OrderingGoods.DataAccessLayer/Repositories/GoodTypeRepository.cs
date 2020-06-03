using Microsoft.EntityFrameworkCore;
using OrderingGoods.DataAccessLayer.Abstract;
using OrderingGoods.Entities;
using System;
using System.Collections.Generic;

namespace OrderingGoods.DataAccessLayer.Implementation.Repository
{
    public class GoodTypeRepository : Repository<GoodTypeEntity, int>, IGoodTypeRepository
    {
        public GoodTypeRepository(OrderingGoodsContext appContext) : base(appContext) { }
    }
}
