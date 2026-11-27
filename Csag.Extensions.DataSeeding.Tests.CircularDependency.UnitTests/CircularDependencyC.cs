namespace Csag.Extensions.DataSeeding.Tests.CircularDependency.UnitTests
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Circular dependency test seed C that depends on A, forming a 3-node cycle: A → B → C → A.
    /// </summary>
    [DependsOn(typeof(CircularDependencyA))]
    public class CircularDependencyC : ISeed
    {
        /// <inheritdoc />
        public Task SeedAsync(CancellationToken cancellationToken)
        {
            // This seed intentionally creates a 3-node circular dependency for testing
            return Task.CompletedTask;
        }
    }
}
