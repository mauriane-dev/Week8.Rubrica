using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8.Rubrica.Core.Entities;
using Week8.Rubrica.Core.InterfaceRepositories;

namespace Week8.Rubrica.Core.BusinessLayer
{
    public class MainBusinessLayer : IBusinessLayer
    {
        private readonly IRepositoryContact contattiRepo;
        private readonly IRepositoryAddress indirizziRepo;
       
        public MainBusinessLayer(IRepositoryContact contatti, IRepositoryAddress indirizzi)
        {
            contattiRepo = contatti;
            indirizziRepo = indirizzi;

        }

        #region Funzionalità Contatti

        public List<Contact> GetAllContatti()
        {
            return contattiRepo.GetAll().ToList();
        }

        public StatoRichiesta AggiungiContatto(Contact newContact)
        {
            var contattoEsistente = GetAllContatti().FirstOrDefault(c => c.FirstName == newContact.FirstName && c.LastName == newContact.LastName);

            if (contattoEsistente != null)
            {
                return new StatoRichiesta { Messaggio = "Contatto già esistente", IsOk = false };
            }

            contattiRepo.Add(newContact);
            return new StatoRichiesta { Messaggio = "Docente aggiunto con successo", IsOk = true };
        }

        public StatoRichiesta EliminaContatto(int idContatto)
        {
            //controllo su input
            var contattoEsistente = contattiRepo.GetContactById(idContatto);

            if (contattoEsistente == null)
            {
                return new StatoRichiesta 
                { 
                    Messaggio = "Id non valido", 
                    IsOk = false 
                };
            }

            var contattoAssociatoAdIndirizzo = GetAllIndirizzi().FirstOrDefault(i => i.ContactId == idContatto);

            if (contattoAssociatoAdIndirizzo != null)
            {
                return new StatoRichiesta
                {
                    Messaggio = "Impossibile cancellare questo contatto perchè è associato ad un indirizzo",
                    IsOk = false
                };
            }

            contattiRepo.Delete(contattoEsistente);
            return new StatoRichiesta 
            { 
                Messaggio = "Contatto eliminato correttamente", 
                IsOk = true 
            };
        }

        #endregion

        #region Funzionalità Indirizzi
        public StatoRichiesta AggiungiIndirizzo(Address newAddress)
        {
            //Controllo sul contatto al quale associare l'indirizzo
            var indirroAssociatoAContatto = contattiRepo.GetContactById(newAddress.ContactId);

            if (indirroAssociatoAContatto == null)
            {
                return new StatoRichiesta { Messaggio = "Id contatto errato o inesistente", IsOk = false };
            }

            indirizziRepo.Add(newAddress);

            return new StatoRichiesta { Messaggio = "Indirizzo aggiunto correttamente", IsOk = true };
        }

        public List<Address> GetAllIndirizzi()
        {
            return indirizziRepo.GetAll().ToList();
        }

        public List<Address> GetIndirizzoByIdContatto(int idContatto)
        {
            var contatto = contattiRepo.GetAll().FirstOrDefault(c => c.Id == idContatto);

            if (contatto == null)
            {
                return null;
            }

            var indirizzi = new List<Address>();
            indirizzi = indirizziRepo.GetAll().Where(i => i.ContactId == contatto.Id).ToList();

            return indirizzi
                ;
        }

        #endregion

    }
}
