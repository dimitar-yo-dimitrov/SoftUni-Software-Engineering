using System;
using System.Collections.Generic;
using System.Linq;
using MilitaryElite.Models;

namespace MilitaryElite
{
    public class Engine
    {
        private List<Soldier> soldiers;

        public void Run()
        {
            string input;

            soldiers = new List<Soldier>();

            while ((input = Console.ReadLine()) != "End")
            {
                var tokens = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string type = tokens[0];

                switch (type)
                {
                    case nameof(Private):
                        AddPrivate(tokens);
                        break;

                    case nameof(LieutenantGeneral):
                        AddLieutenantGeneral(tokens);
                        break;

                    case nameof(Engineer):
                        AddEngineer(tokens);
                        break;

                    case nameof(Commando):
                        AddCommando(tokens);
                        break;

                    case nameof(Spy):
                        AddSpy(tokens);
                        break;
                }
            }

            soldiers.ForEach(Console.WriteLine);
        }

        private void AddPrivate(string[] tokens)
        {
            var id = tokens[1];
            var firstName = tokens[2];
            var lastName = tokens[3];
            var salary = decimal.Parse(tokens[4]);

            Private @private = new Private(id, firstName, lastName, salary);

            soldiers.Add(@private);
        }

        private void AddLieutenantGeneral(string[] tokens)
        {
            var id = tokens[1];
            var firstName = tokens[2];
            var lastName = tokens[3];
            var salary = decimal.Parse(tokens[4]);

            var lieutenant = new LieutenantGeneral(id, firstName, lastName, salary);

            List<string> privates = tokens.Skip(5).ToList();

            while (privates.Any())
            {
                Private currentPrivate = (Private)soldiers
                    .FirstOrDefault(x => x.Id == privates[0]);

                if (currentPrivate != null)
                {
                    lieutenant.Privates.Add(currentPrivate);
                }

                privates.RemoveAt(0);
            }

            soldiers.Add(lieutenant);
        }

        private void AddEngineer(string[] tokens)
        {
            try
            {
                var id = tokens[1];
                var firstName = tokens[2];
                var lastName = tokens[3];
                var salary = decimal.Parse(tokens[4]);
                var corps = tokens[5];
                
                List<string> repairs = tokens.Skip(6).ToList();

                var engineer = new Engineer(id, firstName, lastName, salary, corps);

                while (repairs.Any())
                {
                    string repairName = repairs[0];
                    int repairTime = int.Parse(repairs[1]);

                    Repair currentRepair = new Repair(repairName, repairTime);
                    engineer.Repairs.Add(currentRepair);

                    repairs.RemoveRange(0, 2);
                }

                soldiers.Add(engineer);
            }
            catch (ArgumentException ex)
            {
            }
        }

        private void AddCommando(string[] tokens)
        {
            var id = tokens[1];
            var firstName = tokens[2];
            var lastName = tokens[3];
            var salary = decimal.Parse(tokens[4]);
            var corps = tokens[5];

            List<string> missions = tokens.Skip(6).ToList();

            var commando = new Commando(id, firstName, lastName, salary, corps);

            while (missions.Any())
            {
                try
                {
                    var missionCodeName = missions[0];
                    var missionState = missions[1];

                    Mission mission = new Mission(missionCodeName, missionState);

                    commando.Missions.Add(mission);
                }
                catch (ArgumentException ex)
                {
                }

                missions.RemoveRange(0, 2);
            }

            soldiers.Add(commando);
        }

        private void AddSpy(string[] tokens)
        {
            var id = tokens[1];
            var firstName = tokens[2];
            var lastName = tokens[3];
            var codeNumber = int.Parse(tokens[4]);

            Spy spy = new Spy(id, firstName, lastName, codeNumber);

            soldiers.Add(spy);
        }
    }
}