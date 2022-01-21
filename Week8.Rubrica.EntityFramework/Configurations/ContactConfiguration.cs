using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8.Rubrica.Core.Entities;

namespace Week8.Rubrica.EntityFramework.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contatti");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("Id_Contatto").IsRequired();
            builder.Property(c => c.FirstName).HasColumnName("Nome").HasMaxLength(100).IsRequired();
            builder.Property(c => c.LastName).HasColumnName("Cognome").HasMaxLength(100).IsRequired();

            //Relazione Contatto 1 -> Indirizzo n (uno a molti)
            builder.HasMany(c => c.Addresses).WithOne(a => a.Contact).HasForeignKey(c => c.ContactId);
        }

    }

}
