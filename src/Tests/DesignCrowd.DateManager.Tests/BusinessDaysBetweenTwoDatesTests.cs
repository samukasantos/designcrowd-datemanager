using DesignCrowd.DateManager.Infrastructure.Services.Abstractions;
using DesignCrowd.DateManager.Tests.Fixture;
using FluentAssertions;
using NSubstitute;

namespace DesignCrowd.DateManager.Tests;

public class BusinessDaysBetweenTwoDatesTests(BusinessDayCounterServiceFixture fixture)
    : IClassFixture<BusinessDayCounterServiceFixture>
{
    private readonly IBusinessDayCounterService _businessDayCounterService = fixture.BusinessDayCounterService;
    private readonly IPublicHolidayService _publicHolidayService = fixture.PublicHolidayService;

    public static TheoryData<DateTime, DateTime, int> Dates =
        new()
        {
            { new DateTime(2013, 10, 7), new DateTime(2013, 10, 9),   1 },
            { new DateTime(2013, 12, 24), new DateTime(2013, 12, 27), 0 },
            { new DateTime(2013, 10, 7), new DateTime(2014, 1, 1),  59 },

        };

    [Theory, MemberData(nameof(Dates))]
    public void Should_Return_Correct_BusinessDays_Count_Excluding_Public_Holidays(
        DateTime startDate,
        DateTime endDate,
        int daysExpected)
    {
        // Arrange
        var publicHolidays = new List<DateTime>
        {
            new(2013, 12, 25), //Public holiday on 25th
            new(2013, 12, 26), //Public holiday on 26th
            new(2013, 1, 1)    //Public holiday on 1st

        }; 

        _publicHolidayService
            .IsPublicHoliday(Arg.Is<DateTime>(d => d == new DateTime(2024, 12, 24)))
            .Returns(true);

        // Act
        var businessDays = _businessDayCounterService.BusinessDaysBetweenTwoDates(startDate, endDate, publicHolidays);

        // Assert
        businessDays.Should().Be(daysExpected);
    }

    [Fact]
    public void Should_Call_IsPublicHoliday_For_Each_Weekday()
    {
        // Arrange
        var startDate = new DateTime(2024, 12, 20); // Friday
        var endDate = new DateTime(2024, 12, 27);   // Friday
        var publicHolidays = new List<DateTime>();

        // Act
        _businessDayCounterService.BusinessDaysBetweenTwoDates(startDate, endDate, publicHolidays);

        // Assert
        _publicHolidayService.Received(1).IsPublicHoliday(new DateTime(2024, 12, 23)); // Monday
        _publicHolidayService.Received(1).IsPublicHoliday(new DateTime(2024, 12, 24)); // Tuesday
        _publicHolidayService.Received(1).IsPublicHoliday(new DateTime(2024, 12, 26)); // Thursday
    }
}