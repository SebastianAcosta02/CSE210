using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private List<string> _prompts = new List<string>
    {
        "What small accomplishment am I proud of today?",
        "Who helped me today, and how did it make a difference?",
        "What is something new I learned today?",
        "When did I feel peaceful or grateful today?",
        "What challenge did I face today, and how did I respond?",
        "What ordinary moment would I like to remember?",
        "What did I do today that reflects the person I want to become?",
        "What is one kind thing I can do for someone tomorrow?"
    };

    private Random _random = new Random();

    public string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }
}
