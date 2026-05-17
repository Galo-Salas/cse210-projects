using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("\n[System: The journal is currently empty.]\n");
            return;
        }

        Console.WriteLine("\n--- Journal Entries ---");
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
        Console.WriteLine("-----------------------\n");
    }

    public void SaveToFile(string file)
    {
        Console.WriteLine($"Saving to {file}...");

        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                // Using ~|~ as a robust delimiter to prevent comma corruption
                outputFile.WriteLine($"{entry._date}~|~{entry._promptText}~|~{entry._entryText}~|~{entry._category}");
            }
        }
        Console.WriteLine($"[System: Journal successfully saved to {file}]\n");
    }

    public void LoadFromFile(string file)
    {
        Console.WriteLine($"Loading from {file}...");

        if (File.Exists(file))
        {
            _entries.Clear();
            string[] lines = System.IO.File.ReadAllLines(file);

            foreach (string line in lines)
            {
                string[] parts = line.Split("~|~");

                if (parts.Length == 4)
                {
                    Entry loadedEntry = new Entry();
                    loadedEntry._date = parts[0];
                    loadedEntry._promptText = parts[1];
                    loadedEntry._entryText = parts[2];
                    loadedEntry._category = parts[3];

                    _entries.Add(loadedEntry);
                }
            }
            Console.WriteLine("[System: Journal loaded successfully.]\n");
        }
        else
        {
            Console.WriteLine("[Error: File not found. Check your directory or filename.]\n");
        }
    }
}