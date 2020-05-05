using AutoMapper;
using OrderingGoods.BusinessLayer.DomainModels;
using OrderingGoods.DataAccessLayer;
using OrderingGoods.DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Linq;

namespace OrderingGoods.BusinessLayer
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

        public IEnumerable<Good> GetAllGoods()
        {
            return unitOfWork.GoodRepository.GetAll().Select(good => mapper.Map<GoodEntity, Good>(good));
        }
    }
}
