namespace Csag.Extensions.DataSeeding.Tests.Core.UnitTests
{
    using System.Threading;
    using System.Threading.Tasks;
    using Csag.Extensions.DataSeeding.Abstractions;
    using Csag.Extensions.DataSeeding.Tests.Common.Fakes.Services;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Test seed for workflow integration testing.
    /// </summary>
    public class WorkflowTestSeed : ISeed
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger<WorkflowTestSeed> logger;

        /// <summary>
        /// The scoped service.
        /// </summary>
        private readonly IFakeScopedService scopedService;

        /// <summary>
        /// The scoped service with dependency.
        /// </summary>
        private readonly IFakeScopedServiceWithDependency scopedServiceWithDependency;

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkflowTestSeed"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="scopedService">The scoped service.</param>
        /// <param name="scopedServiceWithDependency">The scoped service with dependency.</param>
        public WorkflowTestSeed(
            ILogger<WorkflowTestSeed> logger,
            IFakeScopedService scopedService,
            IFakeScopedServiceWithDependency scopedServiceWithDependency)
        {
            this.logger = logger;
            this.scopedService = scopedService;
            this.scopedServiceWithDependency = scopedServiceWithDependency;
        }

        /// <inheritdoc />
        public async Task SeedAsync(CancellationToken cancellationToken)
        {
            this.logger.LogInformation("Executing workflow test seed with scoped services");

            // Test both scoped services
            this.logger.LogInformation("Scoped service ID: {ServiceId}", this.scopedService.ServiceId);
            var result = await this.scopedServiceWithDependency.PerformScopedOperationAsync();
            this.logger.LogInformation("Scoped operation result: {Result}", result);
        }
    }
}
