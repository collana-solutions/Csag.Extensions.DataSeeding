namespace Csag.Extensions.DataSeeding.Demo
{
    using System;
    using System.Threading.Tasks;
    using Csag.DotNet.Console;

    /// <summary>
    /// The program
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public static async Task Main(string[] args)
        {
            var builder = DotNetConsole.CreateDefaultBuilder(args);
            DotNetConsoleLogger.Initialize(builder.Configuration);

            try
            {
                var startup = new Startup();
                startup.ConfigureServices(builder.Services);

                var console = builder.Build();
                await console.RunAsync();
            }
            catch (Exception ex)
            {
                DotNetConsoleLogger.Log.Error(ex, "Stopped program because of an unexpected exception");
                throw;
            }
            finally
            {
                // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
                DotNetConsoleLogger.Shutdown();
            }
        }
    }
}
