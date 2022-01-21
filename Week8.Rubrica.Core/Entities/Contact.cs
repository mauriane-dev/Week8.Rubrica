using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week8.Rubrica.Core.Entities
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public List<Address> Addresses { get; set; } = new List<Address>();

        public override string ToString()
        {
            return $"Id: {Id}\t{FirstName}\t{LastName}\t";
        }

    }

}
