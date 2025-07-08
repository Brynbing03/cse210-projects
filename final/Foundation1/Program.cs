using System;
using System.Collections.Generic;

// this models a comment on haha a fake video
class Comment
{
    public string CommenterName { get; }
    public string CommentText { get; }

    public Comment(string name, string text)
    {
        CommenterName = name;
        CommentText = text;
    }
}

// this represents a youtube video and stores its bumpin comments 
class Video
{
    public string Title { get; }
    public string Author { get; }
    public int Length { get; }
    private List<Comment> comments;

    // the constructors
    // creates an empty list to store the comments for a video
    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        comments = new List<Comment>();
    }

    // this takes a comment object and adds it to the internal comments list
    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    // this returns the total number of comments on the said video
    public int GetNumberOfComments()
    {
        return comments.Count;
    }

    // this returns the actual list of comments 
    // this allows other code to loop through them
    public List<Comment> GetComments()
    {
        return comments;
    }

    // this prints all the video stuff like the title, author, length and how many comments for each video
    // it then loops through each comment and prints the name of the person who left a comment and what that comment was
    // I added some blank lines too for visual spacing
    public void DisplayVideoInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {Length} seconds");
        Console.WriteLine($"Number of Comments: {GetNumberOfComments()}");

        foreach (Comment c in comments)
        {
            Console.WriteLine($"- {c.CommenterName}: {c.CommentText}");
        }

        Console.WriteLine();
    }
}

// this is the main program! this is where it all starts...
class Program
{
    static void Main(string[] args)
    {
        // I created a list that stores all my pretty good video objects
        List<Video> videos = new List<Video>();

        // haha I am kind of pround of these fake youtube videos and comments!!!! Bahahahaha! I hope you love them! 

        Video v1 = new Video("Being a toddler for a day!", "Nugget Nathan", 342);
        v1.AddComment(new Comment("Mr. Snooze", "I tried it and I peaked at nap time! zzzzzz"));
        v1.AddComment(new Comment("Bitey", "I loved this 100%."));
        v1.AddComment(new Comment("Sticky Ricky", "I vibe with this so much... "));
        v1.AddComment(new Comment("Boogie Oogie", "I do this everyday!"));
        videos.Add(v1);

        Video v2 = new Video("How to swim like a mermaid!", "Oceanna", 726);
        v2.AddComment(new Comment("Finley", "My new favorite thing!"));
        v2.AddComment(new Comment("Pearl", "Can't wait to try this literally tonight in the hot tub."));
        v2.AddComment(new Comment("Waverly", "Just go with the waves, truely."));
        videos.Add(v2);

        Video v3 = new Video("Funny baby FAILS", "Parent Life", 478);
        v3.AddComment(new Comment("Kimmy", "#MiniMeltdown2.0"));
        v3.AddComment(new Comment("Earl", "Baby vs. Gravity and... GRAVITY WINS."));
        v3.AddComment(new Comment("Andrew", "Oops, I pooped again... diaper disaster!"));
        videos.Add(v3);

        // this displays all of the videos
        // it loops through the video list
        // then it prints all the videos details and that videos comments
        foreach (Video v in videos)
        {
            v.DisplayVideoInfo();
        }
    }
}
