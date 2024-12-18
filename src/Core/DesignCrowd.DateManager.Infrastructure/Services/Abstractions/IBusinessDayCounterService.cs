
namespace DesignCrowd.DateManager.Infrastructure.Services.Abstractions;

public interface IBusinessDayCounterService
{
    int WeekdaysBetweenTwoDates(DateTime firstDate, DateTime secondDate);
    int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IList<DateTime> publicHolidays);
}