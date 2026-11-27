namespace Csag.Extensions.DataSeeding
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface for seeds that can be executed by the seeding framework.
    /// Use the <see cref="DependsOnAttribute"/> to specify execution dependencies.
    /// </summary>
    /// <example>
    /// <code>
    /// [DependsOn(typeof(UserRolesSeed))]
    /// public class UsersSeed : ISeed
    /// {
    ///     private readonly ILogger&lt;UsersSeed&gt; logger;
    ///
    ///     public UsersSeed(ILogger&lt;UsersSeed&gt; logger)
    ///     {
    ///         this.logger = logger;
    ///     }
    ///
    ///     public async Task SeedAsync(CancellationToken cancellationToken)
    ///     {
    ///         this.logger.LogInformation("Seeding users...");
    ///         // Your seeding logic here
    ///     }
    /// }
    /// </code>
    /// </example>
    public interface ISeed
    {
        /// <summary>
        /// Performs the seeding operation asynchronously.
        /// This method is called by the seeding framework after all dependencies have been executed.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task representing the asynchronous seeding operation.</returns>
        Task SeedAsync(CancellationToken cancellationToken);
    }
}
