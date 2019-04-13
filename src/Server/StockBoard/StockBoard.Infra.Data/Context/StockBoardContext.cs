using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using StockBoard.Domain.Models;
using StockBoard.Infra.Data.Mappings;
using StockBoard.Infra.Data.SeedData;

namespace StockBoard.Infra.Data.Context
{
    public class StockBoardContext : DbContext
    {
        public StockBoardContext(DbContextOptions options) : base(options)
        {

        }
        private readonly IHostingEnvironment _env;

        public StockBoardContext(IHostingEnvironment env)
        {
            _env = env;
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Broker> Brokers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonMap());
            modelBuilder.ApplyConfiguration(new StockMap());
            modelBuilder.ApplyConfiguration(new BrokerMap());
            modelBuilder.ApplyConfiguration(new OrderMap());

            modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            // get the configuration from the app settings

            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder()
                    .SetBasePath(_env.ContentRootPath)
                    .AddJsonFile("appsettings.json")
                    .Build();

                // define the database to use
                optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            }
        }
    }
}
