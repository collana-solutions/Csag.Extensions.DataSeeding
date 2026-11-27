namespace Csag.Extensions.DataSeeding.Tests.MultiDependency.UnitTests
{
    using System.Threading;
    using System.Threading.Tasks;
    using Csag.Extensions.DataSeeding.Abstractions;

    /// <summary>
    /// Foundation seed A for multi-dependency testing.
    /// </summary>
    public class FoundationSeedA : ISeed
    {
        /// <inheritdoc />
        public Task SeedAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
