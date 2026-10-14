namespace EternalQuest
{
    /// <summary>
    /// A goal that is never finished. Every time it is recorded, the user
    /// earns its points. It needs no member variables of its own: everything
    /// it uses is inherited from Goal.
    /// </summary>
    public class EternalGoal : Goal
    {
        public EternalGoal(string shortName, string description, int points)
            : base(shortName, description, points)
        {
        }

        public override int RecordEvent()
        {
            return GetPoints();
        }

        public override bool IsComplete()
        {
            return false;
        }

        public override string GetStringRepresentation()
        {
            return $"EternalGoal:{GetShortName()}|{GetDescription()}|{GetPoints()}";
        }
    }
}
