using System;

namespace ExerciseTracking
{
    /// <summary>
    /// A lap-pool swimming activity. The number of laps is recorded
    /// (each lap is 50 meters); distance, speed and pace are calculated.
    /// </summary>
    public class Swimming : Activity
    {
        private int _laps;

        public Swimming(DateTime date, int minutes, int laps)
            : base(date, minutes)
        {
            _laps = laps;
        }

        public override double GetDistance()
        {
            // laps * 50 meters = km, then km to miles.
            return _laps * 50 / 1000.0 * 0.62;
        }

        public override double GetSpeed()
        {
            return (GetDistance() / GetMinutes()) * 60;
        }

        public override double GetPace()
        {
            return GetMinutes() / GetDistance();
        }
    }
}
