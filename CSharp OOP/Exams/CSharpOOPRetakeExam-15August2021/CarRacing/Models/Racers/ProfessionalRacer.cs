using CarRacing.Models.Cars.Contracts;

namespace CarRacing.Models.Racers
{
    public class ProfessionalRacer : Racer
    {
        private const string RacingBehavior = "strict";
        private const int Experience = 30;

        public ProfessionalRacer(string username, ICar car) 
            : base(username, RacingBehavior, Experience, car)
        {
        }

        public override void Race()
        {
            base.Race();
            this.DrivingExperience += 10;
        }
    }
}
