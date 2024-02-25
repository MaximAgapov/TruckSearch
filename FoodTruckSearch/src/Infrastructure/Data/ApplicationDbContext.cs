using System.Reflection;
using FoodTruckSearch.Application.Common.Interfaces;
using FoodTruckSearch.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodTruckSearch.Infrastructure.Data;

public class ApplicationDbContext: DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}

    public DbSet<FoodFacilityEntity> FoodFacilityEntities => Set<FoodFacilityEntity>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
