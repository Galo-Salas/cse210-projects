using System;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, string points) : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        int pointsEarned = int.Parse(_points);
        Console.WriteLine($"Consistency is key. You have earned {pointsEarned} points for your progression.");
        return pointsEarned;
    }

    public override bool IsComplete()
    {
        return false; 
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{_shortName},{_description},{_points}";
    }
}