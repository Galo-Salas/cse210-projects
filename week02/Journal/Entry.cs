using System;

public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;
    public string _category; // Exceeding requirements feature

    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Category: [{_category}]");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Response: {_entryText}\n");
    }
}