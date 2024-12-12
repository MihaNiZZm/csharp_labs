namespace HackathonApp
{
    public interface IHrDirector
    {
        public int CalculateTeamsSatisfaction(Wishlist wishlist, int selectedId);
        public double CalculateOverallTeamsHarmony(
            IEnumerable<Team> teams,
            IEnumerable<Wishlist> teamLeadsWishlists,
            IEnumerable<Wishlist> juniorsWishlists
        );
    }
}
