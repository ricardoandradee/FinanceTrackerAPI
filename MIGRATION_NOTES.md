# MIGRATION_NOTES.md

## Summary
This branch (feat/net8-migration) upgrades the FinanceTrackerAPI solution from .NET Core 3.1 to .NET 8.0 and updates incompatible NuGet packages and hosting model. Goals were to preserve API contracts and business logic while bringing projects to current stable packages and the WebApplication hosting model.

Branch: feat/net8-migration

## Files changed (high level)
- FinanceTracker.API/FinanceTracker.API.csproj
  - TargetFramework -> net8.0
  - LangVersion 12.0, Nullable enabled
  - Bumped ASP.NET-related packages and NSwag to versions compatible with .NET 8

- FinanceTracker.Application/FinanceTracker.Application.csproj
  - TargetFramework -> net8.0
  - LangVersion 12.0, Nullable enabled
  - Bumped packages: AutoMapper, AutoMapper.Extensions.Microsoft.DependencyInjection, FluentValidation, MediatR, Microsoft.EntityFrameworkCore
  - Updated MediatR registration to RegisterServicesFromAssembly in DependencyInjection

- FinanceTracker.Domain/FinanceTracker.Domain.csproj
  - TargetFramework -> net8.0
  - Nullable enabled

- FinanceTracker.Infrastructure/FinanceTracker.Infrastructure.csproj
  - TargetFramework -> net8.0
  - LangVersion 12.0, Nullable enabled
  - Bumped packages: JwtBearer, Identity.EntityFrameworkCore, Diagnostics.EntityFrameworkCore, EFCore.Proxies, EFCore.SqlServer, System.IdentityModel.Tokens.Jwt
  - Hardened DI: configuration guards and GetRequiredService usage

- FinanceTracker.API/Program.cs
  - Rewritten to use WebApplication.CreateBuilder (minimal hosting model)
  - Moved ConfigureServices -> builder.Services and Configure middleware -> app pipeline
  - Database migrations run on startup (MigrateAsync)
  - Seeding now async and gated to Development environment only (first run only because the seed checks for existing rows)

- FinanceTracker.Infrastructure/Persistence/ApplicationDbContextSeed.cs
  - Converted to async (SeedDataBaseAsync) and uses EF async APIs (AnyAsync, SaveChangesAsync, AddRange)

- FinanceTracker.Application/DependencyInjection.cs
  - Updated MediatR registration to use RegisterServicesFromAssembly

- FinanceTracker.Infrastructure/DependencyInjection.cs
  - Adds explicit checks for required configuration values (ConnectionStrings:DefaultConnectionAzure, Jwt:Key) and throws a clear InvalidOperationException if missing
  - Registers IApplicationDbContext with provider.GetRequiredService<ApplicationDbContext>()

- Added: MIGRATION_NOTES.md (this file)

## Packages updated (versions applied in branch)
These are the package versions applied to the repo files in this branch. They were selected to be stable releases compatible with .NET 8 as of the migration.
- Microsoft.AspNetCore.Mvc.NewtonsoftJson: 8.0.0
- Microsoft.AspNetCore.SpaServices.Extensions: 8.0.0
- Microsoft.AspNetCore.Identity.UI: 8.0.0
- Microsoft.Extensions.Diagnostics.HealthChecks.EntityFrameworkCore: 8.0.0
- Microsoft.VisualStudio.Web.CodeGeneration.Design: 8.0.0
- Microsoft.EntityFrameworkCore.Tools: 8.0.0
- NSwag.AspNetCore / NSwag.MSBuild: 14.0.7

- AutoMapper: 13.0.1
- AutoMapper.Extensions.Microsoft.DependencyInjection: 12.0.1
- FluentValidation: 11.8.0
- FluentValidation.DependencyInjectionExtensions: 11.8.0
- MediatR: 12.1.1
- MediatR.Extensions.Microsoft.DependencyInjection: 12.1.1
- Microsoft.EntityFrameworkCore: 8.0.0

- Microsoft.AspNetCore.Authentication.JwtBearer: 8.0.0
- Microsoft.AspNetCore.Identity.EntityFrameworkCore: 8.0.0
- Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore: 8.0.0
- Microsoft.EntityFrameworkCore.Proxies: 8.0.0
- Microsoft.EntityFrameworkCore.SqlServer: 8.0.0
- System.IdentityModel.Tokens.Jwt: 7.0.3

