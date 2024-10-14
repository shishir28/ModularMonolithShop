# ModularMonolithShop
This is a project for a modular monolith and in way revisiting the work done in [edukaan](https://github.com/shishir28/edukaan).

Principles followed:
1. DDD
2. CQRS
3. Vertical Slice Architecture
4. Modular Monolith
5. SOLID
6. Mediator Pattern, Decorator Pattern, Repository Pattern, Unit of Work Pattern, Factory Pattern, Strategy Pattern, Dependency Injection
7. Pub/Sub Pattern
8. Outbox Pattern

Backing Services:
1. Postgres
2. Redis
3. RabbitMQ
4. Keycloak
5. Seq

Libraries:
1. Carter
2. MediatR
3. Mapster
4. MassTransit

`docker-compose -f ./docker-compose.yml -f ./docker-compose.override.yml up --build`
`dotnet ef migrations add InitialCreate -s API/ModularMonolithShop.Api/ModularMonolithShop.Api.csproj -p Modules/Catalog/ModularMonolithShop.Catalog.csproj -o Infrastructure/Persistence/Migrations`
`dotnet ef database update InitialCreate -s API/ModularMonolithShop.Api/ModularMonolithShop.Api.csproj -p Modules/Catalog/ModularMonolithShop.Catalog.csproj`
