namespace HackathonApp
{
    public static class SatisfactionCalculator
    {
        public static int CalculateSatisfaction(Wishlist wishlist, int selectedId)
        {
            var position = Array.IndexOf(wishlist.DesiredEmployees, selectedId);
            return 20 - position;
        }
    }
}
