
using DesignCrowd.DateManager.Infrastructure.Services;
using DesignCrowd.DateManager.Infrastructure.Services.Abstractions;
using NSubstitute;

namespace DesignCrowd.DateManager.Tests.Fixture;

public class BusinessDayCounterServiceFixture
{
    public IPublicHolidayService PublicHolidayService { get; private set; }
    public IBusinessDayCounterService BusinessDayCounterService { get; private set; }

    public BusinessDayCounterServiceFixture()
    {
        PublicHolidayService = Substitute.For<IPublicHolidayService>();

        BusinessDayCounterService = new BusinessDayCounterService(PublicHolidayService);
    }
}