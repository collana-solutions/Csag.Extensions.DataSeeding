---
"@collana-solutions/csag-extensions-dataseeding": major
---

The package moves to a new ID and new namespaces. The API and the behavior are the same as in 1.0.0.

| Up to 1.0.0 | From 2.0.0 |
| --- | --- |
| `Neolution.Extensions.DataSeeding` | `Csag.Extensions.DataSeeding` |

**To migrate:**

1. Replace the `Neolution.Extensions.DataSeeding` package reference with `Csag.Extensions.DataSeeding`, at 2.0.0 or later.
2. Change the namespaces: `using Neolution.Extensions.DataSeeding;` (for `AddDataSeeding`) becomes `using Csag.Extensions.DataSeeding;`, and `using Neolution.Extensions.DataSeeding.Abstractions;` (for `ISeed`, `ISeeder` and `DependsOn`) becomes `using Csag.Extensions.DataSeeding.Abstractions;`.

The `Neolution.Extensions.DataSeeding` ID gets deprecated on nuget.org, with `Csag.Extensions.DataSeeding` as the alternate. Its existing versions stay available, but it gets no new releases.
