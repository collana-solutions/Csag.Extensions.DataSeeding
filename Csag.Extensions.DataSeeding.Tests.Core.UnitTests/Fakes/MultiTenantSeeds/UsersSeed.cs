namespace Csag.Extensions.DataSeeding.Tests.Core.UnitTests.Fakes.MultiTenantSeeds
{
    using System.Threading;
    using System.Threading.Tasks;
    using Csag.Extensions.DataSeeding.Abstractions;
    using Microsoft.Extensions.Logging;

    /// <inheritdoc />
    [DependsOn(typeof(TenantsSeed))]
    public class UsersSeed : ISeed
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<UsersSeed> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersSeed"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public UsersSeed(ILogger<UsersSeed> logger)
        {
            this.logger = logger;
        }

        /// <inheritdoc />
        public Task SeedAsync(CancellationToken cancellationToken)
        {
            this.logger.LogInformation("Seed() called");
            return Task.CompletedTask;
        }
    }
}
