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
}