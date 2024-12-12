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
            var teamList = new List<Team>();
            var assignedJuniors = new HashSet<int>(); // Для отслеживания занятых джунов

            foreach (var teamLead in teamLeads)
            {
                var leadWishlist = teamLeadsWishlists.First(w => w.EmployeeId == teamLead.Id);

                // Найти первого свободного джуна из вишлиста тимлида
                var bestJuniorId = leadWishlist.DesiredEmployees
                    .FirstOrDefault(juniorId => !assignedJuniors.Contains(juniorId));

                if (bestJuniorId == 0) // Если все джуны из вишлиста заняты
                {
                    Console.WriteLine($"No available juniors for TeamLead {teamLead.Id}");
                    continue;
                }

                // Найти объект джуна по ID
                var junior = juniors.First(j => j.Id == bestJuniorId);

                // Добавить новую команду и занять джуна
                teamList.Add(new Team(teamLead, junior));
                assignedJuniors.Add(junior.Id);
            }

            return teamList;
        }
    }
}

