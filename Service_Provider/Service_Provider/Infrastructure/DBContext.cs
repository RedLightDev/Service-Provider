using Microsoft.EntityFrameworkCore;
using Service_Provider.Infrastructure.Entity;

namespace Service_Provider.Infrastructure
{
    public class ServiceDBContext: DbContext
    {
        public DbSet<Service> services { get; set; }

        public ServiceDBContext(DbContextOptions<ServiceDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Service>().ToTable(nameof(Service)).HasKey(x => x.Id);
        }
    }
}
