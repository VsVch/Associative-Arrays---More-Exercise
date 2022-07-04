using System;
using System.Collections.Generic;
using System.Linq;

namespace P01._Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            string inpitFirst;
            Dictionary<string, string> contests = new Dictionary<string, string>();

            while ((inpitFirst = Console.ReadLine()) != "end of contests")
            {
                string[] inputFirstToArr = inpitFirst.Split(':');
                string contest = inputFirstToArr[0];
                string passwordForContest = inputFirstToArr[1];
                contests[contest] = passwordForContest;
            }
            Dictionary<string, Dictionary<string, int>> results = new Dictionary<string, Dictionary<string, int>>();
            string inputSecond;
            while ((inputSecond = Console.ReadLine())!= "end of submissions")
            {
                string[] inputSecondArr = inputSecond.Split("=>");
                string contest = inputSecondArr[0];
                string password = inputSecondArr[1];
                string username = inputSecondArr[2];
                int points = int.Parse(inputSecondArr[3]);
                if (contests.ContainsKey(contest) && contests[contest] == password)
                {
                    if (!results.ContainsKey(username))
                    {
                        results[username] = new Dictionary<string, int>();
                    }

                    if (results.ContainsKey(username) && !results[username].ContainsKey(contest))
                    {
                        results[username][contest] = 0;
                    }

                    if (results[username][contest] < points)
                    {
                        results[username][contest] = points;
                    }

                }

            }
            string winner = results.OrderBy(x => x.Value.Values.Sum()).Last().Key;
            int bestPoints = results.OrderBy(x => x.Value.Values.Sum()).Last().Value.Values.Sum();

            Console.WriteLine($"Best candidate is {winner} with total {bestPoints} points.");

            Console.WriteLine("Ranking:");

            foreach (var item in results.OrderBy(x => x.Key))
            {
                Console.WriteLine(item.Key);
                foreach (var contest in item.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }

        }
    }
}
