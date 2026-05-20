# MigrationAgent

## Goal
Upgrade the existing .NET Core 3 backend to .NET 8 with zero regressions.

## Responsibilities
- Update all .csproj files to net8.0
- Migrate Startup.cs → Program.cs using the new hosting model
- Replace deprecated APIs
- Update NuGet packages to compatible versions
- Fix breaking changes
- Ensure the solution builds and tests pass

## Constraints
- Do NOT change API contracts
- Do NOT modify business logic
- Do NOT remove any endpoints
- All changes must be proposed as a Pull Request
- PR must include explanation of each change

## Output
A single PR containing:
- Updated project files
- Updated Program.cs
- Updated dependencies
- Notes on breaking changes handled