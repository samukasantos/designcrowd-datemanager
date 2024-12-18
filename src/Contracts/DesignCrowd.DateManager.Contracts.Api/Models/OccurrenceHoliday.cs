
namespace DesignCrowd.DateManager.Contracts.Api.Models;

public class OccurrenceHoliday(int month, DayOfWeek dayOfWeek, int occurrence) : IPublicHolidayCheck
{
    public int Month { get; } = month;
    public DayOfWeek DayOfWeek { get; } = dayOfWeek;
    public int Occurrence { get; } = occurrence;

    public bool IsHoliday(DateTime curentDate)
    {
        if (curentDate.Month != Month || curentDate.DayOfWeek != DayOfWeek)
        {
            return false;
        }
            
        var occurrence = 0;
        var current = new DateTime(curentDate.Year, Month, 1);

        while (current <= curentDate)
        {
            if (current.DayOfWeek == DayOfWeek)
            {
                occurrence++;
            }

            current = current.AddDays(1);
        }

        return occurrence == Occurrence;
    }
}