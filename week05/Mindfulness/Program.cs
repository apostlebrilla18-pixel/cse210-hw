using System;

namespace Mindfulness
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool keepRunning = true;

            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("Menu Options:");
                Console.WriteLine("  1. Start breathing activity");
                Console.WriteLine("  2. Start reflecting activity");
                Console.WriteLine("  3. Start listing activity");
                Console.WriteLine("  4. Quit");
                Console.Write("Select a choice from the menu: ");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.Run();
                }
                else if (choice == "2")
                {
                    ReflectingActivity reflecting = new ReflectingActivity();
                    reflecting.Run();
                }
                else if (choice == "3")
                {
                    ListingActivity listing = new ListingActivity();
                    listing.Run();
                }
                else if (choice == "4")
                {
                    keepRunning = false;
                }
            }
        }
    }
}
