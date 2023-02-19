namespace App.Core.Random
{
    public class UnityRandom : IRandom
    {
        public int Next(int minInclusive, int maxExclusive)
        {
            return UnityEngine.Random.Range(minInclusive, maxExclusive);
        }
    }
}