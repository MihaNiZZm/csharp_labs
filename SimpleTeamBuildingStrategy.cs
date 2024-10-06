using System.Collections.Generic;
using System.Linq;

namespace HackathonApp
{
    public class SimpleTeamBuildingStrategy : ITeamBuildingStrategy
    {
        public IEnumerable<Team> BuildTeams(
            IEnumerable<Employee> teamLeads,
            IEnumerable<Employee> juniors,
            IEnumerable<Wishlist> teamLeadsWishlists,
            IEnumerable<Wishlist> juniorsWishlists)
        {
            // Простая стратегия на основе предпочтений
            var teamList = new List<Team>();

            foreach (var teamLead in teamLeads)
            {
                var leadWishlist = teamLeadsWishlists.First(w => w.EmployeeId == teamLead.Id);
                var bestJuniorId = leadWishlist.DesiredEmployees[0]; // Пример: всегда выбирать лучшего джуна
                var junior = juniors.First(j => j.Id == bestJuniorId);

                teamList.Add(new Team(teamLead, junior));
            }

            return teamList;
        }
    }
}

