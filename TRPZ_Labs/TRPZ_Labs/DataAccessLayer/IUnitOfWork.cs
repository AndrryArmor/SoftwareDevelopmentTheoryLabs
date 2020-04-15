using OrderingGoods.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingGoods.DataAccessLayer
{
    public interface IUnitOfWork
    {
        IRepository<Good> GoodRepository { get; }

        void Save();
    }
}
