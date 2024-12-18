
# Business Day Counter Application

## Overview
The **Business Day Counter Application** calculates the number of weekdays and business days between two dates. It considers public holidays and configurable rules for holiday calculations. The application follows a layered architecture with CQRS implemented using the Mediator design pattern.

## Solution Structure
The solution is structured as follows:

- **Contracts Layer**
  - **DesignCrowd.DateManager.Contracts.Api**:
    - Models:
      - `FixedHoliday`
      - `IPublicHolidayCheck`
      - `OccurrenceHoliday`
      - `WeekendHoliday`
    - Queries:
      - `GetBusinessDaysBetweenDatesQuery`
      - `GetWeekdaysBetweenDatesQuery`
  - **DesignCrowd.DateManager.Contracts.Shared.Cqrs**:
    - Interfaces:
      - `IQuery`

- **Core Layer**
  - **DesignCrowd.DateManager.Domain**:
    - Entities:
      - `PublicHoliday`
    - Enums:
      - `PublicHolidayType`
  - **DesignCrowd.DateManager.Infrastructure**:
    - Services:
      - `BusinessDayCounterService`
      - `PublicHolidayService`
      - `SqlDbContext`
    - Abstractions:
      - `IBusinessDayCounterService`
      - `IPublicHolidayService`

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
   git clone https://github.com/your-repo/business-day-counter.git
   cd business-day-counter
   ```
2. Build the solution:
   ```bash
   dotnet build
   ```
3. Run the console application:
   ```bash
   dotnet run --project Presentation
   ```

### Example Input/Output
- Input:
  ```
  Enter start date (YYYY-MM-DD): 2024-12-20
  Enter end date (YYYY-MM-DD): 2024-12-27
  ```
- Output:
  ```
  Weekdays: 3
  Business Days: 2
  ```

## Public Holiday Configuration
Public holidays are managed in the database (or an alternative configuration). To add rules:
1. Extend the `PublicHolidayRule` base class if needed.
2. Seed rules using EF Core or manually.

## Unit Tests
### Run Tests
To run the tests:
```bash
dotnet test
```

### Test Coverage
- Handlers for `WeekdaysBetweenDatesQuery` and `BusinessDaysBetweenDatesQuery`.
- `DateRangeService` methods.
- Mocked `IPublicHolidayService` for various scenarios.

## Extending the Application
1. **Add New Holiday Rules**:
   - Implement a new class inheriting from `PublicHolidayRule`.
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

---

For any questions or issues, feel free to contact us or open an issue on GitHub.
