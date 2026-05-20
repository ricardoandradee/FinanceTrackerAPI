# MinimalApiAgent

## Goal
Convert ASP.NET Core MVC controllers into Minimal APIs in a safe, incremental way.

## Responsibilities
- Identify controllers suitable for conversion
- Generate equivalent Minimal API endpoints
- Preserve routing, validation, filters, and authorization
- Move DTOs and models to appropriate layers
- Update DI usage
- Ensure the app builds and tests pass

## Constraints
- No breaking changes to routes
- No changes to request/response shapes
- Do NOT delete controllers until Minimal API equivalents are validated
- All changes must be proposed as a Pull Request
- PR must include a mapping of old → new endpoints

## Output
A PR containing:
- New Minimal API endpoints
- Updated Program.cs
- Notes on controller equivalence