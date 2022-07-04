using System;
using System.Collections.Generic;
using System.Linq;

namespace P02._Judge
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> dict = new Dictionary<string, Dictionary<string, int>>();

            var usersTotalPoint = new Dictionary<string, int>();

            while (true)
            {
                string text = Console.ReadLine();

                if (text == "no more time"){break;}
                else
                {
                    string[] info = text.Split(" -> ");

                    string username = info[0];
                    string contest = info[1];
                    int points = int.Parse(info[2]);
                    bool itMustSum = false;

                    if (!dict.ContainsKey(contest))
                    {
                        dict[contest] = new Dictionary<string, int>();
                        dict[contest][username] = points;
                        itMustSum = true;
                    }
                    else
                    {
                        if (!dict[contest].ContainsKey(username))
                        {
                            dict[contest][username] = points;
                            itMustSum = true;
                        }
                        else
                        {
                            int currentPoints = dict[contest][username];

                            if (currentPoints < points)
                            {
                                dict[contest][username] = points;
                                points = points - currentPoints;
                                itMustSum = true;
                            }
                        }
                    }

                    if (!usersTotalPoint.ContainsKey(username))
                    {
                        usersTotalPoint[username] = 0;
                    }
                    
                    if (itMustSum)
                    {
                        usersTotalPoint[username] += points;
                    }

                }
            }

            foreach (var kvp in dict)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value.Count()} participants");

                int counter = 1;

                foreach (var item in kvp.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{counter}. {item.Key} <::> {item.Value}");
                    counter++;
                }
            }

            Console.WriteLine($"Individual standings:");

            int counterForUsers = 1;

            foreach (var kvp in usersTotalPoint.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{counterForUsers}. {kvp.Key} -> {kvp.Value}");
                counterForUsers++;
            }
        }
    }
}
