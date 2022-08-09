using System;
using System.Collections.Generic;
using System.Linq;
using FootballTeamGenerator.Exceptions;
using FootballTeamGenerator.Models;

namespace FootballTeamGenerator.Core
{
    public class Engine
    {
        private List<Team> teams;

        public Engine()
        {
            teams = new List<Team>();
        }

        public void Run()
        {
            string line = Console.ReadLine();

            while (line != "END")
            {
                try
                {
                    string[] parts = line
                        .Split(';', StringSplitOptions.RemoveEmptyEntries);

                    string command = parts[0];
                    string teamName = parts[1];

                    Team team = null;

                    if (command == "Team")
                    {
                        team = new Team(teamName);
                        teams.Add(team);
                    }

                    else if (command == "Add")
                    {
                        ValidateTeamName(teamName);

                        string playerName = parts[2];
                        int endurance = int.Parse(parts[3]);
                        int sprint = int.Parse(parts[4]);
                        int dribble = int.Parse(parts[5]);
                        int passing = int.Parse(parts[6]);
                        int shooting = int.Parse(parts[7]);

                        Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);

                        var take = teams.FirstOrDefault(x => x.Name == teamName);

                        take.AddPlayer(player);
                    }

                    else if (command == "Remove")
                    {
                        ValidateTeamName(teamName);

                        string playerName = parts[2];

                        var take = teams.FirstOrDefault(x => x.Name == teamName);

                        take.RemovePlayer(playerName);
                    }

                    else if (command == "Rating")
                    {
                        ValidateTeamName(teamName);

                        var takeTeam = this.teams.FirstOrDefault(x => x.Name == teamName);

                        Console.WriteLine(takeTeam);
                    }
                }
                catch (Exception ae)
                {
                    Console.WriteLine(ae.Message);
                }

                line = Console.ReadLine();
            }
        }

        private void ValidateTeamName(string name)
        {
            var team = teams.FirstOrDefault(x => x.Name == name);

            if (team == null)
            {
                throw new ArgumentException
                    (string.Format(ExceptionMessages.InvalidTeamNameException, name));
            }
        }
    }
}
