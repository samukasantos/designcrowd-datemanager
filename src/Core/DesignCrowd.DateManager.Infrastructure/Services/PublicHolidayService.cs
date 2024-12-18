using DesignCrowd.DateManager.Contracts.Api.Models;
using DesignCrowd.DateManager.Domain.Enums;
using DesignCrowd.DateManager.Infrastructure.Services.Abstractions;

namespace DesignCrowd.DateManager.Infrastructure.Services;

public class PublicHolidayService : IPublicHolidayService
{
    private readonly SqlDbContext _dbContext;
    private readonly IList<IPublicHolidayCheck> _publicHolidayChecks;

    public PublicHolidayService(SqlDbContext dbContext)
    {
        _dbContext = dbContext;
        _publicHolidayChecks = LoadHolidayRulesFromDatabase();
    }

    private List<IPublicHolidayCheck> LoadHolidayRulesFromDatabase()
    {
        var holidays = _dbContext.PublicHolidays.ToList();
        var rules = new List<IPublicHolidayCheck>();

        foreach (var holiday in holidays)
        {
            switch (holiday.Type)
            {
                case PublicHolidayType.Fixed:
                    rules.Add(new FixedHoliday(holiday.Month, holiday.Day));
                    break;
                case PublicHolidayType.Weekend:
                    rules.Add(new WeekendHoliday(holiday.Month, holiday.Day));
                    break;
                case PublicHolidayType.Occurrence:
                    if (holiday is { DayOfWeek: not null, Occurrence: not null })
                    {
                        rules.Add(new OccurrenceHoliday(holiday.Month, holiday.DayOfWeek.Value, holiday.Occurrence.Value));
                    }
                    break;
                default:
                    throw new InvalidOperationException($"Unknown holiday type: {holiday.Type}");
            }
        }

        return rules;
    }

    public bool IsPublicHoliday(DateTime currentDate)
    {
        return _publicHolidayChecks.Any(check => check.IsHoliday(currentDate));
    }
}