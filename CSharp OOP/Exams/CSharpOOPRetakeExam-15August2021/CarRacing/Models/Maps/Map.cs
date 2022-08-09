using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return string.Format(OutputMessages.RaceCannotBeCompleted);
            }

            if (!racerOne.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }

            if (!racerTwo.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }

            racerOne.Race();
            racerTwo.Race();
            
            double chanceOfWinningRacerOne = racerOne.Car.HorsePower * racerOne.DrivingExperience;

            double chanceOfWinningRacerTwo = racerTwo.Car.HorsePower * racerTwo.DrivingExperience;

            if (racerOne.RacingBehavior == "strict" || racerTwo.RacingBehavior == "strict")
            {
                chanceOfWinningRacerOne *= 1.2;
                chanceOfWinningRacerTwo *= 1.2;
            }
            else
            {
                chanceOfWinningRacerOne *= 1.1;
                chanceOfWinningRacerTwo *= 1.1;
            }

            var winner = 
                chanceOfWinningRacerOne > chanceOfWinningRacerTwo ? racerOne.Username : racerTwo.Username;

            return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, winner);
        }
    }
}
