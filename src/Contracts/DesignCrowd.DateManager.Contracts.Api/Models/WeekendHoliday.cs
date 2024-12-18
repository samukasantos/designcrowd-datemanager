
namespace DesignCrowd.DateManager.Contracts.Api.Models;

public class WeekendHoliday(int month, int day) : IPublicHolidayCheck
{
    public int Month { get; } = month;
    public int Day { get; } = day;

    public bool IsHoliday(DateTime currentDate)
    {
        if (currentDate.Month == Month && currentDate.Day == Day)
        {
            return currentDate.DayOfWeek != DayOfWeek.Saturday && currentDate.DayOfWeek != DayOfWeek.Sunday;
        }

        if (currentDate.Month != Month || currentDate.DayOfWeek != DayOfWeek.Monday)
        {
            return false;
        }

        var previousDay = currentDate.AddDays(-1);

        return previousDay.Month == Month && previousDay.Day == Day;
    }
}