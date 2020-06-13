using BoilerPlate.Domain.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BoilerPlate.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            // Seed, if necessary
            if (!context.TestTables.Any())
            {
                context.TestTables.Add(new TestTable
                {
                    Name = "Test 1",
                    Remarks = "Rem 1",
                    Created = DateTime.Now,
                    CreatedBy = "user"
                }); ;

                await context.SaveChangesAsync();
            }
        }
    }
}
