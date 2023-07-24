using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace Services
{ public class LazyServiceFactory
    {
        private readonly Dictionary<Type, Func<object>> _services = new Dictionary<Type, Func<object>>();

        public void Register<T>(Func<T> serviceFactory)
        {
            _services[typeof(T)] = () => serviceFactory();
        }

        public T GetService<T>() where T : class
        {
            return _services[typeof(T)]() as T;
        }

        public object GetService(Type serviceType)
        {
            return _services[serviceType]();
        }
    }

}
