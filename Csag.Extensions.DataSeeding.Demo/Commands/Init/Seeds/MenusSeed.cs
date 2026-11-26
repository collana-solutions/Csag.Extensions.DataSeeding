namespace Csag.Extensions.DataSeeding.Demo.Commands.Init.Seeds
{
    using System.Threading;
    using System.Threading.Tasks;
    using Csag.Extensions.DataSeeding.Abstractions;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Creates navigation menus and menu structures
    /// Depends on ContentTemplatesSeed for menu templates
    /// </summary>
    [DependsOn(typeof(ContentTemplatesSeed))]
    public class MenusSeed : ISeed
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<MenusSeed> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="MenusSeed"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public MenusSeed(ILogger<MenusSeed> logger)
        {
            this.logger = logger;
        }

        /// <inheritdoc />
        public async Task SeedAsync(CancellationToken cancellationToken)
        {
            this.logger.LogInformation("Creating navigation menus: main menu, footer menu, admin menu...");
            await Task.Delay(120, cancellationToken);
            this.logger.LogInformation("Navigation menus created and configured with templates");
        }
    }
}
