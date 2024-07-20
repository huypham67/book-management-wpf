using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Common
{
    public class SingletonBase<T> where T : class, new()
    {
        private static T _instance = null;
        private static readonly object _lock = new();
        public static T Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new T();
                    return _instance;
                }
            }
        }
    }
}
