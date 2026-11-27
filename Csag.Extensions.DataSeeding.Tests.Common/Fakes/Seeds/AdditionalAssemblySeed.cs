namespace Csag.Extensions.DataSeeding.Tests.Common.Fakes.Seeds
{
    /// <summary>
    /// A seed in the shared Tests.Common assembly, for tests that register the seeds of more than one assembly.
    /// </summary>
    public class AdditionalAssemblySeed : ISeed
    {
        /// <inheritdoc />
        public Task SeedAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
