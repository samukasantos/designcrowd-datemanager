using Microsoft.EntityFrameworkCore;
using DesignCrowd.DateManager.Infrastructure.Services;
using DesignCrowd.DateManager.Infrastructure.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using DesignCrowd.DateManager.Domain.Entities;
using DesignCrowd.DateManager.Domain.Enums;

namespace DesignCrowd.DateManager.Console;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDependencies(this IServiceCollection services)
    {
        services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining<Program>());

        services.AddDbContext<SqlDbContext>(options =>
            options.UseInMemoryDatabase("DateManagerDB"));

        services.AddSingleton<IPublicHolidayService, PublicHolidayService>();

        services.AddSingleton<IBusinessDayCounterService, BusinessDayCounterService>();

        return services;
    }

    public static async Task SeedDatabase(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<SqlDbContext>();

        if (!dbContext.PublicHolidays.Any())
        {
            dbContext.PublicHolidays.AddRange(
                new PublicHoliday { Type = PublicHolidayType.Fixed, Month = 12, Day = 25 },  // Christmas
                new PublicHoliday { Type = PublicHolidayType.Fixed, Month = 12, Day = 26 },  // Boxing Day
                new PublicHoliday { Type = PublicHolidayType.Weekend, Month = 1, Day = 1 },  // New Year's Day
                new PublicHoliday { Type = PublicHolidayType.Occurrence, Month = 6, DayOfWeek = DayOfWeek.Monday, Occurrence = 2 } // Queen's Birthday
            );

            await dbContext.SaveChangesAsync();
        }
    }
}