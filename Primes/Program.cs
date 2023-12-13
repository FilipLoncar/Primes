using System;

namespace Vsite.Pood
{
    static public class Primes
    {
        static void Main(string[] args)
        {
            OutputPrimes(0);
            OutputPrimes(1);
            OutputPrimes(2);
            OutputPrimes(10);
            OutputPrimes(100);
        }

        static void OutputPrimes(int maxValue)
        {
            Console.WriteLine("Prime numbers up to {0}:", maxValue);
            Console.ReadKey(true);
            var primeNumbers = GeneratePrimeNumbers(maxValue);
            if (primeNumbers.Length == 0)
            {
                Console.WriteLine("No primes");
            }
            else
            {
                foreach (var number in primeNumbers)
                {
                    Console.WriteLine(number);
                }
            }

            //Console.ReadLine();
        }

        //private static int s;
        //private static bool[] crossed;
        //private static int[] primes;

        // From the book "Agile Principles, Patterns and Practices in C#", by Robert C. Martin
        public static int[] GeneratePrimeNumbers(int maxValue)
        {
            if (maxValue < 2)
            {
                return new int[0];
            }

            var flags = GenerateArryOfFlags(maxValue);

            CrossOutMultiples(flags);

            return CollectUnCrossedIntegers(flags);

            //return primes; // return the primes
        }

        private static bool[] GenerateArryOfFlags(int maxValue)
        {
            // size of array
            //s = maxValue + 1;
            // flags for prime numbers
            var crossed = new bool[++maxValue];

            // initialize array to true
            for (int i = 2; i < crossed.Length; ++i)
            {
                crossed[i] = false;
            }

            // get rid of known non-primes 0 and 1
            //f[0] = f[1] = false;

            return crossed;
        }

        private static void CrossOutMultiples(bool[] crossed)
        {
            for (int i = 2; i < CalcLargestCommonFactor(crossed.Length); ++i)
            {
                if (NotCrossed(crossed,i)) // if i is uncrossed, cross its multiples (multiples are not primes)
                {
                    CrossOutMultiplesOf(crossed,i);

                }
            }
        }

        private static int CalcLargestCommonFactor( int i) {

            var commonFactor = Math.Sqrt(i) + 1;
            return (int)commonFactor;
        }

        private static bool NotCrossed(bool[] crossed, int i)
        {
            return !crossed[i];
        }

        private static void CrossOutMultiplesOf(bool[] crossed, int i)
        {
            for (int j = 2 * i; j < crossed.Length; j += i)
            {
                crossed[j] = true; // multiple is not a prime
            }
        }

        private static int[] CollectUnCrossedIntegers(bool[] crossed)
        {
           // int count = GetNumberOfUncrossed();

            var primes = new List<int>(); // int[count];

            // move primes into the result
            for (int i = 2; i < crossed.Length; ++i)
            {
                if (NotCrossed(crossed,i))
                {
                    primes.Add(i);// [j++] = i;
                }

            }
            return primes.ToArray<int>();
        }

        //private static int GetNumberOfUncrossed()
        //{
        //    int count = 0;
        //    for (int i = 2; i < crossed.Length; ++i)
        //    {
        //        if (NotCrossed(i))
        //        {
        //            ++count;
        //        }

        //    }

        //    return count;
        //}
    }
}