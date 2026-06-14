using System;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, string points) : base(name, description, points)
    {
        // Inherent default: a newly instantiated goal is never complete.
        _isComplete = false;
    }

    public override void RecordEvent()
    {
        _isComplete = true;
        Console.WriteLine($"Congratulations! You have earned {_points} points.");
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        // Serialization format: GoalType:Name,Description,Points,IsComplete
        return $"SimpleGoal:{_shortName},{_description},{_points},{_isComplete}";
    }
}