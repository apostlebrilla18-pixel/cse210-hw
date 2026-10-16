using System;

namespace ExerciseTracking
{
    /// <summary>
    /// A stationary-bike activity. The speed is recorded; distance and pace are calculated.
    /// </summary>
    public class Cycling : Activity
    {
        private double _speed;

        public Cycling(DateTime date, int minutes, double speed)
            : base(date, minutes)
        {
            _speed = speed;
        }

        public override double GetDistance()
        {
            return (_speed * GetMinutes()) / 60;
        }

        public override double GetSpeed()
        {
            return _speed;
        }

        public override double GetPace()
        {
            return 60 / _speed;
        }
    }
}
