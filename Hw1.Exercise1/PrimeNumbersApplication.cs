using System;

namespace Hw1.Exercise1
{
    /// <summary>
    /// Prime numbers application core.
    /// </summary>
    public class PrimeNumbersApplication
    {
        /// <summary>
        /// Runs prime numbers application.
        /// Prints prime numbers in the given range (from <paramref name="args"/>) to the output.
        /// </summary>
        /// <param name="args">
        /// Arguments - valid integer range [from, to] 
        /// between <see cref="int.MinValue"/> and <see cref="int.MaxValue"/>
        /// to find prime numbers.
        /// </param>
        /// <returns>Return <c>0</c> in case of success and <c>-1</c> in case of failure.</returns>
        public int Run(string[] args)
        {
            if (args != null && args[0].Length > 0)
            {

                var res1 = int.TryParse(args[0], out var firstValue);
                var res2 = int.TryParse(args[1], out var secondValue);

                if (res1 && res2)
                {

                    if (firstValue < secondValue)
                    {
                        for (var i = firstValue; i <= secondValue; i++)
                        {
                            if (IsPrimeNumber(i))
                            {
                                Console.Write($"{i};");
                            }
                        }
                        return 0;
                    }
                    else if (firstValue > secondValue)
                    {
                        for (var i = secondValue; i <= firstValue; i++)
                        {
                            if (IsPrimeNumber(i))
                            {
                                Console.Write($"{i};");
                            }
                        }
                        return 0;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            return -1;
        }

        public static bool IsPrimeNumber(int number)
        {
            if (number <= 1)
            {
                return false;
            }

            for (var i = 2; i <= number / 2; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
