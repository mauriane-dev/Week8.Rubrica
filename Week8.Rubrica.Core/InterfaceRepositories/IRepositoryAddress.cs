using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8.Rubrica.Core.Entities;

namespace Week8.Rubrica.Core.InterfaceRepositories
{
    public interface IRepositoryAddress : IRepository<Address>
    {
        public Address GetAddressById(int id);
    }
}
