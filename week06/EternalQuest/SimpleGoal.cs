namespace EternalQuest
{
    /// <summary>
    /// A goal that is done once. Recording it earns its points and marks it complete.
    /// </summary>
    public class SimpleGoal : Goal
    {
        private bool _isComplete;

        // Used when creating a brand new goal: it always starts incomplete.
        public SimpleGoal(string shortName, string description, int points)
            : base(shortName, description, points)
        {
            _isComplete = false;
        }

        // Used when loading a saved goal, where the saved status is restored.
        public SimpleGoal(string shortName, string description, int points, bool isComplete)
            : base(shortName, description, points)
        {
            _isComplete = isComplete;
        }

        public override int RecordEvent()
        {
            if (_isComplete)
            {
                return 0;
            }

            _isComplete = true;
            return GetPoints();
        }

        public override bool IsComplete()
        {
            return _isComplete;
        }

        public override string GetStringRepresentation()
        {
            return $"SimpleGoal:{GetShortName()}|{GetDescription()}|{GetPoints()}|{_isComplete}";
        }
    }
}
