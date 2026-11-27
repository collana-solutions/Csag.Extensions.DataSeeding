namespace Csag.Extensions.DataSeeding.Tests.CircularDependency.UnitTests
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Example seed showing the new simplified syntax for single dependency
    /// </summary>
    [DependsOn(typeof(AnotherSeed))]
    public class SimpleDependencySeed : ISeed
    {
        /// <inheritdoc />
        public Task SeedAsync(CancellationToken cancellationToken)
        {
            // Your seeding logic here
            return Task.CompletedTask;
        }
    }
}
