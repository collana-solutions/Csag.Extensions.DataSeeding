namespace Csag.Extensions.DataSeeding.Tests.Core.UnitTests.Fakes
{
    using System;
    using System.Threading;

    /// <summary>
    /// Fake data initializer.
    /// </summary>
    public class DataInitializerFake
    {
        /// <summary>
        /// The seeder
        /// </summary>
        private readonly ISeeder seeder;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataInitializerFake" /> class.
        /// </summary>
        /// <param name="seeder">The seeder.</param>
        public DataInitializerFake(ISeeder seeder)
        {
            this.seeder = seeder;
        }

        /// <summary>
        /// Runs this instance.
        /// </summary>
        /// <returns><c>true</c> if run did not throw any exceptions; otherwise <c>false</c>.</returns>
        public bool Run()
        {
            try
            {
                this.seeder.SeedAsync(CancellationToken.None);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
