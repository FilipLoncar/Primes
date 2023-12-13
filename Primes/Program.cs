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
        private static bool[] crossed;
        private static int[] primes;

        // From the book "Agile Principles, Patterns and Practices in C#", by Robert C. Martin
        public static int[] GeneratePrimeNumbers(int maxValue)
        {
            if (maxValue < 2)
            {
                return new int[0];
            }

            GenerateArryOfFlags(maxValue);

            CrossOutMultiples();

            CollectUnCrossedIntegers();

            return primes; // return the primes
        }

        private static void GenerateArryOfFlags(int maxValue)
        {
            // size of array
            //s = maxValue + 1;
            // flags for prime numbers
            crossed = new bool[++maxValue];

            // initialize array to true
            for (int i = 2; i < crossed.Length; ++i)
            {
                crossed[i] = false;
            }

            // get rid of known non-primes 0 and 1
            //f[0] = f[1] = false;
        }

        private static void CrossOutMultiples()
        {
            for (int i = 2; i < Math.Sqrt(crossed.Length) + 1; ++i)
            {
                if (NotCrossed(i)) // if i is uncrossed, cross its multiples (multiples are not primes)
                {
                    for (int j = 2 * i; j < crossed.Length; j += i)
                    {
                        crossed[j] = true; // multiple is not a prime
                    }

                }
            }
        }

        private static bool NotCrossed(int i)
        {
            return !crossed[i];
        }

        private static void CollectUnCrossedIntegers()
        {
            int count = 0;
            for (int i = 2; i < crossed.Length; ++i)
            {
                if (NotCrossed(i))
                {
                    ++count;
                }
                    
            }

            primes = new int[count];

            // move primes into the result
            for (int i = 2, j = 0; i < crossed.Length; ++i)
            {
                if (NotCrossed(i))
                {
                    primes[j++] = i;
                }
                    
            }
        }

    }
}
