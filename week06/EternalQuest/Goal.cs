namespace EternalQuest
{
    /// <summary>
    /// Base class for every kind of goal. It holds what all goals share
    /// (short name, description, points) and declares the behaviors that
    /// each derived class must provide in its own way.
    ///
    /// Polymorphism: GoalManager keeps every goal in one List&lt;Goal&gt; and
    /// calls RecordEvent(), IsComplete(), GetDetailsString() and
    /// GetStringRepresentation() without knowing which kind of goal it has.
    /// </summary>
    public abstract class Goal
    {
        private string _shortName;
        private string _description;
        private int _points;

        public Goal(string shortName, string description, int points)
        {
            _shortName = shortName;
            _description = description;
            _points = points;
        }

        public string GetShortName()
        {
            return _shortName;
        }

        public string GetDescription()
        {
            return _description;
        }

        public int GetPoints()
        {
            return _points;
        }

        /// <summary>
        /// Records that the goal was accomplished once and returns the
        /// number of points earned. Each kind of goal decides for itself
        /// how many points that is, so every derived class must implement it.
        /// </summary>
        public abstract int RecordEvent();

        /// <summary>
        /// True when the goal is finished.
        /// </summary>
        public abstract bool IsComplete();

        /// <summary>
        /// Text used when listing goals, e.g. "[ ] Read scriptures (Daily study)".
        /// This default is enough for most goals; only ChecklistGoal overrides it.
        /// </summary>
        public virtual string GetDetailsString()
        {
            string box = IsComplete() ? "[X]" : "[ ]";
            return $"{box} {_shortName} ({_description})";
        }

        /// <summary>
        /// Text used when saving the goal to a file.
        /// </summary>
        public abstract string GetStringRepresentation();
    }
}
