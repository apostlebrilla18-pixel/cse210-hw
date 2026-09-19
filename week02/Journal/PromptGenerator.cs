using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private readonly List<string> _prompts;
    private readonly Random _random;

    public PromptGenerator()
    {
        _random = new Random();
        _prompts = new List<string>
        {
            "What was the best part of your day?",
            "What was a challenge you faced today?",
            "What are you grateful for right now?",
            "What did you learn today?",
            "How did you show kindness today?"
        };
    }

    public string GetRandomPrompt()
    {
        if (_prompts.Count == 0)
        {
            return "Write about your day.";
        }

        return _prompts[_random.Next(_prompts.Count)];
    }
}