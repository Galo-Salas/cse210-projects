using System;

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, string points, int target, int bonus) : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    public override int RecordEvent()
    {
        _amountCompleted++;
        int standardPoints = int.Parse(_points);
        
        if (IsComplete())
        {
            Console.WriteLine($"Target reached! You earned {standardPoints} standard points and a massive bonus of {_bonus} points!");
            return standardPoints + _bonus;
        }
        else
        {
            Console.WriteLine($"Progress recorded. You earned {standardPoints} points. Keep pushing.");
            return standardPoints;
        }
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        return $"{base.GetDetailsString()} -- Currently completed: {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{_shortName},{_description},{_points},{_bonus},{_target},{_amountCompleted}";
    }
    
    // A specific method to restore the exact state when loading from a file
    public void SetAmountCompleted(int amount)
    {
        _amountCompleted = amount;
    }
}