# Csag.Extensions.DataSeeding.Abstractions

[![NuGet](https://img.shields.io/nuget/v/Csag.Extensions.DataSeeding.Abstractions.svg)](https://www.nuget.org/packages/Csag.Extensions.DataSeeding.Abstractions)
[![License: MIT](https://img.shields.io/badge/License-MIT-lightgray.svg)](https://github.com/collana-solutions/Csag.Extensions.DataSeeding/blob/main/LICENSE)

The contracts (the interfaces and the attribute) of [Csag.Extensions.DataSeeding](https://www.nuget.org/packages/Csag.Extensions.DataSeeding). This package has no dependency on other packages.

## Contents

All types are in the `Csag.Extensions.DataSeeding` namespace:

- `ISeed`: one seed, with its `SeedAsync` method.
- `[DependsOn(typeof(...))]`: the seeds that must run before this seed.
- `ISeeder`: runs all registered seeds in dependency order.

## When to reference this package

Reference this package in a project that only defines seeds, for example a domain or core library of an application. That project then does not get the seeder and the packages that the seeder uses.

The project that registers and runs the seeds references [Csag.Extensions.DataSeeding](https://www.nuget.org/packages/Csag.Extensions.DataSeeding). That package depends on this package, so NuGet installs both. That project does not need its own reference to this package.

The [README of Csag.Extensions.DataSeeding](https://github.com/collana-solutions/Csag.Extensions.DataSeeding/blob/main/Csag.Extensions.DataSeeding/README.md) describes the setup and the use of the seeds.
