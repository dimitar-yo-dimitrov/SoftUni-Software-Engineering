using CarRacing.Models.Cars.Contracts;

namespace CarRacing.Models.Racers
{
    public class StreetRacer : Racer
    {
        private const string RacingBehavior = "aggressive";
        private const int Experience = 10;

        public StreetRacer(string username, ICar car) 
            : base(username, RacingBehavior, Experience, car)
        {
        }

        public override void Race()
        {
            base.Race();
            this.DrivingExperience += 5;
        }
    }
}
