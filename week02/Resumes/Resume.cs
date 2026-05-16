using System;
using System.Collections.Generic;

public class Resume
{
    // Member variables
    public string _name;
    
    // Initializing the list immediately to avoid NullReferenceExceptions
    public List<Job> _jobs = new List<Job>();

    // Method to display the entire resume
    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");

        // Iterating through each job and reusing the Job class's Display method
        foreach (Job job in _jobs)
        {
            job.Display();
        }
    }
}