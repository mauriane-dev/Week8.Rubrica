using System.Collections.Generic;
using Week8.Rubrica.Core.BusinessLayer;
using Week8.Rubrica.Core.Entities;
using Week8.Rubrica.EntityFramework.RepositoryEF;
using Xunit;

namespace Week8.Rubrica.Test
{
    public class RubricaTest
    {
        IBusinessLayer bl = new MainBusinessLayer(new RepositoryContactEF(), new RepositoryAddressEF());

        [Fact]
        public void AggiungiContatto()
        {
            //ARRANGE: predisposizione/prerequisiti del test
            Contact newContact = new Contact()
            {
                FirstName = "Antonio",
                LastName = "Boccalatte"
            };


            //ACT: chiamata alla funzionalità da testare

            bl.EliminaContatto(newContact.Id);

            StatoRichiesta sr = bl.AggiungiContatto(newContact);

            //ASSERT: valutazione del risultato atteso
            Assert.True(sr.IsOk == true);

        }

        [Fact]
        public void AggiungiIndirrizzo()
        {
            Address newAddress = new Address()
            {
                Tipology = "Residenza",
                Street = "Via Roma 9/10",
                City = "Montelungo",
                PostalCode = 50345,
                Province = "Arezzo",
                Country = "Italia",
                ContactId = 3
            };
            
            StatoRichiesta sr = bl.AggiungiIndirizzo(newAddress);

            Assert.True(sr.IsOk == true);
        }
    }
}