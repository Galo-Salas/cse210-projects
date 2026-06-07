using System;

class Program
{
    static void Main(string[] args)
    {
        // EXCEEDS REQUIREMENTS: Tracking activity
        int breathingCount = 0;
        int reflectionCount = 0;
        int listingCount = 0;

        string choice = "";

        while (choice != "4")
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflection activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity activity = new BreathingActivity();
                activity.Run();
                breathingCount++;
            }
            else if (choice == "2")
            {
                ReflectionActivity activity = new ReflectionActivity();
                activity.Run();
                reflectionCount++;
            }
            else if (choice == "3")
            {
                ListingActivity activity = new ListingActivity();
                activity.Run();
                listingCount++;
            }
        }

        Console.Clear();
        Console.WriteLine("Session Summary:");
        Console.WriteLine($"Breathing Activities Completed: {breathingCount}");
        Console.WriteLine($"Reflection Activities Completed: {reflectionCount}");
        Console.WriteLine($"Listing Activities Completed: {listingCount}");
        Console.WriteLine("\nThank you for taking time for your well-being today.");
    }
}