

namespace DesignCrowd.DateManager.Infrastructure.Services.Abstractions;

public interface IPublicHolidayService
{
    bool IsPublicHoliday(DateTime currentDate);
}