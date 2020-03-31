namespace WebAPIReactCrud
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using FakeData;

    public class Program
    {
        public static void Main(string[] args)
        {
            // 1. Get the IWebHost which will host this application.
            var host = CreateHostBuilder(args).Build();

            // 2. Find the service layer within our scope.
            using (var scope = host.Services.CreateScope())
            {
                // 3. Get the instance of DonationDbContext in our services layer.
                var services = scope.ServiceProvider;
                
                DataGenerator.Initialize(services);
            }
            
            host.Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}