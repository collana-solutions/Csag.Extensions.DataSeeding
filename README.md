# Csag.Extensions.DataSeeding

[![NuGet](https://img.shields.io/nuget/v/Csag.Extensions.DataSeeding.svg)](https://www.nuget.org/packages/Csag.Extensions.DataSeeding)
[![License: MIT](https://img.shields.io/badge/License-MIT-lightgray.svg)](./LICENSE)

A .NET library that splits data seeding code into small seeds. Each seed declares the seeds it depends on with the `[DependsOn]` attribute, and the seeder runs them in dependency order, each in its own dependency injection scope. Circular dependencies are reported with a clear error.

```shell
dotnet add package Csag.Extensions.DataSeeding
```

## Projects

| Project | Description |
|---|---|
| [`Csag.Extensions.DataSeeding`](./Csag.Extensions.DataSeeding) | The library, published as the [Csag.Extensions.DataSeeding](https://www.nuget.org/packages/Csag.Extensions.DataSeeding) NuGet package for `net8.0` and `net10.0`. Its [README](./Csag.Extensions.DataSeeding/README.md) is the package documentation. The CHANGELOG next to it is generated from changesets. |
| [`Csag.Extensions.DataSeeding.Abstractions`](./Csag.Extensions.DataSeeding.Abstractions) | The contracts (the interfaces `ISeed` and `ISeeder` and the attribute `DependsOnAttribute`), published as the [Csag.Extensions.DataSeeding.Abstractions](https://www.nuget.org/packages/Csag.Extensions.DataSeeding.Abstractions) NuGet package for `net8.0` and `net10.0`, with no dependency on other packages. The main package depends on it. Both packages always have the same version. Its [README](./Csag.Extensions.DataSeeding.Abstractions/README.md) is the package documentation, and its CHANGELOG is also generated from changesets. |
| [`Csag.Extensions.DataSeeding.Demo`](./Csag.Extensions.DataSeeding.Demo) | A console application that seeds a fictional CMS with 13 interconnected seeds. Its [README](./Csag.Extensions.DataSeeding.Demo/README.md) explains the dependency graph and how to run it. |
| `Csag.Extensions.DataSeeding.Tests.*` | xunit tests for the library, plus `Tests.Common` with the fake services they share. |

## Build and test

### Prerequisites

- The .NET SDK pinned in [global.json](global.json) (10.0.4xx, a newer 10.0 SDK rolls forward). It builds the `net8.0` and the `net10.0` targets, and it supplies the .NET 10.0 runtime for the `net10.0` tests.
- The .NET 8.0 runtime, to run the `net8.0` tests.
- Node.js 24 with Corepack, for the changesets tooling: run `corepack enable` and then `pnpm install` once in the repository root.

### Build

```bash
dotnet restore --locked-mode
dotnet build --configuration Release --no-restore
```

Every project has a `packages.lock.json`, and CI restores in locked mode. After changing a package reference, run `dotnet restore` without `--locked-mode` and commit the updated lock files.

### Run tests

```bash
dotnet test --configuration Release --no-build
```

### Pack

```bash
dotnet pack --configuration Release --no-build -o ./nupkgs
```

## Preview packages

Each pull request to `main` or to a `release/**` branch publishes both packages to a public preview feed on feedz.io. A draft PR, a PR from a fork and a PR from Dependabot publish no preview. The version is one patch above the current release, for example `2.0.1-pr.42.183` (PR 42, workflow run 183). The **"chore: version packages"** PR publishes a release candidate of the upcoming version instead, for example `2.1.0-pr.73.190`, so the changes of the next release can be tested before it ships. In prerelease mode the version in `package.json` is a prerelease such as `3.0.0-rc.0`, and the preview extends it, for example `3.0.0-rc.0.pr.42.183`. That version sorts after the prerelease and before the next one. A comment on the PR gives the version of its latest push. The feed removes previews after 30 days. Releases go to nuget.org only.

To use a preview in an application, add the feed to the `nuget.config` of the application. The feed needs no credentials:

```xml
<packageSources>
  <clear />
  <add key="nuget.org" value="https://api.nuget.org/v3/index.json" />
  <add key="csag-extensions-dataseeding-previews" value="https://f.feedz.io/collana-solutions/csag-extensions-dataseeding/nuget/index.json" />
</packageSources>
<packageSourceMapping>
  <packageSource key="nuget.org">
    <package pattern="*" />
    <package pattern="Csag.Extensions.DataSeeding" />
    <package pattern="Csag.Extensions.DataSeeding.Abstractions" />
  </packageSource>
  <packageSource key="csag-extensions-dataseeding-previews">
    <package pattern="Csag.Extensions.DataSeeding" />
    <package pattern="Csag.Extensions.DataSeeding.Abstractions" />
  </packageSource>
</packageSourceMapping>
```

The preview feed needs a pattern for each of the two package IDs. `Csag.Extensions.DataSeeding` depends on `Csag.Extensions.DataSeeding.Abstractions` of the same preview version, so that package must also restore from the feed. The same two patterns are also necessary under nuget.org. NuGet looks for a package only in the sources of its most specific pattern, so without them the released versions do not restore.

To test a preview:

1. Set each package of this repository that the application references (`Csag.Extensions.DataSeeding`, `Csag.Extensions.DataSeeding.Abstractions`) to the preview version.
2. If the application restores in locked mode, update its `packages.lock.json` files.
3. Add the feed only on the branch that tests the preview. The main branch of the application then does not need feedz.io to restore.

## Release process

This repository follows the [collana-solutions release playbook](https://github.com/collana-solutions/release-playbook) (Changesets, NuGet variant):

1. Every PR that changes a package needs a changeset. Run `pnpm changeset`, choose the packages and the bump type, and describe the change for consumers of the packages. CI's **Changeset Check** fails a PR that changes a package folder, `Directory.Build.props`, `Directory.Packages.props` or `global.json` without a changeset. Add an empty one (`pnpm changeset --empty`) when such a change ships nothing. A PR that only touches CI or repository documentation needs none.
2. On merge to `main`, the Release workflow keeps a **"chore: version packages"** PR up to date. It bumps the version in the `package.json` of each package folder, writes it into the `.csproj` next to it with `scripts/sync-versions.mjs` and updates the `CHANGELOG.md` files. The two packages are in one fixed group in `.changeset/config.json`, so they always get the same version.
3. Merging that PR creates a git tag and a GitHub Release for each package. The release of `Csag.Extensions.DataSeeding` starts the **NuGet Publish** workflow. It packs both packages and pushes them to nuget.org through [trusted publishing](https://learn.microsoft.com/nuget/nuget-org/trusted-publishing), so no API key is stored in the repository. To publish an existing release again, for example after a failed push, run **NuGet Publish** from the Actions tab with the release tag of `Csag.Extensions.DataSeeding`.

Dependabot PRs get their changesets automatically. Do not edit a `CHANGELOG.md` or the `<Version>` in a `.csproj` by hand.

## License

This project is licensed under the MIT License. See the [LICENSE](./LICENSE) file for details.
