using System;
using System.Globalization;

namespace Hw1.Exercise3
{
    /// <summary>
    /// 'Rock-Paper-Scissors' game application core.
    /// </summary>
    public class GameApplication
    {
        /// <summary>
        /// Runs game application.
        /// Prints game results.
        /// </summary>
        /// <param name="args">
        /// Arguments - player's shape.
        /// args[0] - shape [Rock, Paper, Scissors].
        /// </param>
        /// <returns>Returns : 
        /// <c>0</c> in case of success; 
        /// <c>-1</c> in case of invalid <paramref name="args"/>.
        /// </returns>
        public int Run(string[] args)
        {
            if (args != null && args.Length > 0)
            {
                var playerChoose = args[0].ToLowerInvariant();
                var myTI = new CultureInfo("en-US", false).TextInfo;

                if (playerChoose is "rock" or "scissors" or "paper")
                {
                    playerChoose = myTI.ToTitleCase(playerChoose);
                    var computerChoose = RandomChoose();
                    string result;

                    if (playerChoose.Equals(computerChoose, StringComparison.OrdinalIgnoreCase))
                    {
                        result = "Draw";

                        Console.WriteLine("{0}={1}:{2}", "Player", playerChoose, result);
                        Console.Write("{0}={1}:{2}", "Computer", computerChoose, result);

                        return 0;
                    }
                    else if (playerChoose == "Rock")
                    {
                        result = computerChoose == "Scissors" ? "Win" : "Lose";

                        Console.WriteLine("{0}={1}:{2}", "Player", playerChoose, result);
                        result = result == "Win" ? "Lose" : "Win";
                        Console.Write("{0}={1}:{2}", "Computer", computerChoose, result);

                        return 0;
                    }
                    else if (playerChoose == "Scissors")
                    {
                        result = computerChoose == "Paper" ? "Win" : "Lose";

                        Console.WriteLine("{0}={1}:{2}", "Player", playerChoose, result);
                        result = result == "Win" ? "Lose" : "Win";
                        Console.Write("{0}={1}:{2}", "Computer", computerChoose, result);

                        return 0;
                    }
                    else
                    {
                        result = computerChoose == "Rock" ? "Win" : "Lose";
                        Console.WriteLine("{0}={1}:{2}", "Player", playerChoose, result);
                        result = result == "Win" ? "Lose" : "Win";
                        Console.Write("{0}={1}:{2}", "Computer", computerChoose, result);

                        return 0;
                    }
                }
                return -1;
            }

            return -1;
        }
        private static string RandomChoose()
        {
            var rnd = new Random();
            var random = rnd.Next(0, 3);
            var result = random == 1 ? "Rock" : random == 2 ? "Scissors" : "Paper";

            return result;
        }

    }
}
