using System;
using System.Collections.Generic;
using System.IO;

namespace JournalProgram
{
    public class Journal
    {
        private List<Entry> _entries;

        public Journal()
        {
            _entries = new List<Entry>();
        }

        public void AddEntry(Entry entry)
        {
            if (entry == null)
            {
                Console.WriteLine("Entry cannot be null.");
                return;
            }

            _entries.Add(entry);
        }

        public void DisplayAll()
        {
            if (_entries.Count == 0)
            {
                Console.WriteLine("The journal is empty.");
                return;
            }

            foreach (Entry entry in _entries)
            {
                entry.Display();
                Console.WriteLine(new string('-', 40));
            }
        }

        public void SaveToFile(string filename)
        {
            if (string.IsNullOrWhiteSpace(filename))
            {
                Console.WriteLine("Filename cannot be empty.");
                return;
            }

            try
            {
                List<string> lines = new List<string>();

                foreach (Entry entry in _entries)
                {
                    lines.Add(entry.ToFileLine());
                }

                File.WriteAllLines(filename, lines);
                Console.WriteLine($"Journal saved to {filename}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to save journal: {ex.Message}");
            }
        }

        public void LoadFromFile(string filename)
        {
            if (string.IsNullOrWhiteSpace(filename))
            {
                Console.WriteLine("Filename cannot be empty.");
                return;
            }

            if (!File.Exists(filename))
            {
                Console.WriteLine($"Could not find a file named {filename}.");
                return;
            }

            try
            {
                List<Entry> loadedEntries = new List<Entry>();

                foreach (string line in File.ReadAllLines(filename))
                {
                    Entry loadedEntry = Entry.FromFileLine(line);
                    if (loadedEntry != null)
                    {
                        loadedEntries.Add(loadedEntry);
                    }
                }

                _entries = loadedEntries;
                Console.WriteLine($"Journal loaded from {filename}. ({_entries.Count} entries)");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to load journal: {ex.Message}");
            }
        }
    }
}