using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            var contestData = new Dictionary<string, string>();

            var line = Console.ReadLine();

            while (line != "end of contests")
            {
                var parts = line
                    .Split(":", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string contest = parts[0];
                string password = parts[1];

                if (!contestData.ContainsKey(contest))
                {
                    contestData.Add(contest, password);
                }

                line = Console.ReadLine();
            }

            line = Console.ReadLine();

            var usersData = new Dictionary<string, Dictionary<string, int>>();

            while (line != "end of submissions")
            {
                var parts = line
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string contest = parts[0];
                string password = parts[1];
                string userName = parts[2];
                int points = int.Parse(parts[3]);

                if (contestData.ContainsKey(contest) && contestData[contest] == password)
                {
                    if (!usersData.ContainsKey(userName))
                    {
                        usersData.Add(userName, new Dictionary<string, int>());
                    }

                    if (!usersData[userName].ContainsKey(contest))
                    {
                        usersData[userName][contest] = points;
                    }

                    if (usersData[userName][contest] < points)
                    {
                        usersData[userName][contest] = points;
                    }
                }

                line = Console.ReadLine();
            }

            string bestStudent = string.Empty;
            int topSum = int.MinValue;

            foreach (var user in usersData)
            {
                var studentsPoints = 0;

                foreach (var point in user.Value)
                {
                    studentsPoints += point.Value;
                }

                if (studentsPoints > topSum)
                {
                    topSum = studentsPoints;
                    bestStudent = user.Key;
                }
            }

            Console.WriteLine($"Best candidate is {bestStudent} with total {topSum} points.");
            Console.WriteLine("Ranking:");

            foreach (var user in usersData.OrderBy(u => u.Key))
            {
                Console.WriteLine(user.Key);

                foreach (var contest in user.Value.OrderByDescending(c => c.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
