using System;

public abstract class Goal
{
    // Protected variables allow derived classes to access them directly
    protected string _shortName;
    protected string _description;
    protected string _points;

    public Goal(string name, string description, string points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    // Abstract methods enforce a strict contract: derived classes MUST implement these.
    public abstract void RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetStringRepresentation();

    // Virtual methods provide a robust default implementation that CAN be overridden if necessary.
    public virtual string GetDetailsString()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkbox} {_shortName} ({_description})";
    }

    // A getter to safely access the name from the GoalManager
    public string GetName()
    {
        return _shortName;
    }
}