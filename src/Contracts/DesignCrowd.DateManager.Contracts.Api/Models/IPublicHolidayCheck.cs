

namespace DesignCrowd.DateManager.Contracts.Api.Models;

public interface IPublicHolidayCheck
{
    bool IsHoliday(DateTime currentDate);
}