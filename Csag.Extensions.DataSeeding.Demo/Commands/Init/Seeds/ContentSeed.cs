namespace Csag.Extensions.DataSeeding.Demo.Commands.Init.Seeds
{
    using System.Threading;
    using System.Threading.Tasks;
    using Csag.Extensions.DataSeeding.Abstractions;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Creates sample content including pages and articles
    /// Depends on both categories and users being available (demonstrates multiple dependencies)
    /// </summary>
    [DependsOn(typeof(CategoriesSeed), typeof(UsersSeed), typeof(ContentTemplatesSeed), typeof(ContentMetadataSeed))]
    public class ContentSeed : ISeed
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<ContentSeed> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContentSeed"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public ContentSeed(ILogger<ContentSeed> logger)
        {
            this.logger = logger;
        }

        /// <inheritdoc />
        public async Task SeedAsync(CancellationToken cancellationToken)
        {
            this.logger.LogInformation("Creating sample content: Home page, About page, sample blog posts...");
            await Task.Delay(250, cancellationToken);
            this.logger.LogInformation("Sample content created and assigned to categories and authors");
        }
    }
}
