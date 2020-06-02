using AutoMapper;
using OrderingGoods.Models;
using OrderingGoods.DataAccessLayer;
using OrderingGoods.DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Linq;

namespace OrderingGoods.BusinessLayer.Services
{
    public class GoodTypeService : IGoodTypeService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GoodTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public IEnumerable<GoodType> GetAllGoodTypes()
        {
            return unitOfWork.GoodTypeRepository.GetAll()
                .Select(goodTypeEntity => mapper.Map<GoodType>(goodTypeEntity));
        }
    }
}
