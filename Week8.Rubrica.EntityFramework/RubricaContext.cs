using Microsoft.EntityFrameworkCore;
using Week8.Rubrica.Core.Entities;
using Week8.Rubrica.EntityFramework.Configurations;

namespace Week8.Rubrica.EntityFramework
{
    public class RubricaContext : DbContext
    {
        //Elenco i DbSet ovvero le tabelle/entità 
        public DbSet<Contact> Contatti { get; set; }
        public DbSet<Address> Indirizzi { get; set; }

        public RubricaContext ()
        {

        }

        public RubricaContext(DbContextOptions<RubricaContext> options) : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=RubricaManagement; Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Contact>(new ContactConfiguration());
            modelBuilder.ApplyConfiguration<Address>(new AddressConfiguration());
        }
    }
}