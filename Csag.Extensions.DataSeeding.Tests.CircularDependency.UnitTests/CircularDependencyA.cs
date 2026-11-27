namespace Csag.Extensions.DataSeeding.Tests.CircularDependency.UnitTests
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Circular dependency test seed A that depends on B.
    /// </summary>
    [DependsOn(typeof(CircularDependencyB))]
    public class CircularDependencyA : ISeed
    {
        /// <inheritdoc />
        public Task SeedAsync(CancellationToken cancellationToken)
        {
            // This seed intentionally creates a circular dependency for testing
            return Task.CompletedTask;
        }
    }
}
