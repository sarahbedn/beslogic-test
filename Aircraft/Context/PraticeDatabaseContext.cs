using Beslogic.Pratice.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Beslogic.Pratice.API.Context
{
    public class PraticeDatabaseContext : DbContext
    {
        public PraticeDatabaseContext(DbContextOptions options) : base(options) { }
        public virtual DbSet<Aircraft> Aircrafts { get; set; } = null!;

    }

    public class PraticeDatabaseContextFactory : IDesignTimeDbContextFactory<PraticeDatabaseContext>
    {
        public PraticeDatabaseContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PraticeDatabaseContext>();
            optionsBuilder.UseSqlServer($"Data Source=.;Initial Catalog=PraticeDatabase;Authentication=Active Directory Integrated;");
            return new PraticeDatabaseContext(optionsBuilder.Options);
        }
    }
}