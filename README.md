# vehicle-inventory-microservice

Vehicle Inventory Web API
Architecture Overview

It is a Clean Architecture Vehicle Inventory project in the form of RESTful API. 
The code is divided into various layers so as to have greater separation of concerns and scalability.

The Clean Architecture has the following layers:
1. Domain Layer

It includes:

Vehicle entity

Vehicle Status

DomainException

Business rules

It is the layer of the core business logic and domain validation rules. It is not based on any other layer.

2. Application Layer

It includes:

DTOs ( CreateVehicleRequest, UpdateVehicleStatusRequest, VehicleResponse)

Interfaces (IVehicleRepository)

VehicleService

The business flow and interaction between the domain and infrastructure layers are seen in this layer.

3. Infrastructure Layer

It includes:

EF Core DbContext

Repository implementation

Database configuration

The persistence mechanism with the help of Entity Framework Core is the duty of this layer.

4. WebAPI Layer

It includes:

Controllers

Swagger configuration

Dependency Injection

This layer manages the RESTful API endpoints and handling of the HTTP requests.


Domain Model and Business Rules.
Rules in the Vehicle entity are:

The vehicle code cannot be vacant.

The status must be one of the fixed statuses.

A DomainException is caused by invalid operations.

DataAnnotations are used to validate DTO.


Run Instructions:
Solve in Visual Studio.

Ensure that SQL server is running.

Apply database migrations:
Update-Database

Run the application.
Access Swagger at:

https://localhost:7297/swagger


Known Limitations:

None of the authentication/authorization applied.

No pagination or filtering for large datasets.

No advanced logging mechanism implemented.

Only to be developed locally.

No unit tests included.
