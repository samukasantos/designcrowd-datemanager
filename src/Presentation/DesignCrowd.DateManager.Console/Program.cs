using DesignCrowd.DateManager.Contracts.Api.Models;
using DesignCrowd.DateManager.Contracts.Api.Queries;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DesignCrowd.DateManager.Console;

public class Program
{
    private static async Task Main()
    {
        var serviceProvider = new ServiceCollection()
            .AddDependencies()
            .BuildServiceProvider();

        await ServiceCollectionExtensions.SeedDatabase(serviceProvider);

        var mediator = serviceProvider.GetRequiredService<ISender>();

        var startDate = new DateTime(2023, 12, 23);
        var endDate = new DateTime(2024, 1, 3);

        // Weekdays
        var weekdaysQuery = new GetWeekdaysBetweenDatesQuery
        {
            FirstDate = startDate,
            SecondDate = endDate
        };

        var weekdays = await mediator.Send(weekdaysQuery);
        System.Console.WriteLine($"Weekdays between {startDate.ToShortDateString()} and {endDate.ToShortDateString()}: {weekdays}");

        // Business Days
        var businessDaysQuery = new GetBusinessDaysBetweenDatesQuery
        {
            FirstDate = startDate,
            SecondDate = endDate,
            PublicHolidays = []
        };

        var businessDays = await mediator.Send(businessDaysQuery);
        System.Console.WriteLine($"Business days (with holidays) between {startDate.ToShortDateString()} and {endDate.ToShortDateString()}: {businessDays}");
        System.Console.ReadKey();
    }
}