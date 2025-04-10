# MovieAPI

A comprehensive RESTful API for managing movies, TV series, actors, directors, and related entertainment data.

## Overview

MovieAPI is an ASP.NET Core-based backend solution that offers a complete set of endpoints for handling entertainment content. The project implements domain-driven design principles with proper separation of concerns using a clean architecture approach.

## Features

- Complete CRUD operations for movies, TV series, episodes, actors, and directors
- JWT-based authentication for secure API access
- Rich relationship modeling between entertainment entities:
  - Movies and their actors/directors
  - TV series, seasons, episodes, and cast members
  - Genre classifications
- User-specific watchlists and recommendations
- Rating and review system
- Swagger documentation for API testing and exploration

## Architecture

The solution is organized into four main projects:

- **MovieAPI.Domain**: Core business entities, interfaces, and the Result pattern implementation
- **MovieAPI.Application**: Application services, DTOs, and business logic
- **MovieAPI.Infrastructure**: Data access, repositories, and external service implementations
- **MovieAPI.API**: Controllers, filters, and API configuration

## Key Relationships

- Movies can have multiple actors and directors (many-to-many)
- Series can have multiple episodes, actors, and directors
- Users can create watchlists containing movies and series
- Content can be categorized with multiple genres
- Users can rate and review movies and series

## Getting Started

### Prerequisites

- .NET 9.0 SDK
- SQL Server (LocalDB or full instance)
- Visual Studio or another IDE

### Installation

1. Clone the repository
2. Update the connection string in `appsettings.json` if needed
3. Run the application using:
   ```
   dotnet run --project src/MovieAPI.API
   ```
4. Access the API at:
   - HTTP: http://localhost:5000
   - HTTPS: https://localhost:5001
5. Browse Swagger documentation at `/swagger`

## API Endpoints

The API provides endpoints for managing:

- Authentication (register, login)
- Movies with filtering and search
- Series and their episodes
- Actors and directors
- User watchlists and preferences
- Ratings and reviews

## Technology Stack

- ASP.NET Core 9.0
- Entity Framework Core with SQL Server
- JWT authentication
- Swagger/OpenAPI for documentation
- Result pattern for standardized responses

## Development Notes

- Repository pattern is used for data access
- Services follow a uniform interface pattern
- JWT configuration is stored in appsettings.json
- Dependency Injection is used throughout the application

## Future Enhancements

- Recommendation engine based on user preferences
- Advanced search and filtering
- Performance optimizations for large datasets
- Media file storage and streaming 