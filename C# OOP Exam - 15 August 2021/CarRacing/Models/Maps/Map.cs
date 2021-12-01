namespace CarRacing.Models.Maps
{
    using CarRacing.Models.Maps.Contracts;
    using CarRacing.Models.Racers.Contracts;

    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!AreBothPlayersAvailabe(racerOne, racerTwo))
            {
                var possibleWinner = FindAutomaticWinner(racerOne, racerTwo);

                if (!possibleWinner.IsAvailable())
                {
                    return "Race cannot be completed because both racers are not available!";
                }
                else
                {
                    var loser = possibleWinner == racerOne ? racerOne : racerTwo;

                    return $"{possibleWinner.Username} wins the race! {loser.Username} was not available to race!";
                }
            }

            return Race(racerOne, racerTwo);
        }

        private bool AreBothPlayersAvailabe(IRacer racerOne, IRacer racerTwo)
        {
            return racerOne.IsAvailable() && racerTwo.IsAvailable();
        }

        private IRacer FindAutomaticWinner(IRacer racerOne, IRacer racerTwo)
        {
            if (racerOne.IsAvailable())
            {
                return racerOne;
            }

            return racerTwo;
        }

        private double CalculateChanceOfWinning(IRacer racer)
        {
            double racingBehaviourNumericalValue = racer.RacingBehavior == "strict" ? 1.2 : 1.1;

            return racer.Car.HorsePower * racer.DrivingExperience * racingBehaviourNumericalValue;
        }

        private string Race(IRacer racerOne, IRacer racerTwo)
        {
            double pOnechanceOfWinning = CalculateChanceOfWinning(racerOne);
            double pTwochanceOfWinning = CalculateChanceOfWinning(racerTwo);

            racerOne.Race();
            racerTwo.Race();

            if (pOnechanceOfWinning > pTwochanceOfWinning)
            {
                return $"{racerOne.Username} has just raced against {racerTwo.Username}! {racerOne.Username} is the winner!";
            }

            return $"{racerTwo.Username} has just raced against {racerOne.Username}! {racerTwo.Username} is the winner!";
        }
    }
}
