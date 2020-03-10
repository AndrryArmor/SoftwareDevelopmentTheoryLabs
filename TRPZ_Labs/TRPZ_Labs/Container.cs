using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsOrdering
{
    public class Container
    {
        private readonly Dictionary<Type, Type> registeredObjects;

        public Container()
        {
            registeredObjects = new Dictionary<Type, Type>();
        }

        public dynamic Resolve<TKey>()
        {
            return Activator.CreateInstance(registeredObjects[typeof(TKey)]);
        }

        public void Register<TKey, TConcrete>() where TConcrete : TKey
        {
            registeredObjects[typeof(TKey)] = typeof(TConcrete);
        }
    }
}
