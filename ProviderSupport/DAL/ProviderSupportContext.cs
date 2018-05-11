using ProviderSupport.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ProviderSupport.DAL
{
    public class ProviderSupportContext : DbContext
    {
        // connection string to the database passed into the constructor
        public ProviderSupportContext() : base("ProviderSupportContext")
        {
            // added 5/7/18 per tutorial Reading Related Data https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/reading-related-data-with-the-entity-framework-in-an-asp-net-mvc-application
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Provider> Providers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<BillToOrg> BillToOrgs { get; set; }
        public DbSet<CounsPa> CounsPas { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<ServiceTypeEmpl> ServiceTypeEmpls { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}