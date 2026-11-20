namespace Csag.Extensions.DataSeeding.Tests.MultiDependency.UnitTests
{
    using System.Threading.Tasks;
    using Csag.Extensions.DataSeeding.Abstractions;

    /// <summary>
    /// Foundation seed B for multi-dependency testing.
    /// </summary>
    public class FoundationSeedB : ISeed
    {
        /// <summary>
        /// Seeds the data.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task SeedAsync()
        {
            return Task.CompletedTask;
        }
    }
}
