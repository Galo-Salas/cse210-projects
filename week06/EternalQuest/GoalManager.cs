using System;
using System.Collections.Generic;
using System.IO;

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
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
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
        string title = "Novice";

        if (_score >= 2000)
        {
            title = "Master of Discipline";
        }
        else if (_score >= 1000)
        {
            title = "High-Performer";
        }
        else if (_score >= 500)
        {
            title = "Dedicated Disciple";
        }

        Console.WriteLine($"\n*** Current Rank: {title} ***");
        Console.WriteLine($"You have {_score} points.\n");
    }

    public void ListGoalNames()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        
        string type = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        
        Console.Write("What is the amount of points associated with this goal? ");
        string points = Console.ReadLine();

        if (type == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (type == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (type == "3")
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());
            
            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());
            
            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
        else
        {
            Console.WriteLine("Invalid selection. Goal creation aborted.");
        }
    }

    public void RecordEvent()
    {
        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        
        if (int.TryParse(Console.ReadLine(), out int input) && input > 0 && input <= _goals.Count)
        {
            int goalIndex = input - 1;
            
            // The polymorphic call now securely returns the correct integer value
            int pointsEarned = _goals[goalIndex].RecordEvent();
            _score += pointsEarned;
        }
        else
        {
            Console.WriteLine("Invalid goal selection.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved successfully.");
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            
            _score = int.Parse(lines[0]);
            _goals.Clear();

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(':');
                string goalType = parts[0];
                string[] details = parts[1].Split(',');

                if (goalType == "SimpleGoal")
                {
                    SimpleGoal simpleGoal = new SimpleGoal(details[0], details[1], details[2]);
                    if (bool.Parse(details[3]))
                    {
                        // To prevent adding points during load, we just set internal state 
                        // but since _isComplete is private, we will record event and subtract points back
                        // A cleaner C1-level fix is to not record it, but just know it's finished.
                        simpleGoal.RecordEvent();
                        _score -= int.Parse(details[2]); // offset the points added by RecordEvent during load
                    }
                    _goals.Add(simpleGoal);
                }
                else if (goalType == "EternalGoal")
                {
                    _goals.Add(new EternalGoal(details[0], details[1], details[2]));
                }
                else if (goalType == "ChecklistGoal")
                {
                    ChecklistGoal checklistGoal = new ChecklistGoal(details[0], details[1], details[2], int.Parse(details[4]), int.Parse(details[3]));
                    checklistGoal.SetAmountCompleted(int.Parse(details[5]));
                    _goals.Add(checklistGoal);
                }
            }
            Console.WriteLine("Goals loaded successfully.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}