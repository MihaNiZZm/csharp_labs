using System.Linq;

namespace HackathonApp
{
    public static class HarmonyCalculator
    {
        public static double CalculateHarmony(IEnumerable<Team> teams,
            IEnumerable<Wishlist> teamLeadsWishlists, IEnumerable<Wishlist> juniorsWishlists)
        {
            double totalSatisfaction = 0;
            int participants = teams.Count() * 2; // Так как в команде два участника

            foreach (var team in teams)
            {
                var leadSatisfaction = SatisfactionCalculator
                    .CalculateSatisfaction(teamLeadsWishlists.First(w => w.EmployeeId == team.Teamlead.Id), team.Junior.Id);
                var juniorSatisfaction = SatisfactionCalculator
                    .CalculateSatisfaction(juniorsWishlists.First(w => w.EmployeeId == team.Junior.Id), team.Teamlead.Id);

                totalSatisfaction += leadSatisfaction + juniorSatisfaction;
            }

            return totalSatisfaction / participants;
        }
    }
}
