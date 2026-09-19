using System;

namespace JournalProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Journal journal = new Journal();
            PromptGenerator promptGenerator = new PromptGenerator();
            bool keepRunning = true;

            Console.WriteLine("Welcome to your Journal!");

            while (keepRunning)
            {
                ShowMenu();
                string choice = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(choice))
                {
                    Console.WriteLine("Please enter a valid option.");
                    Console.WriteLine();
                    continue;
                }

                choice = choice.Trim();

                switch (choice)
                {
                    case "1":
                        WriteNewEntry(journal, promptGenerator);
                        break;
                    case "2":
                        journal.DisplayAll();
                        break;
                    case "3":
                        SaveJournal(journal);
                        break;
                    case "4":
                        LoadJournal(journal);
                        break;
                    case "5":
                        keepRunning = false;
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("That's not a valid option. Please choose 1-5.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("Journal Menu");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
        }

        static void WriteNewEntry(Journal journal, PromptGenerator promptGenerator)
        {
            string prompt = promptGenerator.GetRandomPrompt();
            Console.WriteLine(prompt);
            Console.Write("Your response: ");
            string response = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(response))
            {
                Console.WriteLine("Entry cannot be empty.");
                return;
            }

            Entry entry = new Entry(prompt, response.Trim());
            journal.AddEntry(entry);

            Console.WriteLine("Entry saved!");
        }

        static void SaveJournal(Journal journal)
        {
            Console.Write("Enter a filename to save to: ");
            string filename = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(filename))
            {
                Console.WriteLine("Filename cannot be empty.");
                return;
            }

            journal.SaveToFile(filename.Trim());
        }

        static void LoadJournal(Journal journal)
        {
            Console.Write("Enter a filename to load from: ");
            string filename = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(filename))
            {
                Console.WriteLine("Filename cannot be empty.");
                return;
            }

            journal.LoadFromFile(filename.Trim());
        }
    }
}