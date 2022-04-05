using System;

namespace Hw1.Exercise4
{
    /// <summary>
    /// Array statistics application core.
    /// </summary>
    public class ArrayStatApplication
    {
        /// <summary>
        /// Runs array statistics application.
        /// Prints statistics.
        /// </summary>
        /// <param name="args">
        /// Arguments - integer array.
        /// </param>
        /// <returns>Returns : 
        /// <c>0</c> in case of success; 
        /// <c>-1</c> in case of invalid <paramref name="args"/>.
        /// </returns>
        public int Run(string[] args)
        {
            if (args != null && args.Length > 0)
            {
                var array = new int[args.Length];

                for (var i = 0; i < args.Length; i++)
                {
                    var parsing = int.TryParse(args[i], out array[i]);

                    if (!parsing)
                    {
                        return -1;
                    }
                }

                Console.WriteLine("{0}={1}", "Min", MinValue(array));
                Console.WriteLine("{0}={1}", "Max", MaxValue(array));
                Console.WriteLine("{0}={1}", "Sum", ArraySum(array));
                Console.WriteLine("{0}={1}", "Average", ArrayAverage(array));
                Console.WriteLine("{0}={1}", "Count", array.Length);
                Array.Sort(array);
                Console.Write("{0}={1}", "Sorted", string.Join("; ", array));

                return 0;

            }

            return -1;

        }

        public static int MinValue(int[] array)
        {
            var minValue = array[0];

            for (var i = 0; i < array.Length; i++)
            {
                if (minValue > array[i])
                {
                    minValue = array[i];
                }
            }
            return minValue;
        }

        public static int MaxValue(int[] array)
        {
            var maxValue = array[0];

            for (var i = 0; i < array.Length; i++)
            {
                if (maxValue < array[i])
                {
                    maxValue = array[i];
                }
            }
            return maxValue;
        }

        public static int ArraySum(int[] array)
        {
            var arraySum = 0;

            for (var i = 0; i < array.Length; i++)
            {
                arraySum += array[i];
            }
            return arraySum;
        }

        public static double ArrayAverage(int[] array)
        {
            var arraySum = 0;

            for (var i = 0; i < array.Length; i++)
            {
                arraySum += array[i];
            }
            var arrayAverage = (double)arraySum / array.Length;
            return arrayAverage;
        }
    }
}
