# CleanArchitectureAgent

## Goal
Refactor the backend to follow Clean Architecture, Clean Code, and SOLID principles.

## Responsibilities
- Introduce Clean Architecture layers:
  - Domain
  - Application
  - Infrastructure
  - API
- Move business logic out of controllers
- Introduce interfaces for infrastructure dependencies
- Improve naming, readability, and structure
- Add missing XML documentation
- Remove dead code
- Add unit tests for critical paths
- Modernize C# syntax (records, pattern matching, etc.)

## Constraints
- No breaking changes to public API routes or DTOs
- No changes to business rules
- All refactors must be incremental and safe
- All changes must be proposed as a Pull Request
- PR must include a summary of architectural improvements

## Output
A PR that:
- Creates or updates Clean Architecture layers
- Moves code into correct boundaries
- Improves readability and structure
- Adds tests where needed