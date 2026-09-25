using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_Db_Airplane_
{
    public class AirplaneDb : DbContext
    {
        public AirplaneDb()
        {
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"
                            Data Source = (localdb)\MSSQLLocalDB;
                            Initial Catalog = Airplane_PV_511;
                            Integrated Security = True;
                            Connect Timeout = 2;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Fluent API configuration
            modelBuilder.Entity<Client>().ToTable("Passangers");
            modelBuilder.Entity<Client>()
                .Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("FirstName");

            modelBuilder.Entity<Client>()
                .Property(a => a.Email)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Flight>().HasKey(a => a.Number);

            modelBuilder.Entity<Flight>()
                .Property(a => a.DepartureCity)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Flight>()
                .Property(a => a.ArrivalCity)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Account>()
                .Property(a => a.Login)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Account>()
                .Property(a => a.Password)
                .IsRequired()
                .HasMaxLength(50);

            // one to many (1 .... *)
            modelBuilder.Entity<Flight>()
                .HasOne(f => f.Airplane)
                .WithMany(f => f.Flights)
                .HasForeignKey(f => f.AirplaneId);

            // many to many (* .... *)
            modelBuilder.Entity<Flight>()
                .HasMany(f => f.Clients)
                .WithMany(f => f.Flights);

            // one to one
            modelBuilder.Entity<Account>()
                .HasOne(c => c.Client)
                .WithOne(c => c.Account)
                .HasForeignKey<Account>(c => c.ClientId);

            modelBuilder.SeedClients();
            modelBuilder.SeedAirplane();
            modelBuilder.SeedAccounts();
            modelBuilder.SeedFlights();
        }

        public DbSet<Flight> Flights { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Airplane> Airplanes { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
}
