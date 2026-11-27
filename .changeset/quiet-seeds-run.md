---
"@collana-solutions/csag-extensions-dataseeding": major
---

The public API changes. At each place in your code that you must change, the compiler shows an error. The fixes are mechanical.

**To migrate:**

1. The namespace `Csag.Extensions.DataSeeding.Abstractions` is removed. `ISeed`, `ISeeder` and `DependsOnAttribute` are now in `Csag.Extensions.DataSeeding`.
   - **Before:** `using Csag.Extensions.DataSeeding.Abstractions;`
   - **After:** `using Csag.Extensions.DataSeeding;`
   - **Why:** Application code uses these types, and such types belong in the namespace of the feature. The word "Abstractions" tells how the code is packaged, not what the types are. Microsoft does the same: `ILogger` is in the namespace `Microsoft.Extensions.Logging`, and its package is `Microsoft.Extensions.Logging.Abstractions`. Also, a seed file needs one `using` less.
2. `AddDataSeeding()` without arguments is removed. A call without arguments no longer compiles. Give the assembly that contains your seeds.
   - **Before:** `services.AddDataSeeding();`
   - **After:** `services.AddDataSeeding(typeof(Program).Assembly);`
   - **Why:** The call without arguments scanned the assembly of its caller. In an optimized build, the runtime can merge a small method into its caller (inlining), so the scanned assembly can differ between Debug and Release, without an error. An explicit assembly registers the same seeds in every build.
3. `AddDataSeeding` takes one assembly and, as an option, more assemblies. It registers the seeds of each of them. A call with one assembly does not change.
   - **Before:** `AddDataSeeding(this IServiceCollection services, Assembly assembly)`
   - **After:** `AddDataSeeding(this IServiceCollection services, Assembly assembly, params Assembly[] additionalAssemblies)`, for example `services.AddDataSeeding(typeof(Program).Assembly, typeof(SharedSeed).Assembly);`
   - **Why:** When your seeds are in more than one project, one call registers all of them. v2 needed one call for each assembly.
4. `AddDataSeeding` returns the `IServiceCollection`, so you can chain more calls. Your source code does not change.
   - **Before:** `public static void AddDataSeeding(...)`
   - **After:** `public static IServiceCollection AddDataSeeding(...)`
   - **Why:** The `Add...` methods of Microsoft.Extensions return the `IServiceCollection`, so that registrations can be chained. `AddDataSeeding` now follows this convention.

**Compile every project that calls `AddDataSeeding` again.** Items 3 and 4 change its signature. Source code compiles unchanged, but a DLL compiled against v2 fails with v3 with a `MissingMethodException` for `AddDataSeeding`. This hits, for example, a library of your own that was not compiled again. Compile each project that calls `AddDataSeeding` against v3.
