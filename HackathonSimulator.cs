using System;
using System.Collections.Generic;
using System.Linq;

namespace HackathonApp
{
    public class HackathonSimulator
    {
        public static void SimulateHackathons(int iterations,
            ITeamBuildingStrategy strategy,
            IEnumerable<Employee> teamLeads, IEnumerable<Employee> juniors)
        {
            double totalHarmony = 0;

            for (int i = 0; i < iterations; i++)
            {
                var juniorWishlists = DataLoader.GenerateRandomWishlists(juniors, teamLeads);
                var teamLeadWishlists = DataLoader.GenerateRandomWishlists(teamLeads, juniors);

                var teams = strategy.BuildTeams(teamLeads, juniors, teamLeadWishlists, juniorWishlists);
                var harmony = HarmonyCalculator.CalculateHarmony(teams, teamLeadWishlists, juniorWishlists);
                totalHarmony += harmony;

                Console.WriteLine($"Hackathon {i + 1}: Harmony = {harmony}");
            }

            Console.WriteLine($"Average Harmony over {iterations} Hackathons: {totalHarmony / iterations}");
        }
    }
}

