using OrderingGoods.Models;
using System.Collections.Generic;
 
namespace OrderingGoods.BusinessLayer.Abstract
{
    public interface IGoodTypeService
    {
        IEnumerable<GoodType> GetAllGoodTypes();
    }
}
