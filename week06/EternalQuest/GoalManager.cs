using System;
using System.Collections.Generic;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        bool isRunning = true;
        while (isRunning)
        {
            DisplayPlayerInfo();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // Call CreateGoal();
                    break;
                case "2":
                    // Call ListGoalDetails();
                    break;
                case "6":
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid selection. Please adhere to the menu options.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYou have {_score} points.\n");
    }

    // You will implement these methods next:
    // public void ListGoalNames() { ... }
    // public void ListGoalDetails() { ... }
    // public void CreateGoal() { ... }
    // public void RecordEvent() { ... }
    // public void SaveGoals() { ... }
    // public void LoadGoals() { ... }
}