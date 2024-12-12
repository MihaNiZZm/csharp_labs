
namespace HackathonApp
{
    public class HrDirector : IHrDirector
    {
        private readonly IHarmonyCalculator _calculator;

        public HrDirector(IHarmonyCalculator calculator)
        {
            _calculator = calculator;
        }

        public double CalculateOverallTeamsHarmony(
            IEnumerable<Team> teams,
            IEnumerable<Wishlist> teamLeadsWishlists, 
            IEnumerable<Wishlist> juniorsWishlists
        )
        {
            List<int> satisfactions = new List<int>();

            foreach (var team in teams)
            {
                var leadSatisfaction = CalculateTeamsSatisfaction(
                    teamLeadsWishlists.First(w => w.EmployeeId == team.Teamlead.Id), 
                    team.Junior.Id
                );
                satisfactions.Add(leadSatisfaction);

                var juniorSatisfaction = CalculateTeamsSatisfaction(
                    juniorsWishlists.First(w => w.EmployeeId == team.Junior.Id), 
                    team.Teamlead.Id
                );
                satisfactions.Add(juniorSatisfaction);
            }

            return _calculator.СalculateTotalHarmony(satisfactions);
        }

        public int CalculateTeamsSatisfaction(Wishlist wishlist, int selectedId)
        {
            var position = Array.IndexOf(wishlist.DesiredEmployees, selectedId);
            return 20 - position;
        }
    }
}
