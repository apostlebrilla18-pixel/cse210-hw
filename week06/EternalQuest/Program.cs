namespace EternalQuest
{
    // ---------------------------------------------------------------------
    // EXCEEDING REQUIREMENTS - what was added beyond the core assignment:
    //
    // 1. Leveling system (gamification): the player's score is turned into a
    //    level (every 1000 points) with a title such as "Seeker",
    //    "Apprentice" or "Champion". The level and the points needed for
    //    the next level are shown above the menu, and a LEVEL UP message
    //    appears when recording an event pushes the player into a new level.
    // 2. Input validation: numeric questions re-ask until a valid whole
    //    number is entered, and loading rejects missing or invalid files
    //    instead of crashing.
    // ---------------------------------------------------------------------

    public class Program
    {
        public static void Main(string[] args)
        {
            GoalManager manager = new GoalManager();
            manager.Start();
        }
    }
}