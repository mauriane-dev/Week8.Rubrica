using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8.Rubrica.Core.Entities;

namespace Week8.Rubrica.Core.BusinessLayer
{
    public interface IBusinessLayer
    {
        #region Funzionalità Contatti
        public List<Contact> GetAllContatti();
        public StatoRichiesta AggiungiContatto(Contact newContact);
        public StatoRichiesta EliminaContatto(int idContatto);
        //public bool EsisteCorso(string codice);
        #endregion

        #region Funzionalità Indirizzi
        public List<Address> GetAllIndirizzi();
        public StatoRichiesta AggiungiIndirizzo(Address newAddress);
        public List<Address> GetIndirizzoByIdContatto(int idContatto);

        #endregion
    }
}
