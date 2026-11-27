namespace Csag.Extensions.DataSeeding
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides seeding methods for the automatically registered seed components.
    /// </summary>
    /// <seealso cref="ISeeder" />
    public interface ISeeder
    {
        /// <summary>
        /// Seeds all registered seed components in dependency order.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task SeedAsync(CancellationToken cancellationToken);
    }
}
