---
"@collana-solutions/csag-extensions-dataseeding": major
---

Added `CancellationToken` parameter to `ISeed.SeedAsync` and `ISeeder.SeedAsync` to support cooperative cancellation.

**Migration:**
Update any custom implementations of `ISeed` and `ISeeder` to accept `CancellationToken` in their `SeedAsync` method signatures:

- **Before:** `Task SeedAsync();`
- **After:** `Task SeedAsync(CancellationToken cancellationToken);`
