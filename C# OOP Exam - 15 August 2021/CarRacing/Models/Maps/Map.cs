namespace CarRacing.Models.Maps
{
    using CarRacing.Models.Maps.Contracts;
    using CarRacing.Models.Racers.Contracts;

    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (AreBothPlayersAvailabe(racerOne, racerTwo))
            {
                return Race(racerOne, racerTwo);
            }
            else
            {
                var winner = FindAutomaticWinner(racerOne, racerTwo);

                if (winner == null)
                {
                    return "Race cannot be completed because both racers are not available!";
                }
                else
                {
                    var loser = winner.Username == racerOne.Username ? racerTwo : racerOne;

                    return $"{winner.Username} wins the race! {loser.Username} was not available to race!";
                }
            }
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
            else if (racerTwo.IsAvailable())
            {
                return racerTwo;
            }

            return null;
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

            return $"{racerOne.Username} has just raced against {racerTwo.Username}! {racerTwo.Username} is the winner!";
        }
    }
}
