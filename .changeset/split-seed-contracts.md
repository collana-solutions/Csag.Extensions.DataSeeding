---
"@collana-solutions/csag-extensions-dataseeding": major
"@collana-solutions/csag-extensions-dataseeding-abstractions": major
---

The contracts of the library (the interfaces `ISeed` and `ISeeder` and the attribute `DependsOnAttribute`) move to a new package, `Csag.Extensions.DataSeeding.Abstractions`. This package has no dependency on other packages. The two packages always have the same version.

- A project that references `Csag.Extensions.DataSeeding` needs no change for this split. `Csag.Extensions.DataSeeding` depends on `Csag.Extensions.DataSeeding.Abstractions`, so NuGet installs both packages.
- A project that only defines seeds, for example a domain or core library of your application, can reference `Csag.Extensions.DataSeeding.Abstractions` alone. That project then does not get the seeder and the packages that the seeder uses, such as Scrutor.

The types stay in the namespace `Csag.Extensions.DataSeeding`, without `.Abstractions`. Application code uses these types, so they belong in the namespace of the feature. Only the package ID tells that the package holds the contracts. Microsoft does the same with `ILogger`: its namespace is `Microsoft.Extensions.Logging`, and its package is `Microsoft.Extensions.Logging.Abstractions`.

**Why:** A project that only defines seeds can depend on the contracts without the seeder and its dependencies. Other libraries of collana solutions, for example `Csag.Extensions.Caching`, also have a separate Abstractions package for their contracts.
