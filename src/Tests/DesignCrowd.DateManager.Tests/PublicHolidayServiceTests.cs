
using DesignCrowd.DateManager.Infrastructure.Services.Abstractions;
using DesignCrowd.DateManager.Tests.Fixture;
using FluentAssertions;
using NSubstitute;

namespace DesignCrowd.DateManager.Tests;

public class PublicHolidayServiceTests(BusinessDayCounterServiceFixture fixture)
    : IClassFixture<BusinessDayCounterServiceFixture>
{
    private readonly IPublicHolidayService _publicHolidayService = fixture.PublicHolidayService;

    [Fact]
    public void Should_Return_True_For_Public_Holiday()
    {
        // Arrange
        var holidayDate = new DateTime(2024, 12, 25);
        _publicHolidayService.IsPublicHoliday(holidayDate).Returns(true);

        // Act
        var isHoliday = _publicHolidayService.IsPublicHoliday(holidayDate);

        // Assert
        isHoliday.Should().BeTrue();
    }

    [Fact]
    public void Should_Return_False_For_NonHoliday()
    {
        // Arrange
        var nonHolidayDate = new DateTime(2024, 7, 1);
        _publicHolidayService.IsPublicHoliday(nonHolidayDate).Returns(false);

        // Act
        var isHoliday = _publicHolidayService.IsPublicHoliday(nonHolidayDate);

        // Assert
        isHoliday.Should().BeFalse();
    }
}