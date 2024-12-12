namespace HackathonApp
{
    public interface IHrManager
    {
        public IEnumerable<Wishlist> GenerateRandomWishlists(
            IEnumerable<Employee> employees, 
            IEnumerable<Employee> otherEmployees
        );

        public IEnumerable<Team> BuildTeams(
            IEnumerable<Employee> teamLeads,
            IEnumerable<Employee> juniors,
            IEnumerable<Wishlist> teamLeadsWishlists,
            IEnumerable<Wishlist> juniorsWishlists
        );
    }
}
