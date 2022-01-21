using Week8.Rubrica.Core.Entities;
using Week8.Rubrica.Core.InterfaceRepositories;

namespace Week8.Rubrica.RepositoryMock
{
    public class RepositoryContactMock : IRepositoryContact
    {
        public static List<Contact> contatti = new List<Contact>()
        {
            new Contact{Id=1, FirstName="Mario", LastName="Rossi"},
            new Contact{Id=2, FirstName="Giuseppe", LastName="Bianchi"}
        };

        public Contact Add(Contact item)
        {
            if (contatti.Count() == 0)
            {
                item.Id = 1;
            }
            else
            {
                item.Id = contatti.Max(c => c.Id) + 1;
            }

            contatti.Add(item);

            return item;
        }

        public bool Delete(Contact item)
        {
            contatti.Remove(item);

            return true;
        }

        public List<Contact> GetAll()
        {
            return contatti.ToList();
        }

        public Contact GetContactById(int id)
        {
            return GetAll().FirstOrDefault(c => c.Id == id);
        }

        public Contact Update(Contact item)
        {
            throw new NotImplementedException();
        }
    }
}