Note: If you prefer slightly different minor versions, update the csproj files on the branch and run a restore/build.

## Breaking changes considered and how they were handled
- Hosting model (Startup -> Program): Rewrote Program.cs to the new WebApplication model. All services and middleware were moved while preserving initialization order and behavior (error handler, CORS, custom 404 middleware, routing, authentication, authorization, static files, endpoints).

- MediatR API changes (v12+): Registration moved to the new RegisterServicesFromAssembly pattern to match new MediatR recommended registration. This is a wiring-only change and does not affect handlers or behavior.

- EF Core 8: Migrations assembly is still `FinanceTracker.API` as before. Migration calls were changed to `MigrateAsync()` and seeding uses async EF APIs. Validate EF tool compatibility in CI; if the environment uses older CLI tools, update them to a .NET 8–compatible dotnet-ef.

- System.IdentityModel.Tokens.Jwt upgrades: The token validation setup remains the same (IssuerSigningKey, ValidateIssuer/Audience). The DI and JwtBearer setup was updated to use the configuration guard for `Jwt:Key`. If you rely on any deprecated exceptions from older versions, handle them explicitly where used.

- Null-safety: Nullable was enabled and some DI usages were hardened (GetRequiredService). Configuration values that are required now throw descriptive exceptions at startup to fail fast if misconfigured.

## Seeding behavior
- Database migrations are executed on every startup: `context.Database.MigrateAsync()`.
- Seeding is executed only when `app.Environment.IsDevelopment()` is true and only when the tables are empty (seed method checks each table via Any/AnyAsync). This satisfies: Development-only, first-run-only, and empty-db-only constraints.

## Validation checklist (run locally or CI)
1. Prerequisites
   - Install .NET 8 SDK
   - Install dotnet-ef for EF tools (matching the EF Core 8 package version)

2. Restore & Build
   - dotnet restore
   - dotnet build --configuration Release

3. Tests
   - dotnet test

4. Run Migrations locally (example using environment placeholders)
   - Configure local environment variables (Bash):
     ```bash
     export ConnectionStrings__DefaultConnectionAzure="Server=.;Database=FT_Local;Trusted_Connection=True;"
     export Jwt__Key="your_local_jwt_secret_here"
     export ASPNETCORE_ENVIRONMENT=Development
     ```
   - Run database update (from repository root):
     ```bash
     dotnet ef database update --project FinanceTracker.Infrastructure --startup-project FinanceTracker.API
     ```
   - Or run the API and let it run migrations/seed (seed runs only when ASPNETCORE_ENVIRONMENT=Development and tables empty):
     ```bash
     dotnet run --project FinanceTracker.API
     ```

5. Smoke tests
   - Call a few endpoints (e.g., GET /api/health or representative endpoints) and compare responses against baseline from the previous implementation.
   - Validate JWT authentication works with tokens signed using the `Jwt:Key` value.

## CI guidance
- Ensure your CI uses the .NET 8 SDK image/runner and dotnet-ef version compatible with EF Core 8.
- Example CI steps (truncated):
  - dotnet restore
  - dotnet build --configuration Release
  - dotnet test
  - dotnet ef database update (if you want CI to run migrations on an integration DB)

I will attach CI logs as a comment in the PR once CI runs and completes.

## How to open the Pull Request
I pushed all changes to branch `feat/net8-migration`. Create a PR from `feat/net8-migration` -> `master` using the GitHub UI or the gh CLI:

```bash
# Using GitHub CLI
gh pr create --base master --head feat/net8-migration --title "chore: migrate to .NET 8" --body-file MIGRATION_NOTES.md
```

Or create the PR in the GitHub web UI and paste the contents of this file as the PR description.

## Notes / Limitations
- I updated and pushed code to the `feat/net8-migration` branch in this repository. I cannot run your CI runner from here; CI must be executed in your environment or via GitHub Actions configured on the repo. I will include instructions and example placeholders in this file for running everything locally.
- No secrets were committed. Provide any non-production DB strings or secrets via secure channels if you want me to validate against a specific environment.

---

If you want I can also prepare a GitHub Actions workflow (optional) that will run the build/test/ef steps on push to this branch and add it to the PR — tell me and I'll add it to the branch as well.
