using HackathonApp;
using Microsoft.Extensions.Hosting;

public class HackathonWorker : IHostedService
{
    private readonly HackathonSimulator _hackathonSimulator;
    private readonly DataLoader _dataLoader;

    public HackathonWorker(HackathonSimulator hackathonSimulator, DataLoader dataLoader)
    {
        _hackathonSimulator = hackathonSimulator;
        _dataLoader = dataLoader;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        string juniorsFilePath = "Juniors20.csv";
        string teamLeadsFilePath = "Teamleads20.csv";

        var juniors = _dataLoader.LoadEmployees(juniorsFilePath);
        var teamLeads = _dataLoader.LoadEmployees(teamLeadsFilePath);

        _hackathonSimulator.SimulateHackathons(1000, teamLeads, juniors);
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}

