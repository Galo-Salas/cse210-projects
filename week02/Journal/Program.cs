using System;

// EXCEEDING REQUIREMENTS: 
// 1. Implemented a custom delimiter (~|~) for saving/loading to prevent commas in user input from breaking the file parsing.
// 2. Added a "Category" system (Spiritual, Social, Physical, Intellectual) to turn the journal into a holistic accountability tracker.

class Program
{
    static void Main(string[] args)
    {
        Journal myJournal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        bool keepRunning = true;

        Console.WriteLine("Welcome to the High-Performance Journal!");

        while (keepRunning)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"\n{prompt}");
                    Console.Write("> ");
                    string response = Console.ReadLine();

                    Console.WriteLine("Categorize this entry (Spiritual, Social, Physical, Intellectual):");
                    Console.Write("> ");
                    string category = Console.ReadLine();

                    Entry newEntry = new Entry();
                    newEntry._date = DateTime.Now.ToShortDateString();
                    newEntry._promptText = prompt;
                    newEntry._entryText = response;
                    newEntry._category = category;

                    myJournal.AddEntry(newEntry);
                    Console.WriteLine("[System: Entry added successfully.]\n");
                    break;

                case "2":
                    myJournal.DisplayAll();
                    break;

                case "3":
                    Console.Write("What is the filename to load? ");
                    string loadFile = Console.ReadLine();
                    myJournal.LoadFromFile(loadFile);
                    break;

                case "4":
                    Console.Write("What is the filename to save? ");
                    string saveFile = Console.ReadLine();
                    myJournal.SaveToFile(saveFile);
                    break;

                case "5":
                    keepRunning = false;
                    Console.WriteLine("\nLogging off. Stay disciplined.");
                    break;

                default:
                    Console.WriteLine("\n[Error: Invalid input. Please select a number from 1 to 5.]\n");
                    break;
            }
        }
    }
}