namespace Csag.Extensions.DataSeeding.Tests.Core.UnitTests.Fakes.MultiTenantSeeds
{
    using System.Threading.Tasks;
    using Csag.Extensions.DataSeeding.Abstractions;
    using Microsoft.Extensions.Logging;

    /// <inheritdoc />
    [DependsOn(typeof(UsersSeed))]
    public class PermissionsSeed : ISeed
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<PermissionsSeed> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="PermissionsSeed"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public PermissionsSeed(ILogger<PermissionsSeed> logger)
        {
            this.logger = logger;
        }

        /// <inheritdoc />
        public Task SeedAsync()
        {
            this.logger.LogInformation("Seed() called");
            return Task.CompletedTask;
        }
    }
}
