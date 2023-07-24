using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class LazyService<T>
    {
        private readonly Lazy<T> _instance;

        public LazyService()
        {
            _instance = new Lazy<T>(Activator.CreateInstance<T>);
        }

        public LazyService(Func<T> factory)
        {
            _instance = new Lazy<T>(factory);
        }

        public T Instance => _instance.Value;
    }
}
