namespace Sieve;

public interface ISieve
{
    long NthPrime(long n);
}

public class SieveImplementation : ISieve
{
    private readonly List<long> primes = new();
    static readonly int MAX_SIZE = 200000000;
    public SieveImplementation()
    {
        List<bool> isPrime = Enumerable.Repeat(true, MAX_SIZE).ToList();

        int i = 2;

        while (i * i < MAX_SIZE)
        {
            if (isPrime[i])
            {
                int j = i * i;
                while (j < MAX_SIZE)
                {
                    isPrime[j] = false;
                    j += i;
                }
            }
            i++;
        }
        for (int p = 2; p < MAX_SIZE; p++)
        {
            if (isPrime[p])
            {
                primes.Add(p);
            }
        }
    }
    public long NthPrime(long n)
    {
        return primes[(int)n];
    }
}