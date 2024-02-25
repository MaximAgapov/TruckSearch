using System.Globalization;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CsvHelper;
using FoodTruckSearch.Domain.Entities;
using FoodTruckSearch.Infrastructure.Data.ImportDto;

namespace FoodTruckSearch.Infrastructure.Data
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedSampleDataAsync(ApplicationDbContext context, IMapper mapper)
        {
            
            using (var reader = new StreamReader("..\\Infrastructure\\Data.\\Mobile_Food_Facility_Permit.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var import = csv.GetRecords<FoodFacilityCsvDto>();

                var records = import.AsQueryable().ProjectTo<FoodFacilityEntity>(mapper.ConfigurationProvider);
                
                context.FoodFacilityEntities.AddRange(records);
                await context.SaveChangesAsync();
            }
            
           
        }
    }
}
