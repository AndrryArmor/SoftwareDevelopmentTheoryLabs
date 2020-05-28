using AutoMapper;
using OrderingGoods.BusinessLayer.DomainModels;
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
        private readonly MappingService mappingService;

        public GoodService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            mappingService = new MappingService(unitOfWork);
        }

        public IEnumerable<string> GetAllGoodNames()
        {
            //IEnumerable<Good> goods = unitOfWork.GoodRepository.GetAll().Select(goodEntity => mapper.Map<Good>(goodEntity));
            IEnumerable<Good> goods = unitOfWork.GoodRepository.GetAll().Select(goodEntity => mappingService.Map(goodEntity));
            return goods.Select(good => good.Name).ToHashSet();
        }
    }
}
