
namespace DesignCrowd.DateManager.Contracts.Api.Models;

public class FixedHoliday(int month, int day) : IPublicHolidayCheck
{
    public int Month { get; } = month;
    public int Day { get; } = day;

    public bool IsHoliday(DateTime currentDate)
    {
        return currentDate.Month == Month && currentDate.Day == Day;
    }
}