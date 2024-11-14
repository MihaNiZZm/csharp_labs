namespace HackathonApp
{
    public class SatisfactionCalculator
    {
        public int CalculateSatisfaction(Wishlist wishlist, int selectedId)
        {
            var position = Array.IndexOf(wishlist.DesiredEmployees, selectedId);
            return 20 - position;
        }
    }
}
