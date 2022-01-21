using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8.Rubrica.Core.BusinessLayer;
using Week8.Rubrica.Core.Entities;
using Week8.Rubrica.EntityFramework.RepositoryEF;

namespace Week8.Rubrica
{
    public class Menu
    {
        private static readonly IBusinessLayer bl = new MainBusinessLayer(new RepositoryContactEF(), new RepositoryAddressEF());
        //private static readonly IBusinessLayer bl = new MainBusinessLayer(new RepositoryContactMock(), new RepositoryAddressMock(), new RepositoryLezioniADO());
        public static void Start()
        {
            Console.WriteLine("Benvenuto al Master!");

            bool exit = true;

            while (exit)
            {
                int scelta = SchermoMenu();
                exit = AnalizzaScelta(scelta);
            }

        }

        #region Menu
        private static int SchermoMenu()
        {
            Console.WriteLine("******************Menu*********************");
            //Funzionalità Contatti
            Console.WriteLine("\nFunzionalità Contatti");
            Console.WriteLine("1. Visualizza Contatti");
            Console.WriteLine("2. Inserire un nuovo Contatto");
            Console.WriteLine("3. Elimina un Contatto");
            //Funzionalità Indirizzi
            Console.WriteLine("\nFunzionalità Indirizzi");
            Console.WriteLine("4. Visualizza l'elenco completo degli indirizzi");
            Console.WriteLine("5. Inserimento nuovo Indirizzo");

            Console.WriteLine("\n0. Exit");
            Console.WriteLine("********************************************");

            int scelta = GetNumber("la tua scelta");

            return scelta;
        }

        private static bool AnalizzaScelta(int scelta)
        {
            switch (scelta)
            {
                case 1:
                    VisualizzaContatti();
                    break;
                case 2:
                    InserisciContatto();
                    break;
                case 3:
                    EliminaContatto();
                    break;
                case 4:
                    VisualizzaIndirizzi();
                    break;
                case 5:
                    InserisciIndirizzo();
                    break;               
                case 0:
                    return false;
                    Console.WriteLine("Arrivederci!");

                default:
                    Console.WriteLine("Scelta non valida. Riprova");
                    break;
            }

            return true;
        }

        #endregion

        #region Contatti
        private static void EliminaContatto()
        {
            Console.WriteLine("Ecco l'elenco dei contatti disponibili");
            VisualizzaContatti();

            Console.WriteLine("Quale contatto vuoi eliminare? ");
            int id = GetNumber("l'id da eliminare");
            StatoRichiesta e = bl.EliminaContatto(id);
            Console.WriteLine(e.Messaggio);
        }

        private static void InserisciContatto()
        {
            //chiedo all'utente i dati per "creare" il nuovoContatto
            string nome = GetInfo("il nome del nuovo contatto");
            string cognome = GetInfo("il cognome del nuovo contatto");

            Contact newContact = new Contact();
            newContact.FirstName = nome;
            newContact.LastName = cognome;

            StatoRichiesta sr = bl.AggiungiContatto(newContact);
            Console.WriteLine(sr.Messaggio);
        }

        private static void VisualizzaContatti()
        {
            List<Contact> contatti = bl.GetAllContatti();

            if (contatti.Count == 0)
            {
                Console.WriteLine("Lista vuota");
            }
            else
            {
                foreach (var item in contatti)
                {
                    Console.WriteLine(item);
                }
            }
        }

        #endregion

        #region Indirizzi

        private static void InserisciIndirizzo()
        {
            //chiedo all'utente i dati per "creare" un nuovoIndirizzo
            Console.WriteLine("Che tipologia di indirizzo vuoi inserire? Domicilio o Residenza");
            string tipologia = GetInfo("la tipologia");
            string via = GetInfo("una nuova via");
            string città = GetInfo("una nuova città");
            int cap = GetNumber("il CAP");
            string provincia = GetInfo("la provincia");
            string nazione = GetInfo("il paese");
            int idContatto = GetNumber("l'id del contatto associato a questo indirizzo");

            Address newAddress = new Address();

            if(tipologia.Equals("Domicilio") || tipologia.Equals("Residenza"))
            {
                newAddress.Tipology = tipologia;
                newAddress.Street = via;
                newAddress.City = città;
                newAddress.PostalCode = cap;
                newAddress.Province = provincia;
                newAddress.Country = nazione;
                newAddress.ContactId = idContatto;

                StatoRichiesta sr = bl.AggiungiIndirizzo(newAddress);
                Console.WriteLine(sr.Messaggio);
            }
            else
            {
                Console.WriteLine("Tipologia non esistente. Scegli tra Domicilio o Residenza");
            }
                     
        }

        private static void VisualizzaIndirizzi()
        {
            List<Address> indirizzi = bl.GetAllIndirizzi();

            if (indirizzi.Count == 0)
            {
                Console.WriteLine("Lista vuota");
            }
            else
            {
                foreach (var item in indirizzi)
                {
                    Console.WriteLine(item);
                }
            }
        }

        #endregion


        #region Metodi per recuperare l'input utente
        private static string GetInfo(string message)
        {
            string info;
            do
            {
                Console.WriteLine($"Inserisci {message}: ");
                info = Console.ReadLine();

            } while (string.IsNullOrEmpty(info));

            return info;
        }

        private static int GetNumber(string message)
        {
            int numero;

            do
            {
                Console.WriteLine($"Inserire {message}: ");
            } while (!Int32.TryParse(Console.ReadLine(), out numero));

            return numero;
        }

        #endregion
    }
}
