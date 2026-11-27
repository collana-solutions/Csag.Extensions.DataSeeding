namespace Csag.Extensions.DataSeeding.Tests.MultiDependency.UnitTests
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// A seed with complex multi-dependencies for testing.
    /// </summary>
    [DependsOn(typeof(FoundationSeedA), typeof(FoundationSeedB))]
    public class ComplexSeed : ISeed
    {
        /// <inheritdoc />
        public Task SeedAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
