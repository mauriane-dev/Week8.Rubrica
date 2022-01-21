using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8.Rubrica.Core.Entities;
using Week8.Rubrica.Core.InterfaceRepositories;

namespace Week8.Rubrica.EntityFramework.RepositoryEF
{
    public class RepositoryAddressEF : IRepositoryAddress
    {
        public Address Add(Address item)
        {
            using (var ctx = new RubricaContext())
            {
                ctx.Indirizzi.Add(item);
                ctx.SaveChanges();
            }
            return item;
        }

        public bool Delete(Address item)
        {
            using (var ctx = new RubricaContext())
            {
                ctx.Indirizzi.Remove(item);
                ctx.SaveChanges();
            }
            return true;
        }

        public List<Address> GetAll()
        {
            using (var ctx = new RubricaContext())
            {
                return ctx.Indirizzi.Include(x => x.Contact).ToList();
            }
        }

        public Address GetAddressById(int id)
        {
            using (var ctx = new RubricaContext())
            {
                return ctx.Indirizzi.Include(x => x.Contact).FirstOrDefault(a => a.AddressId == id);
            }
        }

        public Address Update(Address item)
        {
            throw new NotImplementedException();
        }
    }
}
