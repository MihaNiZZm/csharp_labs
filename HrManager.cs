
namespace HackathonApp
{
    public class HrManager : IHrManager
    {
        private readonly ITeamBuildingStrategy _strategy;

        public HrManager(ITeamBuildingStrategy strategy)
        {
            _strategy = strategy;
        }

        public IEnumerable<Team> BuildTeams(IEnumerable<Employee> teamLeads, IEnumerable<Employee> juniors, IEnumerable<Wishlist> teamLeadsWishlists, IEnumerable<Wishlist> juniorsWishlists)
        {
            return _strategy.BuildTeams(teamLeads, juniors, teamLeadsWishlists, juniorsWishlists);
        }

        public IEnumerable<Wishlist> GenerateRandomWishlists(IEnumerable<Employee> employees, IEnumerable<Employee> otherEmployees)
        {
            var random = new Random();
            var otherEmployeeIds = otherEmployees.Select(e => e.Id).ToArray();

            return employees.Select(e =>
            {
                var shuffledIds = otherEmployeeIds.OrderBy(_ => random.Next()).ToArray();
                return new Wishlist(e.Id, shuffledIds);
            });
        }
    }
}
