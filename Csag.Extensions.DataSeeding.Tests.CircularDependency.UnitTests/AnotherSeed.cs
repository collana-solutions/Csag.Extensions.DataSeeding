namespace Csag.Extensions.DataSeeding.Tests.CircularDependency.UnitTests
{
    using System.Threading;
    using System.Threading.Tasks;
    using Csag.Extensions.DataSeeding.Abstractions;

    /// <summary>
    /// Another seed with no dependencies
    /// </summary>
    public class AnotherSeed : ISeed
    {
        /// <inheritdoc />
        public Task SeedAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
