---
"@collana-solutions/csag-extensions-dataseeding": major
---

Added `CancellationToken` parameter to `ISeed.SeedAsync` and `ISeeder.SeedAsync` to support cooperative cancellation.

**Migration:**
Update any custom implementations of `ISeed` and `ISeeder` to accept `CancellationToken` in their `SeedAsync` method signatures:

- **Before:** `Task SeedAsync();`
- **After:** `Task SeedAsync(CancellationToken cancellationToken);`

A call to `ISeeder.SeedAsync` passes the token of the caller. A caller without a token passes `CancellationToken.None`.

**Why:** A seed calls async methods, for example of Entity Framework, and these take a `CancellationToken`. In v2 a seed had no token to pass to them. The seeder now gives each seed the token of its caller. There is no overload without the token: a call without it would give `CancellationToken.None` to every seed, and the run could never be cancelled.
