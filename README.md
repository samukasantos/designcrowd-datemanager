
# Business Day Counter Application

## Overview
The **Business Day Counter Application** calculates the number of weekdays and business days between two dates. It considers public holidays and configurable rules for holiday calculations. The application follows a layered architecture with CQRS implemented using the Mediator design pattern.

## Solution Structure
The solution is structured as follows:

- **Contracts Layer**
- This layer defines the interfaces, data models, and query/command contracts for communication between layers.
  - **DesignCrowd.DateManager.Contracts.Api**:
    - Models: Define the structure for holiday rules and queries:
      - `FixedHoliday` Represents holidays on fixed calendar dates.
      - `IPublicHolidayCheck` Interface for checking public holidays.
      - `OccurrenceHoliday` Represents holidays based on nth occurrence of a weekday in a month.
      - `WeekendHoliday` Represents holidays adjusted for weekends.
    - Queries:
      - `GetBusinessDaysBetweenDatesQuery` Retrieves business days between two dates.
      - `GetWeekdaysBetweenDatesQuery` Retrieves weekdays between two dates.
  - **DesignCrowd.DateManager.Contracts.Shared.Cqrs**:
    - Interfaces:
      - `IQuery` interface for all query operations.

- **Core Layer**
- This layer contains the domain entities, enums, and infrastructure for core business logic.
  - **DesignCrowd.DateManager.Domain**:
    - Entities:
      - `PublicHoliday` Represents a public holiday with relevant metadata.
    - Enums:
      - `PublicHolidayType` Defines holiday types (e.g., FixedDate, Occurrence).
  - **DesignCrowd.DateManager.Infrastructure**:
    - Services:
      - `BusinessDayCounterService` Contains logic to calculate weekdays and business days.
      - `PublicHolidayService` Manages holiday rules and determines applicable holidays.
      - `SqlDbContext` EF Core database context for managing holiday data.
    - Abstractions:
      - `IBusinessDayCounterService` Interface for day counting services.
      - `IPublicHolidayService` Interface for public holiday services.

- **Presentation Layer**
  - **DesignCrowd.DateManager.Console**:
    - Console application for user interaction.
    - Dependency injection setup.

- **Tests Layer**
  - **DesignCrowd.DateManager.Tests**:
    - Unit tests for services and handlers.
    - Uses xUnit, FluentAssertions, and NSubstitute.

## Dependencies
- **MediatR** for CQRS pattern.
- **Entity Framework Core** for data persistence.
- **NSubstitute** for mocking dependencies in tests.
- **FluentAssertions** for test assertions.

## Key Features
1. **Weekday Count**: Calculates the number of weekdays between two dates.
2. **Business Day Count**: Calculates business days, excluding weekends and public holidays.
3. **Public Holiday Rules**:
   - Fixed date holidays (e.g., Christmas).
   - Weekend-adjusted holidays (e.g., New Year’s Day).
   - Nth occurrence holidays (e.g., Queen’s Birthday).
4. **CQRS Implementation**: Separation of queries and commands using MediatR.

## Usage
### Prerequisites
- [.NET SDK](https://dotnet.microsoft.com/) installed on your system.
- A database configured for Entity Framework Core (optional for advanced scenarios).

### Running the Application
1. Clone the repository:
   ```bash
   git clone https://github.com/your-repo/designcrowd-datemanager.git
   cd designcrowd-datemanager
   ```
2. Build the solution:
   ```bash
   dotnet build
   ```
3. Run the console application:
   ```bash
   dotnet run --project Presentation
   ```
## Public Holiday Configuration
Public holidays are managed in the database (or an alternative configuration like 3rd party APIs or json file). To add:
1. Implement the `IPublicHolidayCheck` interface if needed.
2. Seed public holidays using EF Core or manually.

## Unit Tests
### Run Tests
To run the tests:
```bash
dotnet test
```

### Test Coverage
- BusinessDaysBetweenTwoDatesTests, PublicHolidayServiceTests and WeekdaysBetweenTwoDatesTests.
- Mocked `IPublicHolidayService` for various scenarios.

## Extending the Application
1. **Add New Holiday Rules**:
   - Create a new class implementing from `IPublicHolidayCheck` interface.
   - Register the rule in the database or configuration.
2. **Enhance Queries**:
   - Create new query classes as needed.
   - Implement handlers using MediatR.

## Contributing
Contributions are welcome! Follow these steps:
1. Fork the repository.
2. Create a new branch for your feature or bug fix.
3. Submit a pull request.

## License
This project is licensed under the MIT License. See the `LICENSE` file for details.
