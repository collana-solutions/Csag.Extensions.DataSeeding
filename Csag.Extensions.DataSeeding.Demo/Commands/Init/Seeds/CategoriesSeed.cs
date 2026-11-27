namespace Csag.Extensions.DataSeeding.Demo.Commands.Init.Seeds
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Creates content categories for organizing articles and pages
    /// Depends on system configuration for category settings
    /// </summary>
    [DependsOn(typeof(SystemConfigurationSeed))]
    public class CategoriesSeed : ISeed
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<CategoriesSeed> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoriesSeed"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public CategoriesSeed(ILogger<CategoriesSeed> logger)
        {
            this.logger = logger;
        }

        /// <inheritdoc />
        public async Task SeedAsync(CancellationToken cancellationToken)
        {
            this.logger.LogInformation("Creating content categories: News, Blog, Products, About...");
            await Task.Delay(120, cancellationToken);
            this.logger.LogInformation("Content categories created successfully");
        }
    }
}
