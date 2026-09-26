using System;
using System.Collections.Generic;

namespace ScriptureMemorizer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Scripture> library = BuildLibrary();
            Scripture scripture = GetRandomScripture(library);

            bool quit = false;
            while (!quit && !scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine();
                Console.Write("Press enter to continue or type 'quit' to end: ");

                string input = Console.ReadLine();
                if (string.Equals(input, "quit", StringComparison.OrdinalIgnoreCase))
                {
                    quit = true;
                }
                else
                {
                    scripture.HideRandomWords(3);
                }
            }

            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine();
                Console.WriteLine("Great job! The scripture is completely hidden.");
            }
        }

        private static Scripture GetRandomScripture(List<Scripture> library)
        {
            Random random = new Random();
            int index = random.Next(library.Count);
            return library[index];
        }

        private static List<Scripture> BuildLibrary()
        {
            List<Scripture> library = new List<Scripture>();

            library.Add(new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world that he gave his only begotten Son, " +
                "that whosoever believeth in him should not perish, but have everlasting life."));

            library.Add(new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart, and lean not unto thine own understanding. " +
                "In all thy ways acknowledge him, and he shall direct thy paths."));

            library.Add(new Scripture(
                new Reference("Philippians", 4, 13),
                "I can do all things through Christ which strengtheneth me."));

            library.Add(new Scripture(
                new Reference("Joshua", 1, 9),
                "Have not I commanded thee? Be strong and of a good courage; be not afraid, " +
                "neither be thou dismayed: for the Lord thy God is with thee whithersoever thou goest."));

            return library;
        }
    }
}