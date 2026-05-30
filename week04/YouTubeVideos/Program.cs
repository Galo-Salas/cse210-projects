using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // 1. Initialize the list to store our videos
        List<Video> videoRoster = new List<Video>();

        // 2. Create Video 1 and its comments
        Video video1 = new Video("C# Fundamentals: Abstraction", "Tech Guru", 845);
        video1.AddComment(new Comment("Alice", "This clarified the concept perfectly, thank you!"));
        video1.AddComment(new Comment("Bob", "Could you do a follow-up on polymorphism?"));
        video1.AddComment(new Comment("Charlie", "The audio was a bit low, but great content."));
        videoRoster.Add(video1);

        // 3. Create Video 2 and its comments
        Video video2 = new Video("Effective Time Management for Students", "Study Smart", 1200);
        video2.AddComment(new Comment("David", "Implementing these routines tomorrow."));
        video2.AddComment(new Comment("Elena", "The Pomodoro technique changed my life."));
        video2.AddComment(new Comment("Frank", "Great advice for balancing work and studies."));
        videoRoster.Add(video2);

        // 4. Create Video 3 and its comments
        Video video3 = new Video("Daily Devotionals: Finding Peace", "Light Network", 600);
        video3.AddComment(new Comment("Grace", "Truly uplifting message today."));
        video3.AddComment(new Comment("Henry", "I needed to hear exactly this."));
        video3.AddComment(new Comment("Isabella", "Sharing this with my family."));
        video3.AddComment(new Comment("Jack", "Beautiful insights on maintaining faith."));
        videoRoster.Add(video3);

        // 5. Iterate through the roster and invoke the display method
        Console.WriteLine("=== YouTube Video Tracker Analysis ===\n");
        foreach (Video vid in videoRoster)
        {
            vid.DisplayVideoDetails();
        }
    }
}