
using DesignCrowd.DateManager.Infrastructure.Services.Abstractions;
using DesignCrowd.DateManager.Tests.Fixture;
using FluentAssertions;

namespace DesignCrowd.DateManager.Tests;

public class WeekdaysBetweenTwoDatesTests(BusinessDayCounterServiceFixture fixture)
    : IClassFixture<BusinessDayCounterServiceFixture>
{
    private readonly IBusinessDayCounterService _businessDayCounterService = fixture.BusinessDayCounterService;

    public static TheoryData<DateTime, DateTime, int> Dates =
        new()
        {
            { new DateTime(2013, 10, 7), new DateTime(2013, 10, 9),  1 },
            { new DateTime(2013, 10, 5), new DateTime(2013, 10, 14), 5 },
            { new DateTime(2013, 10, 7), new DateTime(2014, 1, 1),  61 },
            { new DateTime(2013, 10, 7), new DateTime(2013, 10, 5),  0 },

        };

    [Theory, MemberData(nameof(Dates))]
    public void When_Assign_Start_And_End_Date_Should_Return_Correct_Weekdays_Count(
        DateTime startDate,
        DateTime endDate,
        int daysExpected)
    {
        
        // Act
        var weekdays = _businessDayCounterService.WeekdaysBetweenTwoDates(startDate, endDate);

        // Assert
        weekdays.Should().Be(daysExpected);
    }

  
}