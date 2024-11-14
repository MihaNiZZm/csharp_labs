namespace HackathonApp
{
    public class HarmonyCalculator
    {
        private readonly SatisfactionCalculator _satisfactionCalculator;

        public HarmonyCalculator(SatisfactionCalculator satisfactionCalculator)
        {
            _satisfactionCalculator = satisfactionCalculator;
        }

        public double CalculateHarmony(IEnumerable<Team> teams,
            IEnumerable<Wishlist> teamLeadsWishlists, IEnumerable<Wishlist> juniorsWishlists)
        {
            double totalSatisfaction = 0;
            double participants = teams.Count() * 2;

            foreach (var team in teams)
            {
                var leadSatisfaction = _satisfactionCalculator
                    .CalculateSatisfaction(teamLeadsWishlists.First(w => w.EmployeeId == team.Teamlead.Id), team.Junior.Id);
                var juniorSatisfaction = _satisfactionCalculator
                    .CalculateSatisfaction(juniorsWishlists.First(w => w.EmployeeId == team.Junior.Id), team.Teamlead.Id);

                totalSatisfaction += 1f / leadSatisfaction + 1f / juniorSatisfaction;
            }

            return participants / totalSatisfaction;
        }
    }
    
}
