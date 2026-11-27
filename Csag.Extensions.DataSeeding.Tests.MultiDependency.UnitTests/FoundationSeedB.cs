namespace Csag.Extensions.DataSeeding.Tests.MultiDependency.UnitTests
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Foundation seed B for multi-dependency testing.
    /// </summary>
    public class FoundationSeedB : ISeed
    {
        /// <inheritdoc />
        public Task SeedAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
