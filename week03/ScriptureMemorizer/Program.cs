using System;
using System.Collections.Generic;

// EXCEEDING REQUIREMENTS:
// 1. Program selects a random scripture from a loaded library of multiple scriptures.
// 2. The HideRandomWords method inside Scripture.cs ensures it only attempts to hide words that are not already hidden.

class Program
{
    static void Main(string[] args)
    {
        // Setup a library of scriptures to pull from
        List<Scripture> library = new List<Scripture>
        {
            new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all thine heart and lean not unto thine own understanding."),
            new Scripture(new Reference("John", 3, 16), "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."),
            new Scripture(new Reference("Moroni", 10, 4, 5), "And when ye shall receive these things, I would exhort you that ye would ask God, the Eternal Father, in the name of Christ, if these things are not true...")
        };

        // Pick a random scripture
        Random random = new Random();
        int index = random.Next(library.Count);
        Scripture selectedScripture = library[index];

        while (true)
        {
            Console.Clear();
            Console.WriteLine(selectedScripture.GetDisplayText());
            Console.WriteLine();

            // Check if we should end the program because all words are hidden
            if (selectedScripture.IsCompletelyHidden())
            {
                break;
            }

            Console.WriteLine("Press enter to continue or type 'quit' to finish:");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            // Hide 3 random words per cycle
            selectedScripture.HideRandomWords(3);
        }
    }
}