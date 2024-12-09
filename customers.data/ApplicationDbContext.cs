using customers.domain;
using Microsoft.EntityFrameworkCore;

namespace customers.data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<PhoneNumber> PhoneNumber { get; set; }
        public DbSet<PhoneCode> PhoneCode { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Gender>()
                .Property(g => g.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
