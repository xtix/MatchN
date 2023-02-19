namespace App.Core.Random
{
    public interface IRandom
    {
        int Next(int minInclusive, int maxExclusive);
    }
}