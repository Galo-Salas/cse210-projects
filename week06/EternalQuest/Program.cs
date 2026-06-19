using System;

/* * EXCEEDING REQUIREMENTS:
 * To exceed the core requirements, I implemented a gamified Leveling/Ranking system. 
 * As the user accumulates points, their "Title" dynamically upgrades (e.g., from 
 * "Novice" to "Master of Discipline"). This provides immediate, rewarding feedback and 
 * encourages continuous progression across spiritual, social, physical, and intellectual goals.
 */

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}