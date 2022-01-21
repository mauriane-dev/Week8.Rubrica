using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week8.Rubrica.Core.InterfaceRepositories
{
    public interface IRepository <T>     where T : class
    {
        //operazioni Crud
        public List<T> GetAll();
        public T Add(T item);
        public T Update(T item);
        public bool Delete(T item);
    }
}
