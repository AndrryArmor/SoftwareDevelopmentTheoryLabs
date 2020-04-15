using AutoMapper;
using OrderingGoods.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return unitOfWork.GoodRepository.GetAll().Select(good => mapper.Map<DataAccessLayer.Entities.Good, Good>(good));
        }
    }
}
