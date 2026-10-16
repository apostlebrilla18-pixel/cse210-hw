using System;
using System.Globalization;

namespace ExerciseTracking
{
    /// <summary>
    /// Base class for every kind of exercise. It holds the attributes all
    /// activities share (the date and the length in minutes) and declares,
    /// but does not implement, the calculations each kind of activity must
    /// provide in its own way.
    /// </summary>
    public abstract class Activity
    {
        private DateTime _date;
        private int _minutes;

        public Activity(DateTime date, int minutes)
        {
            _date = date;
            _minutes = minutes;
        }

        protected DateTime GetDate()
        {
            return _date;
        }

        protected int GetMinutes()
        {
            return _minutes;
        }

        // Distance in miles.
        public abstract double GetDistance();

        // Speed in miles per hour.
        public abstract double GetSpeed();

        // Pace in minutes per mile.
        public abstract double GetPace();

        /// <summary>
        /// Builds the summary for any activity by calling the overridden
        /// calculation methods. Because GetDistance(), GetSpeed() and
        /// GetPace() are polymorphic, this one method works for every
        /// derived class, so it is only written here in the base class.
        /// </summary>
        public virtual string GetSummary()
        {
            string date = _date.ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
            string type = GetType().Name;

            return string.Format(CultureInfo.InvariantCulture,
                "{0} {1} ({2} min) - Distance {3:0.0} miles, Speed {4:0.0} mph, Pace: {5:0.0} min per mile",
                date, type, _minutes, GetDistance(), GetSpeed(), GetPace());
        }
    }
}
