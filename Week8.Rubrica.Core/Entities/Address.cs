using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week8.Rubrica.Core.Entities
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? Tipology { get; set; }
        public int PostalCode { get; set; }
        public string? Province { get; set; }
        public string? Country { get; set; }

        //FK
        public int ContactId { get; set; }
        public Contact Contact { get; set; }

        public override string ToString()
        {
            return $"Indirizzo: {AddressId}\tTipologia: {Tipology}\tVia: {Street}\tcittà: {City}\t" +
                   $"CAP: {PostalCode}\tProvincia: {Province}\tNazione: {Country}\tContatto: {Contact}";
        }

    }
}
