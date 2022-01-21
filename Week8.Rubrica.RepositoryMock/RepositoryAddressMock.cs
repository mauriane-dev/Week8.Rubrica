using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8.Rubrica.Core.Entities;
using Week8.Rubrica.Core.InterfaceRepositories;

namespace Week8.Rubrica.RepositoryMock
{
    public class RepositoryAddressMock : IRepositoryAddress
    {
        public static List<Address> indirizzi = new List<Address>();
        public Address Add(Address item)
        {
            if (indirizzi.Count() == 0)
            {
                item.AddressId = 1;
            }
            else
            {
                item.AddressId = indirizzi.Max(a => a.AddressId) + 1;
            }

            var contact = RepositoryContactMock.contatti.FirstOrDefault(c => c.Id == item.ContactId);
            item.Contact = contact;

            contact.Addresses.Add(item);

            indirizzi.Add(item);
            return item;
        }

        public bool Delete(Address item)
        {
            indirizzi.Remove(item);
            return true;
        }

        public Address GetAddressById(int id)
        {
            return GetAll().FirstOrDefault(a => a.ContactId == id);
        }

        public List<Address> GetAll()
        {
            return indirizzi.ToList();
        }

        public Address Update(Address item)
        {
            throw new NotImplementedException();
        }
    }
}
