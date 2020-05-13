Webmaster
=========
Example of simple API implmenting [Vertical Slice Architecture](https://jimmybogard.com/vertical-slice-architecture/) using [CQRS pattern](https://docs.microsoft.com/en-us/azure/architecture/patterns/cqrs) and [MediatR library](https://github.com/jbogard/MediatR).

Provides a basic CRUD operetion for websites managing.

## Technologies
- .NET Core 3.1
- Entity Framework Core 3.1 / SQL Server LocalDb
- Swagger
- MediatR
- FluentValidation
- NUnit, FluentAssertions, Moq & Respawn

## Getting Started
Just build and run the project. A local database will be initialized and populated with needed data.

*If you are using SQL Server 2017 and ran into issue initializing the database, please be sure to upgrade to the [latest SQL Server 2017](https://www.microsoft.com/en-us/download/details.aspx?id=56128)*

## Swagger UI
1. Start the project
2. Navigate to default Swagger endpoint at https://localhost:5001/swagger/index.html

## Tests
Just run the tests. A new test database will be initialized and populated with needed data.

### Work needed!
Depending of the use case, a password protection algorithm must be implemented e.g. encrypting with user's secret like a password manager service or hashed for authentication purposes.
