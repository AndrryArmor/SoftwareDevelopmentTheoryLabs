using AutoMapper;
using OrderingGoods.Models;
using OrderingGoods.DataAccessLayer;
using OrderingGoods.DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Linq;

namespace OrderingGoods.BusinessLayer.Services
{
    public class GoodService : IGoodService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GoodService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public IEnumerable<string> GetAllGoodNames()
        {
            return unitOfWork.GoodRepository.GetAll()
                .Select(goodEntity =>
                {
                    var good = mapper.Map<Good>(goodEntity);
                    return good.Name;
                })
                .ToHashSet();
        }
    }
}
