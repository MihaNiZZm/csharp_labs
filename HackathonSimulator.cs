using System;
using System.Collections.Generic;
using System.Linq;

namespace HackathonApp
{
    public class HackathonSimulator
    {
        public static void SimulateHackathons(int iterations,
            ITeamBuildingStrategy strategy,
            IEnumerable<Employee> teamLeads, IEnumerable<Employee> juniors,
            IEnumerable<Wishlist> teamLeadsWishlists, IEnumerable<Wishlist> juniorsWishlists)
        {
            double totalHarmony = 0;

            for (int i = 0; i < iterations; i++)
            {
                var teams = strategy.BuildTeams(teamLeads, juniors, teamLeadsWishlists, juniorsWishlists);
                var harmony = HarmonyCalculator.CalculateHarmony(teams, teamLeadsWishlists, juniorsWishlists);
                totalHarmony += harmony;

                Console.WriteLine($"Hackathon {i + 1}: Harmony = {harmony}");
            }

            Console.WriteLine($"Average Harmony over {iterations} Hackathons: {totalHarmony / iterations}");
        }
    }
}

