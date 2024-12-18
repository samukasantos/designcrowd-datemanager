using DesignCrowd.DateManager.Contracts.Api.Queries;
using DesignCrowd.DateManager.Infrastructure.Services.Abstractions;
using DesignCrowd.DateManager.Infrastructure.Services;
using MediatR;

namespace DesignCrowd.DateManager.Console.QueryHandlers;

public class BusinessDaysBetweenDatesQueryHandler(IBusinessDayCounterService businessDayCounterService) 
    : IRequestHandler<GetBusinessDaysBetweenDatesQuery, int>
{
    public Task<int> Handle(GetBusinessDaysBetweenDatesQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(businessDayCounterService.BusinessDaysBetweenTwoDates(request.FirstDate, request.SecondDate, request.PublicHolidays));
    }
}