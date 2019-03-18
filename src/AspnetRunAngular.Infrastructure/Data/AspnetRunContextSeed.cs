using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace AspnetRunAngular.Infrastructure.Data
{
    public class AspnetRunContextSeed
    {
        public static async Task SeedAsync(AspnetRunContext dbContext, ILoggerFactory loggerFactory)
        {
            dbContext.Database.EnsureCreated();

            await SeedProductsAsync(dbContext);
        }

        private static async Task SeedProductsAsync(AspnetRunContext dbContext)
        {
            //if (!dbContext.Cities.Any())
            //{
            //    var cities = new List<City>
            //    {
            //        new City { Name = "İstanbul - Anadolu" },
            //        new City { Name = "İstanbul - Avrupa" },
            //        new City { Name = "Ankara" },
            //        new City { Name = "İzmir" },
            //        new City { Name = "Bursa" },
            //        new City { Name = "Konya" },
            //        new City { Name = "Kutahya" }
            //    };

            //    expertiseContext.Cities.AddRange(cities);

            //    await expertiseContext.SaveChangesAsync();
            //}
        }
    }
}
