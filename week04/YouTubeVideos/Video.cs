using System;
using System.Collections.Generic;

public class Video
{
    public string Title { get; private set; }
    public string Author { get; private set; }
    public int LengthInSeconds { get; private set; }

    // The list is private; it cannot be arbitrarily modified from outside the class.
    private List<Comment> _comments;

    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
        _comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return _comments.Count;
    }

    public void DisplayVideoDetails()
    {
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {LengthInSeconds} seconds");
        Console.WriteLine($"Total Comments: {GetCommentCount()}");
        Console.WriteLine("Comments:");

        foreach (Comment comment in _comments)
        {
            comment.DisplayComment();
        }
        Console.WriteLine("--------------------------------------------------\n");
    }
}