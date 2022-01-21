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
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Indirizzi");
            builder.HasKey(a => a.AddressId);
            builder.Property(a => a.AddressId).HasColumnName("Id_Indirizzo").IsRequired();
            builder.Property(a => a.Street).HasColumnName("Via").HasMaxLength(50).IsRequired();
            builder.Property(a => a.City).HasColumnName("Città").HasMaxLength(50).IsRequired();
            builder.Property(a => a.Tipology).HasColumnName("Tipologia").IsRequired();

            builder.HasOne(a => a.Contact).WithMany(a => a.Addresses).HasForeignKey(a => a.ContactId).HasConstraintName("FK_IdContatto");
        }
    }
}
