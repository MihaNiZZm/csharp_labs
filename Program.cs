using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HackathonApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<DataLoader>();
                    services.AddSingleton<IHarmonyCalculator, HarmonyCalculator>();
                    services.AddSingleton<IHrDirector, HrDirector>();
                    services.AddSingleton<IHrManager, HrManager>();
                    services.AddTransient<ITeamBuildingStrategy, SimpleTeamBuildingStrategy>();
                    services.AddTransient<HackathonSimulator>();
                    services.AddHostedService<HackathonWorker>();
                })
                .Build();

            host.Run();
        }
    }
}
