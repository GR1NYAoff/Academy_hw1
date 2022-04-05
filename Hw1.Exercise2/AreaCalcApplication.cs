using System;
using System.Globalization;

namespace Hw1.Exercise2
{
    /// <summary>
    /// Area calc application core.
    /// </summary>
    public class AreaCalcApplication
    {
        /// <summary>
        /// Runs area calc application.
        /// Prints area of selected shape (from <paramref name="args"/>) to the output.
        /// </summary>
        /// <param name="args">
        /// Arguments - shape with dimensions.
        /// args[0] - shape [Circle, Square, Rect, Triangle].
        /// args[0..2] - shape dimensions.
        /// </param>
        /// <returns>Returns : 
        /// <c>0</c> in case of success; 
        /// <c>-1</c> in case of invalid <paramref name="args"/>;
        /// <c>-2</c> in case of invalid dimensions.
        /// </returns>
        public int Run(string[] args)
        {
            if (args != null && args.Length >= 2)
            {
                var shape = args[0].ToLowerInvariant();
                var res1 = double.TryParse(args[1].Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out var param1);
                if (param1 < 0)
                {
                    return -2;
                }
                var res2 = false;
                var res3 = false;
                double param2 = -1;
                double param3 = -1;

                if (args.Length >= 3)
                {
                    res2 = double.TryParse(args[2].Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out param2);
                    if (!res2)
                    {
                        return -1;
                    }
                    else if (param2 < 0)
                    {
                        return -2;
                    }
                }
                if (args.Length >= 4)
                {
                    res3 = double.TryParse(args[3].Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out param3);
                    if (!res3)
                    {
                        return -1;
                    }
                    else if (param3 < 0)
                    {
                        return -2;
                    }
                }

                if (shape != null && res1)
                {
                    if (shape == "circle")
                    {
                        var area = Math.PI * Math.Pow(param1, 2);
                        Console.Write(area);
                        return 0;
                    }
                    else if (shape == "square")
                    {
                        var area = Math.Pow(param1, 2);
                        Console.Write(area);
                        return 0;
                    }
                    else if (shape == "rect")
                    {
                        if (!res2)
                        {
                            return -1;
                        }
                        var area = param1 * param2;
                        Console.Write(area);
                        return 0;
                    }
                    else if (shape == "triangle" && !res3)
                    {
                        if (!res2)
                        {
                            return -1;
                        }
                        var area = 0.5 * (param1 * param2);
                        Console.Write(area);
                        return 0;
                    }
                    else if (shape == "triangle")
                    {
                        if (!res2 || !res3)
                        {
                            return -1;
                        }
                        else if (param1 + param2 <= param3 || param2 + param3 <= param1)
                        {
                            return -2;
                        }
                        var p = 0.5 * (param1 + param2 + param3);
                        var area = Math.Sqrt(p * (p - param1) * (p - param2) * (p - param3));
                        Console.Write(area);
                        return 0;
                    }
                    else
                    {
                        return -1;
                    }

                }
                return -1;

            }
            return -1;

        }
    }
}
