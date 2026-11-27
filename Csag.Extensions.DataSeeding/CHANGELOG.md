# @collana-solutions/csag-extensions-dataseeding

## 3.0.0

### Major Changes

- [#20](https://github.com/collana-solutions/Csag.Extensions.DataSeeding/pull/20) [`acbc20b`](https://github.com/collana-solutions/Csag.Extensions.DataSeeding/commit/acbc20bb59bec47c2de0d312bc28d6327a99a566) Thanks [@neoscie](https://github.com/neoscie)! - The package targets `net8.0` and `net10.0`. It no longer targets `net6.0`.
  
  **To migrate:**
  
  - An application on .NET 8 or later needs no change.
  - An application on .NET 6 or .NET 7 cannot use this version. Use version 2 for that application, or move the application to .NET 8 or later.

- [#18](https://github.com/collana-solutions/Csag.Extensions.DataSeeding/pull/18) [`712229e`](https://github.com/collana-solutions/Csag.Extensions.DataSeeding/commit/712229ed8c7673bb2784c9cf60c0e830c3244116) Thanks [@drebrez](https://github.com/drebrez)! - Added `CancellationToken` parameter to `ISeed.SeedAsync` and `ISeeder.SeedAsync` to support cooperative cancellation.
  
  **Migration:**
  Update any custom implementations of `ISeed` and `ISeeder` to accept `CancellationToken` in their `SeedAsync` method signatures:
  
  - **Before:** `Task SeedAsync();`
  - **After:** `Task SeedAsync(CancellationToken cancellationToken);`

### Patch Changes

- [#17](https://github.com/collana-solutions/Csag.Extensions.DataSeeding/pull/17) [`068bcf7`](https://github.com/collana-solutions/Csag.Extensions.DataSeeding/commit/068bcf706cb8e61fed96be1fdd2edfc219eb7607) Thanks [@dependabot](https://github.com/apps/dependabot)! - Bump the nuget-ecosystem group with 5 updates
  
  Scrutor 7.0.0 needs Microsoft.Extensions.DependencyInjection.Abstractions 10.0.0 and Microsoft.Extensions.DependencyModel 10.0.0. This applies to `net8.0` too. On `net8.0`, the package now also brings System.Text.Json, System.Text.Encodings.Web and System.IO.Pipelines, all at 10.0.0.
  
  | Package | From | To | Bump |
  |---------|------|----|------|
  | coverlet.collector | 6.0.4 | 10.1.0 | 🔴 major |
  | MartinCostello.Logging.XUnit | 0.6.0 | 0.7.1 | 🟡 minor |
  | Microsoft.NET.Test.Sdk | 17.14.1 | 18.11.0 | 🔴 major |
  | Scrutor | 6.1.0 | 7.0.0 | 🔴 major |
  | xunit.runner.visualstudio | 3.1.3 | 4.0.1 | 🔴 major |

## 2.0.0

### Major Changes

- [#11](https://github.com/collana-solutions/Csag.Extensions.DataSeeding/pull/11) [`4caeef8`](https://github.com/collana-solutions/Csag.Extensions.DataSeeding/commit/4caeef82cce00344c26846d98819895e003e867e) Thanks [@neotrow](https://github.com/neotrow)! - The package moves to a new ID and new namespaces. The API and the behavior are the same as in 1.0.0.
  
  | Up to 1.0.0 | From 2.0.0 |
  | --- | --- |
  | `Neolution.Extensions.DataSeeding` | `Csag.Extensions.DataSeeding` |
  
  **To migrate:**
  
  1. Replace the `Neolution.Extensions.DataSeeding` package reference with `Csag.Extensions.DataSeeding`, at 2.0.0 or later.
  2. Change the namespaces: `using Neolution.Extensions.DataSeeding;` (for `AddDataSeeding`) becomes `using Csag.Extensions.DataSeeding;`, and `using Neolution.Extensions.DataSeeding.Abstractions;` (for `ISeed`, `ISeeder` and `DependsOn`) becomes `using Csag.Extensions.DataSeeding.Abstractions;`.
  
  The `Neolution.Extensions.DataSeeding` ID gets deprecated on nuget.org, with `Csag.Extensions.DataSeeding` as the alternate. Its existing versions stay available, but it gets no new releases.
