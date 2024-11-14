using System;
using System.Collections.Generic;
using System.Linq;

namespace HackathonApp
{
    public class HackathonSimulator
    {
        private readonly ITeamBuildingStrategy _strategy;
        private readonly HarmonyCalculator _harmonyCalculator;
        private readonly DataLoader _dataLoader;

        public HackathonSimulator(
            ITeamBuildingStrategy strategy,
            HarmonyCalculator harmonyCalculator,
            DataLoader dataLoader)
        {
            _strategy = strategy;
            _harmonyCalculator = harmonyCalculator;
            _dataLoader = dataLoader;
        }

        public void SimulateHackathons(int iterations, IEnumerable<Employee> teamLeads, IEnumerable<Employee> juniors)
        {
            double totalHarmony = 0;
            for (int i = 0; i < iterations; i++)
            {
                var juniorWishlists = _dataLoader.GenerateRandomWishlists(juniors, teamLeads);
                var teamLeadWishlists = _dataLoader.GenerateRandomWishlists(teamLeads, juniors);
                var teams = _strategy.BuildTeams(teamLeads, juniors, teamLeadWishlists, juniorWishlists);
                var harmony = _harmonyCalculator.CalculateHarmony(teams, teamLeadWishlists, juniorWishlists);
                totalHarmony += harmony;
                Console.WriteLine($"Hackathon {i + 1}: Harmony = {harmony}");
            }
            Console.WriteLine($"Average Harmony over {iterations} Hackathons: {totalHarmony / iterations}");
        }
    }
}

