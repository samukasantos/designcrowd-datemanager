
using DesignCrowd.DateManager.Infrastructure.Services.Abstractions;

namespace DesignCrowd.DateManager.Infrastructure.Services;

public class BusinessDayCounterService(IPublicHolidayService publicHolidayService) : IBusinessDayCounterService
{
    public int WeekdaysBetweenTwoDates(DateTime firstDate, DateTime secondDate)
    {
        if (secondDate <= firstDate)
        {
            return 0;
        }

        var weekdays = 0;
        var currentDate = firstDate.AddDays(1);

        while (currentDate < secondDate)
        {
            if (currentDate.DayOfWeek is >= DayOfWeek.Monday and <= DayOfWeek.Friday)
            {
                weekdays++;
            }
            currentDate = currentDate.AddDays(1);
        }

        return weekdays;
    }

    public int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IList<DateTime> publicHolidays)
    {
        if (secondDate <= firstDate)
        {
            return 0;
        }

        var businessDays = 0;
        var currentDate = firstDate.AddDays(1);

        while (currentDate < secondDate)
        {
            if (currentDate.DayOfWeek is >= DayOfWeek.Monday and <= DayOfWeek.Friday &&
                !publicHolidayService.IsPublicHoliday(currentDate) &&
                !publicHolidays.Contains(currentDate.Date))
            {
                businessDays++;
            }
            currentDate = currentDate.AddDays(1);
        }

        return businessDays;
    }
}