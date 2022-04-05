using System;
using System.Globalization;

namespace Hw1.Exercise5
{
    /// <summary>
    /// Calc application core.
    /// </summary>
    public class CalcApplication
    {
        /// <summary>
        /// Runs calc application.
        /// Prints calculation result.
        /// </summary>
        /// <param name="args"> Math expression.</param>
        /// <returns>Returns : 
        /// <c>0</c> in case of success; 
        /// <c>-1</c> in case of invalid format of <paramref name="args"/>;
        /// <c>-2</c> in case of invalid math expression <paramref name="args"/>.
        /// </returns>
        public int Run(string[] args)
        {
            if (args != null && args.Length > 0 && args[0].Length > 0)
            {

                string raw = null;

                for (var i = 0; i < args.Length; i++)
                {
                    raw += string.Concat(args[i]);
                }

                if (RawValidation(raw) >= 3)
                {
                    return -1;
                }

                var space = " ";
                var indexOfFactorialChar = raw.LastIndexOf('!');
                var indexOfAdditionChar = raw.IndexOf('+');

                var subStringTransformation1 = "--";
#pragma warning disable CA1310 // Specify StringComparison for correctness
                var indexOfSubstringT1 = raw.IndexOf(subStringTransformation1); //-1
#pragma warning restore CA1310 // Specify StringComparison for correctness               

                if (indexOfSubstringT1 != -1)
                {
                    raw = raw.Insert(indexOfSubstringT1, space);
                    raw = raw.Insert(indexOfSubstringT1 + 2, space);
                }

                var indexOfMultiplicationChar = raw.IndexOfAny(new char[] { '*', 'x', 'X' });
                var indexOfSegmentationChar = raw.IndexOfAny(new char[] { '/', '\u005c' });
                var indexOfDegreeChar = raw.IndexOf('^');

                var values = raw.Split(new char[] { '+', '*', 'x', 'X', '/', '\u005c', '^', ' ', '!' }, StringSplitOptions.RemoveEmptyEntries);

                var indexOfSubstringSubtraction = values[0].IndexOf('-', 1);

                if (values.Length == 1 && indexOfFactorialChar == -1 && indexOfSubstringSubtraction == -1)
                {
                    var echoValid = double.TryParse(values[0].Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out var value);
                    if (echoValid)
                    {
                        _ = string.Join(' ', value);
                        Console.Write(values[0]);
                        return 0;
                    }
                    return -1;
                }
                else if (values.Length == 1 && indexOfFactorialChar == -1 && indexOfSubstringSubtraction != -1)
                {
                    var newValues = raw.Split("-");
                    var firstValueValid = double.TryParse(newValues[0].Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out var value1);
                    var secondValueValid = double.TryParse(newValues[1].Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out var value2);
                    if (firstValueValid && secondValueValid)
                    {
                        Console.Write(value1 - value2);
                        return 0;
                    }
                    return -1;

                }
                else if (values.Length == 1 && indexOfFactorialChar != -1)
                {
                    var factorialValid = int.TryParse(values[0], NumberStyles.Any, CultureInfo.InvariantCulture, out var value);
                    if (factorialValid)
                    {
                        if (value is not (>= 0 and <= 18))
                        {
                            return -2;
                        }
                        var result = Factorial(value);
                        Console.Write(result);
                        return 0;
                    }
                    return -2;

                }
                else if (values.Length > 1 && indexOfAdditionChar != -1 && values.Length < 3)
                {
                    var firstValueValid = double.TryParse(values[0].Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out var value1);
                    var secondValueValid = double.TryParse(values[1].Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out var value2);
                    if (firstValueValid && secondValueValid)
                    {
                        Console.Write(value1 + value2);
                        return 0;
                    }
                    return -1;
                }
                else if (values.Length > 1 && indexOfSubstringT1 != -1 && values.Length <= 3)
                {
                    var firstValueValid = double.TryParse(values[0].Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out var value1);
                    var secondValueValid = double.TryParse(values[2].Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out var value2);
                    if (firstValueValid && secondValueValid)
                    {
                        Console.Write(value1 - value2);
                        return 0;
                    }
                    return -1;
                }
                else if (values.Length > 1 && indexOfMultiplicationChar != -1 && values.Length < 3)
                {
                    var firstValueValid = double.TryParse(values[0].Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out var value1);
                    var secondValueValid = double.TryParse(values[1].Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out var value2);
                    if (firstValueValid && secondValueValid)
                    {
                        Console.Write(value1 * value2);
                        return 0;
                    }
                    return -1;
                }
                else if (values.Length > 1 && indexOfSegmentationChar != -1 && values.Length < 3)
                {
                    var firstValueValid = double.TryParse(values[0].Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out var value1);
                    var secondValueValid = double.TryParse(values[1].Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out var value2);
                    if (firstValueValid && secondValueValid)
                    {
                        if (value2 == 0)
                        {
                            return -2;
                        }
                        Console.Write(value1 / value2);
                        return 0;
                    }
                    return -1;
                }
                else if (values.Length > 1 && indexOfDegreeChar != -1 && values.Length < 3)
                {
                    var firstValueValid = double.TryParse(values[0].Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out var value1);
                    var secondValueValid = double.TryParse(values[1].Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out var value2);
                    if (firstValueValid && secondValueValid)
                    {
                        if (value2 % 0.5 == 0 && value1 < 0)
                        {
                            return -2;
                        }
                        Console.Write(Math.Pow(value1, value2));
                        return 0;
                    }
                    return -1;
                }

            }
            return -1;
        }

        public long Factorial(int number)
        {
            long result = 1;
            if (number <= 0)
            {
                return result;
            }
            while (number != 1)
            {
                result *= number;
                number--;
            }
            return result;
        }
        public static int RawValidation(string raw)
        {
            var operations = new char[] { '+', '-', '*', 'x', 'X', '/', '\u005c', '^', '!' };
            int cnt1 = default;
            int cnt2 = default;
            for (var i = 1; i < raw.Length; i++)
            {
                for (var j = 0; j < operations.Length; j++)
                {
                    if (raw[i] == operations[j])
                    {
                        cnt1++;

                        if (j > 1)
                        {
                            cnt2++;
                            if (cnt2 >= 2)
                            {
                                return 3;
                            }
                        }
                        continue;
                    }

                }
            }
            return cnt1;
        }
    }
}
