using DesignCrowd.DateManager.Domain.Enums;

namespace DesignCrowd.DateManager.Domain.Entities;

public class PublicHoliday
{
    public int Id { get; set; }
    public PublicHolidayType Type { get; set; }
    public int Month { get; set; }
    public int Day { get; set; }
    public DayOfWeek? DayOfWeek { get; set; }
    public int? Occurrence { get; set; }
}