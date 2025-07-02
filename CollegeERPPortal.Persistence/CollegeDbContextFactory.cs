using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace CollegeERPPortal.Persistence.Context
{
    public class CollegeDbContextFactory : IDesignTimeDbContextFactory<CollegeDbContext>
    {
        public CollegeDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<CollegeDbContext>();
            optionsBuilder.UseOracle(configuration.GetConnectionString("DefaultConnection"));

            return new CollegeDbContext(optionsBuilder.Options);
        }
    }
}
