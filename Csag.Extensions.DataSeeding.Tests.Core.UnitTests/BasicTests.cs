namespace Csag.Extensions.DataSeeding.Tests.Core.UnitTests
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Csag.Extensions.DataSeeding.Tests.Common.Fakes.Seeds;
    using Csag.Extensions.DataSeeding.Tests.Common.Fakes.Services;
    using Csag.Extensions.DataSeeding.Tests.Core.UnitTests.Fakes;
    using Csag.Extensions.DataSeeding.Tests.Core.UnitTests.Fakes.MultiTenantSeeds;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Shouldly;
    using Xunit;
    using Xunit.Abstractions;

    /// <summary>
    /// Basic Tests.
    /// </summary>
    public class BasicTests
    {
        /// <summary>
        /// The test output helper
        /// </summary>
        private readonly ITestOutputHelper testOutputHelper;

        /// <summary>
        /// Initializes a new instance of the <see cref="BasicTests"/> class.
        /// </summary>
        /// <param name="testOutputHelper">The test output helper.</param>
        public BasicTests(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }

        /// <summary>
        /// Asserts that the seeder runs without any exceptions. The seeded seeds should log to console.
        /// </summary>
        [Fact]
        public void SeedsCanBeSeededWithLoggingTest()
        {
            // Assign
            var services = this.CreateServiceCollection();
            services.AddDataSeeding(typeof(BasicTests).Assembly);
            services.AddTransient<DataInitializerFake>();
            var serviceProvider = services.BuildServiceProvider();
            var dataInitializer = serviceProvider.GetRequiredService<DataInitializerFake>();

            // Act
            var dataInitializerRun = dataInitializer.Run();

            // Assert
            dataInitializerRun.ShouldBeTrue();
        }

        /// <summary>
        /// Tests that duplicate seed registration throws an InvalidOperationException with a helpful message.
        /// </summary>
        [Fact]
        public void DuplicateSeedRegistrationThrowsInvalidOperationException()
        {
            // Arrange
            var services = this.CreateServiceCollection();

            services.AddDataSeeding(typeof(BasicTests).Assembly);

            // Issue: SimpleSeed is already added because AddDataSeeding scanned the assembly for ISeed implementations
            services.AddTransient<ISeed, SimpleSeed>();

            services.AddTransient<DataInitializerFake>();
            var serviceProvider = services.BuildServiceProvider();

            // Act & Assert - The exception should be thrown when the seeder is constructed (UseServiceProvider is called)
            var exception = Should.Throw<InvalidOperationException>(() =>
            {
                serviceProvider.GetRequiredService<DataInitializerFake>();
            });

            exception.Message.ShouldContain("Duplicate seed type(s) detected");
            exception.Message.ShouldContain("SimpleSeed");
            exception.Message.ShouldContain("This usually means the same seed class was registered more than once.");
        }

        /// <summary>
        /// Tests that AddDataSeeding returns the service collection it was called on, so that calls can be chained.
        /// </summary>
        [Fact]
        public void AddDataSeedingReturnsTheSameServiceCollection()
        {
            // Arrange
            var services = this.CreateServiceCollection();

            // Act
            var result = services.AddDataSeeding(typeof(BasicTests).Assembly);

            // Assert
            result.ShouldBeSameAs(services);
        }

        /// <summary>
        /// Tests that an assembly that is given two times is scanned one time, so that its seeds are registered one time.
        /// </summary>
        [Fact]
        public void AddDataSeedingScansAnAssemblyThatIsGivenTwoTimesOneTime()
        {
            // Arrange
            var services = this.CreateServiceCollection();

            // Act
            services.AddDataSeeding(typeof(BasicTests).Assembly, typeof(BasicTests).Assembly);

            // Assert: a second scan would register each seed again, and the seeder would then throw for the duplicate seed types
            services.Count(descriptor => descriptor.ServiceType == typeof(ISeed) && descriptor.ImplementationType == typeof(SimpleSeed)).ShouldBe(1);
            var serviceProvider = services.BuildServiceProvider();
            Should.NotThrow(() => serviceProvider.GetRequiredService<ISeeder>());
        }

        /// <summary>
        /// Tests that AddDataSeeding registers the seeds of each given assembly.
        /// </summary>
        [Fact]
        public void AddDataSeedingRegistersTheSeedsOfEachAssembly()
        {
            // Arrange
            var services = this.CreateServiceCollection();

            // Act
            services.AddDataSeeding(typeof(BasicTests).Assembly, typeof(AdditionalAssemblySeed).Assembly);

            // Assert
            services.Count(descriptor => descriptor.ServiceType == typeof(ISeed) && descriptor.ImplementationType == typeof(SimpleSeed)).ShouldBe(1);
            services.Count(descriptor => descriptor.ServiceType == typeof(ISeed) && descriptor.ImplementationType == typeof(AdditionalAssemblySeed)).ShouldBe(1);
        }

        /// <summary>
        /// Tests that AddDataSeeding rejects a null assembly.
        /// </summary>
        [Fact]
        public void AddDataSeedingWithNullAssemblyThrowsArgumentNullException()
        {
            // Arrange
            var services = this.CreateServiceCollection();

            // Act & Assert
            Should.Throw<ArgumentNullException>(() => services.AddDataSeeding(null!))
                .ParamName.ShouldBe("assembly");
        }

        /// <summary>
        /// Tests that AddDataSeeding rejects a null list of additional assemblies.
        /// </summary>
        [Fact]
        public void AddDataSeedingWithNullAdditionalAssembliesThrowsArgumentNullException()
        {
            // Arrange
            var services = this.CreateServiceCollection();

            // Act & Assert
            Should.Throw<ArgumentNullException>(() => services.AddDataSeeding(typeof(BasicTests).Assembly, (Assembly[])null!))
                .ParamName.ShouldBe("additionalAssemblies");
        }

        /// <summary>
        /// Tests that AddDataSeeding rejects a list of additional assemblies that contains null.
        /// </summary>
        [Fact]
        public void AddDataSeedingWithNullAdditionalAssemblyEntryThrowsArgumentException()
        {
            // Arrange
            var services = this.CreateServiceCollection();

            // Act & Assert
            Should.Throw<ArgumentException>(() => services.AddDataSeeding(typeof(BasicTests).Assembly, typeof(BasicTests).Assembly, null!))
                .ParamName.ShouldBe("additionalAssemblies");
        }

        /// <summary>
        /// Creates the service collection.
        /// </summary>
        /// <returns>The <see cref="IServiceCollection"/>.</returns>
        private IServiceCollection CreateServiceCollection()
        {
            var services = new ServiceCollection();
            services.AddLogging(builder => builder.AddXUnit(this.testOutputHelper));

            // Register fake services with different lifetimes to test scoped service injection
            // Use Tests.Common implementations to match what seeds expect
            services.AddSingleton<IFakeSingletonService, Tests.Common.Fakes.Services.FakeSingletonService>();
            services.AddScoped<IFakeScopedService, Tests.Common.Fakes.Services.FakeScopedService>();
            services.AddTransient<IFakeTransientService, Tests.Common.Fakes.Services.FakeTransientService>();

            // Register the scoped service with dependency to test UserManager-like scenarios
            services.AddScoped<IFakeScopedServiceWithDependency, Tests.Common.Fakes.Services.FakeScopedServiceWithDependency>();

            return services;
        }
    }
}
