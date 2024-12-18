using DesignCrowd.DateManager.Contracts.Shared.Cqrs;

namespace DesignCrowd.DateManager.Contracts.Api.Queries;

public class GetBusinessDaysBetweenDatesQuery : IQuery<int>
{
    public DateTime FirstDate { get; set; }

    public DateTime SecondDate { get; set; }

    public IList<DateTime> PublicHolidays { get; set; } = [];
}