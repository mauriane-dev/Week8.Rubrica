using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8.Rubrica.Core.Entities;
using Week8.Rubrica.Core.InterfaceRepositories;

namespace Week8.Rubrica.EntityFramework.RepositoryEF
{
    public class RepositoryContactEF : IRepositoryContact
    {
        public Contact Add(Contact item)
        {
            using (var ctx = new RubricaContext())
            {
                ctx.Contatti.Add(item);
                ctx.SaveChanges();
            }
            return item;
        }

        public bool Delete(Contact item)
        {
            using (var ctx = new RubricaContext())
            {
                ctx.Contatti.Remove(item);
                ctx.SaveChanges();
            }

            return true;
        }

        public List<Contact> GetAll()
        {
            using (var ctx = new RubricaContext())
            {
                return ctx.Contatti.ToList();
            }
        }

        public Contact GetContactById(int id)
        {
            using (var ctx = new RubricaContext())
            {
                return ctx.Contatti.FirstOrDefault(c => c.Id == id);
            }
        }

        public Contact Update(Contact item)
        {
            throw new NotImplementedException();
        }
    }
}
