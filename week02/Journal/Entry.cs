using System;

public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;

    public Entry(string promptText, string entryText)
    {
        _date = DateTime.Now.ToString("yyyy-MM-dd");
        _promptText = promptText ?? "";
        _entryText = entryText ?? "";
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Entry: {_entryText}");
    }

    public string ToFileLine()
    {
        return $"{_date}|{_promptText}|{_entryText}";
    }

    public static Entry FromFileLine(string line)
    {
        if (string.IsNullOrWhiteSpace(line))
        {
            return null;
        }

        string[] parts = line.Split('|');

        if (parts.Length != 3)
        {
            return null;
        }

        Entry entry = new Entry(parts[1].Trim(), parts[2].Trim());
        entry._date = parts[0].Trim();
        return entry;
    }
}