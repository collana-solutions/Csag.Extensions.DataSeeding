namespace Csag.Extensions.DataSeeding.Demo.Commands.Init.Seeds
{
    using System.Threading;
    using System.Threading.Tasks;
    using Csag.Extensions.DataSeeding.Abstractions;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Creates user profiles and personalization settings
    /// Depends on UsersSeed to have users available for profile creation
    /// </summary>
    [DependsOn(typeof(UsersSeed))]
    public class UserProfilesSeed : ISeed
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<UserProfilesSeed> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserProfilesSeed"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public UserProfilesSeed(ILogger<UserProfilesSeed> logger)
        {
            this.logger = logger;
        }

        /// <inheritdoc />
        public async Task SeedAsync(CancellationToken cancellationToken)
        {
            this.logger.LogInformation("Creating user profiles: bio, avatar, contact information...");
            await Task.Delay(200, cancellationToken);
            this.logger.LogInformation("Setting up user preferences: theme, language, notifications...");
            await Task.Delay(150, cancellationToken);
            this.logger.LogInformation("Configuring user dashboard layouts and widgets...");
            await Task.Delay(100, cancellationToken);
            this.logger.LogInformation("User profiles and personalization settings created successfully");
        }
    }
}
