namespace HackathonApp
{
    public class HarmonyCalculator : IHarmonyCalculator
    {
        public double СalculateTotalHarmony(IEnumerable<int> satisfactions)
        {
            int size = satisfactions.Count();
            double sum = 0;

            foreach (var s in satisfactions)
            {
                sum += 1 / (double)s;
            }

            return size / sum;
        }
    }
    
}
