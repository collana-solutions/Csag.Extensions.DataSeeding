namespace Csag.Extensions.DataSeeding
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Extension methods for the <see cref="IServiceCollection"/>
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the data seeding functionality to the service collection.
        /// </summary>
        /// <remarks>
        /// The method registers each public class that is not abstract and that implements <see cref="ISeed"/> in the given assemblies.
        /// When you give an assembly more than one time, the method scans that assembly one time only.
        /// </remarks>
        /// <param name="services">The services.</param>
        /// <param name="assembly">The assembly that contains the seed implementations, for example <c>typeof(Program).Assembly</c>.</param>
        /// <param name="additionalAssemblies">More assemblies that contain seed implementations.</param>
        /// <returns>The same service collection, so that calls can be chained.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="assembly"/> or <paramref name="additionalAssemblies"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="additionalAssemblies"/> contains null.</exception>
        public static IServiceCollection AddDataSeeding(this IServiceCollection services, Assembly assembly, params Assembly[] additionalAssemblies)
        {
            ArgumentNullException.ThrowIfNull(assembly);
            ArgumentNullException.ThrowIfNull(additionalAssemblies);

            if (additionalAssemblies.Any(additionalAssembly => additionalAssembly is null))
            {
                throw new ArgumentException("The list of additional assemblies must not contain null.", nameof(additionalAssemblies));
            }

            var distinctAssemblies = additionalAssemblies.Prepend(assembly).Distinct().ToArray();

            services.AddTransient<ISeeder, Seeder>();
            Seeding.Instance.Configure(distinctAssemblies);

            // Register ISeed implementations
            services.Scan(scan => scan
                .FromAssemblies(distinctAssemblies)
                .AddClasses(classes => classes.AssignableTo<ISeed>())
                .AsSelf()
                .AsImplementedInterfaces()
                .WithTransientLifetime());

            return services;
        }
    }
}
