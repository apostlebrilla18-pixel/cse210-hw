using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    /// <summary>
    /// Runs the menu and manages the list of goals and the player's score.
    /// The goals and score are private; Program.cs only calls Start().
    /// </summary>
    public class GoalManager
    {
        private List<Goal> _goals;
        private int _score;

        private const int PointsPerLevel = 1000;
        private static readonly string[] LevelTitles =
        {
            "Seeker", "Apprentice", "Disciple", "Pathfinder", "Guardian", "Champion", "Legend"
        };

        public GoalManager()
        {
            _goals = new List<Goal>();
            _score = 0;
        }

        public void Start()
        {
            bool keepRunning = true;

            while (keepRunning)
            {
                Console.WriteLine();
                DisplayPlayerInfo();
                Console.WriteLine();
                Console.WriteLine("Menu Options:");
                Console.WriteLine("  1. Create New Goal");
                Console.WriteLine("  2. List Goals");
                Console.WriteLine("  3. Save Goals");
                Console.WriteLine("  4. Load Goals");
                Console.WriteLine("  5. Record Event");
                Console.WriteLine("  6. Quit");
                Console.Write("Select a choice from the menu: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1": CreateGoal(); break;
                    case "2": ListGoalDetails(); break;
                    case "3": SaveGoals(); break;
                    case "4": LoadGoals(); break;
                    case "5": RecordEvent(); break;
                    case "6": keepRunning = false; break;
                    default: Console.WriteLine("That's not a valid option."); break;
                }
            }
        }

        private void DisplayPlayerInfo()
        {
            Console.WriteLine($"You have {_score} points.");
            Console.WriteLine($"Level {GetLevel()}: {GetLevelTitle()}  ({PointsToNextLevel()} points to next level)");
        }

        private int GetLevel()
        {
            return (_score / PointsPerLevel) + 1;
        }

        private string GetLevelTitle()
        {
            int index = Math.Min(GetLevel() - 1, LevelTitles.Length - 1);
            return LevelTitles[index];
        }

        private int PointsToNextLevel()
        {
            return PointsPerLevel - (_score % PointsPerLevel);
        }

        private void ListGoalNames()
        {
            Console.WriteLine("The goals are:");
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
            }
        }

        private void ListGoalDetails()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("You have no goals yet.");
                return;
            }

            Console.WriteLine("The goals are:");
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
            }
        }

        private void CreateGoal()
        {
            Console.WriteLine("The types of Goals are:");
            Console.WriteLine("  1. Simple Goal");
            Console.WriteLine("  2. Eternal Goal");
            Console.WriteLine("  3. Checklist Goal");
            Console.Write("Which type of goal would you like to create? ");
            string type = Console.ReadLine();

            if (type != "1" && type != "2" && type != "3")
            {
                Console.WriteLine("That's not a valid goal type.");
                return;
            }

            string name = AskText("What is the name of your goal? ");
            string description = AskText("What is a short description of it? ");
            int points = AskNumber("What is the amount of points associated with this goal? ");

            if (type == "1")
            {
                _goals.Add(new SimpleGoal(name, description, points));
            }
            else if (type == "2")
            {
                _goals.Add(new EternalGoal(name, description, points));
            }
            else
            {
                int target = AskNumber("How many times does this goal need to be accomplished for a bonus? ");
                int bonus = AskNumber("What is the bonus for accomplishing it that many times? ");
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
            }

            Console.WriteLine("Goal created!");
        }

        private void RecordEvent()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("You have no goals yet. Create one first.");
                return;
            }

            ListGoalNames();
            int number = AskNumber("Which goal did you accomplish? ");

            if (number < 1 || number > _goals.Count)
            {
                Console.WriteLine("That's not a valid goal number.");
                return;
            }

            Goal goal = _goals[number - 1];
            int levelBefore = GetLevel();
            int earned = goal.RecordEvent();

            if (earned == 0)
            {
                Console.WriteLine("That goal is already complete, so no points were earned.");
                return;
            }

            _score += earned;
            Console.WriteLine($"Congratulations! You have earned {earned} points!");
            Console.WriteLine($"You now have {_score} points.");

            if (GetLevel() > levelBefore)
            {
                Console.WriteLine($"*** LEVEL UP! You are now Level {GetLevel()}: {GetLevelTitle()}! ***");
            }
        }

        private void SaveGoals()
        {
            Console.Write("What is the filename for the goal file? ");
            string filename = Console.ReadLine();

            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine(_score);
                foreach (Goal goal in _goals)
                {
                    writer.WriteLine(goal.GetStringRepresentation());
                }
            }

            Console.WriteLine($"Saved {_goals.Count} goals to {filename}.");
        }

        private void LoadGoals()
        {
            Console.Write("What is the filename for the goal file? ");
            string filename = Console.ReadLine();

            if (!File.Exists(filename))
            {
                Console.WriteLine($"Could not find a file named {filename}.");
                return;
            }

            string[] lines = File.ReadAllLines(filename);
            List<Goal> loadedGoals = new List<Goal>();
            int loadedScore;

            if (lines.Length == 0 || !int.TryParse(lines[0], out loadedScore))
            {
                Console.WriteLine("That file is not a valid goal file.");
                return;
            }

            for (int i = 1; i < lines.Length; i++)
            {
                Goal goal = ParseGoal(lines[i]);
                if (goal != null)
                {
                    loadedGoals.Add(goal);
                }
            }

            _score = loadedScore;
            _goals = loadedGoals;
            Console.WriteLine($"Loaded {_goals.Count} goals. Score: {_score}.");
        }

        // Rebuilds a goal from one saved line. Returns null if the line is malformed.
        private Goal ParseGoal(string line)
        {
            try
            {
                int colon = line.IndexOf(':');
                string type = line.Substring(0, colon);
                string[] parts = line.Substring(colon + 1).Split('|');

                if (type == "SimpleGoal")
                {
                    return new SimpleGoal(parts[0], parts[1], int.Parse(parts[2]), bool.Parse(parts[3]));
                }
                if (type == "EternalGoal")
                {
                    return new EternalGoal(parts[0], parts[1], int.Parse(parts[2]));
                }
                if (type == "ChecklistGoal")
                {
                    return new ChecklistGoal(parts[0], parts[1], int.Parse(parts[2]),
                        int.Parse(parts[4]), int.Parse(parts[3]), int.Parse(parts[5]));
                }
            }
            catch (Exception)
            {
                // Fall through and skip a line that can't be read.
            }

            return null;
        }

        // The "|" character separates fields in the save file, so swap it out of typed text.
        private string AskText(string question)
        {
            Console.Write(question);
            string text = Console.ReadLine();
            return text.Replace('|', '/');
        }

        private int AskNumber(string question)
        {
            int number;
            while (true)
            {
                Console.Write(question);
                if (int.TryParse(Console.ReadLine(), out number) && number >= 0)
                {
                    return number;
                }
                Console.WriteLine("Please enter a whole number (0 or higher).");
            }
        }
    }
}
