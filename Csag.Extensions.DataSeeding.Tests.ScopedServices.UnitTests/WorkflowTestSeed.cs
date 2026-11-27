namespace Csag.Extensions.DataSeeding.Tests.ScopedServices.UnitTests
{
    using System.Threading;
    using System.Threading.Tasks;
    using Csag.Extensions.DataSeeding.Abstractions;

    /// <summary>
    /// Test seed for workflow testing.
    /// </summary>
    public class WorkflowTestSeed : ISeed
    {
        /// <inheritdoc />
        public Task SeedAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
