using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonsProfileMVC.Services
{
   public interface IPersonRepo<T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Add(T t);

    }
}
