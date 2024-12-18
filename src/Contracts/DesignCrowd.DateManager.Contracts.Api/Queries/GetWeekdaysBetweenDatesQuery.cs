using DesignCrowd.DateManager.Contracts.Shared.Cqrs;

namespace DesignCrowd.DateManager.Contracts.Api.Queries;

public class GetWeekdaysBetweenDatesQuery : IQuery<int>
{
    public DateTime FirstDate { get; set; }

    public DateTime SecondDate { get; set; }
}