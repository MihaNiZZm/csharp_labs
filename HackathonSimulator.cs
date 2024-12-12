namespace HackathonApp
{
    public class HackathonSimulator
    {
        private readonly IHrManager _hrManager;
        private readonly IHrDirector _hrDirector;

        public HackathonSimulator(IHrManager hrManager, IHrDirector hrDirector)
        {
            _hrManager = hrManager;
            _hrDirector = hrDirector;
        }

        public void SimulateHackathons(int iterations, IEnumerable<Employee> teamLeads, IEnumerable<Employee> juniors)
        {
            double totalHarmony = 0;
            for (int i = 0; i < iterations; i++)
            {
                var juniorWishlists = _hrManager.GenerateRandomWishlists(juniors, teamLeads);
                var teamLeadWishlists = _hrManager.GenerateRandomWishlists(teamLeads, juniors);
                var teams = _hrManager.BuildTeams(teamLeads, juniors, teamLeadWishlists, juniorWishlists);
                var harmony = _hrDirector.CalculateOverallTeamsHarmony(teams, teamLeadWishlists, juniorWishlists);
                totalHarmony += harmony;
                Console.WriteLine($"Hackathon {i + 1}: Harmony = {harmony}");
            }
            Console.WriteLine($"Average Harmony over {iterations} Hackathons: {totalHarmony / iterations}");
        }
    }
}

