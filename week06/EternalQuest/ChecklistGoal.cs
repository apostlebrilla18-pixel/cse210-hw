namespace EternalQuest
{
    /// <summary>
    /// A goal that must be accomplished a set number of times. Each event
    /// earns points, and the final one also earns a bonus.
    /// </summary>
    public class ChecklistGoal : Goal
    {
        private int _amountCompleted;
        private int _target;
        private int _bonus;

        public ChecklistGoal(string shortName, string description, int points, int target, int bonus)
            : base(shortName, description, points)
        {
            _amountCompleted = 0;
            _target = target;
            _bonus = bonus;
        }

        // Used when loading a saved goal, where the saved progress is restored.
        public ChecklistGoal(string shortName, string description, int points, int target, int bonus, int amountCompleted)
            : base(shortName, description, points)
        {
            _amountCompleted = amountCompleted;
            _target = target;
            _bonus = bonus;
        }

        public override int RecordEvent()
        {
            if (IsComplete())
            {
                return 0;
            }

            _amountCompleted++;

            if (IsComplete())
            {
                return GetPoints() + _bonus;
            }

            return GetPoints();
        }

        public override bool IsComplete()
        {
            return _amountCompleted >= _target;
        }

        // The only goal that overrides the default: it also shows progress.
        public override string GetDetailsString()
        {
            return $"{base.GetDetailsString()} -- Currently completed: {_amountCompleted}/{_target}";
        }

        public override string GetStringRepresentation()
        {
            return $"ChecklistGoal:{GetShortName()}|{GetDescription()}|{GetPoints()}|{_bonus}|{_target}|{_amountCompleted}";
        }
    }
}
