using DesignCrowd.DateManager.Contracts.Api.Queries;
using DesignCrowd.DateManager.Infrastructure.Services;
using DesignCrowd.DateManager.Infrastructure.Services.Abstractions;
using MediatR;

namespace DesignCrowd.DateManager.Console.QueryHandlers;

public class WeekdaysBetweenDatesQueryHandler(IBusinessDayCounterService businessDayCounterService)
    : IRequestHandler<GetWeekdaysBetweenDatesQuery, int>
{
    public Task<int> Handle(GetWeekdaysBetweenDatesQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(businessDayCounterService.WeekdaysBetweenTwoDates(request.FirstDate, request.SecondDate));
    }
}