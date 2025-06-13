// using System;
// using System.Collections.Generic;
// using System.Threading;

// // this is the main start to the program
// class Program
// {
//     static void Main()
//     {
//         // this is a list of all the activities for the mindfulness program
//         List<Activity> activities = new()
//         {
//             new BreathingActivity(),
//             new ReflectionActivity(),
//             new ListingActivity()
//         };

//         while (true)
//         {
//             // this is the main menu loop, this is where the user will pick an activity haha or not and type quit
//             Console.Clear();
//             Console.WriteLine("Mindfulness Program Menu:");
//             Console.WriteLine("1 - Breathing Activity");
//             Console.WriteLine("2 - Reflection Activity");
//             Console.WriteLine("3 - Listing Activity");
//             Console.WriteLine("4 - Quit");

//             // this will take what the user inputs and selelct the activity they want
//             Console.Write("Choose an activity: ");
//             string choice = Console.ReadLine();

//             // this is for when someone types quit and it says goodbye and exits the loop
//             if (choice == "4")
//             {
//                 Console.WriteLine("Thank you for choosing to use the Mindfulness Program.");
//                 break;
//             }
//             // this is what converts the user input into a number and then the loop can run the activity that the user wants
//             if (int.TryParse(choice, out int index) && index >= 1 && index <= 3)
//             {
//                 activities[index - 1].Run();
//             }
//             // this is what happens if the user inputs something that is not a number or is not in the list and it says... nope
//             else
//             {
//                 Console.WriteLine("Not a choice... Try again...");
//                 Console.ReadLine();
//             }
//         }
//     }
// }

// // BASE CLASS
// // this is all the shared attributes between wach different class
// // the constructor here sets the name and description
// class Activity
// {
//     protected string _name;
//     protected string _description;
//     protected int _duration;

//     public Activity(string name, string description)
//     {
//         _name = name;
//         _description = description;
//     }

//     // this says hey! to the user and then asks how long the activity should run and it shows a fun spinning spinner for loading
//     public void StartMessage()
//     {
//         Console.Clear();
//         Console.WriteLine($"--- {_name} ---");
//         Console.WriteLine(_description);
//         Console.Write("Enter duration in seconds: ");
//         _duration = int.Parse(Console.ReadLine());
//         Console.WriteLine("Prepare to start...");
//         ShowSpinner(3);
//     }

//     // this says good job for finishing the activity
//     public void EndMessage()
//     {
//         Console.WriteLine("\nGreat Job!");
//         ShowSpinner(2);
//         Console.WriteLine($"You have completed {_duration} seconds of the {_name}.");
//         ShowSpinner(3);
//     }

//     // this is the rotating spinner thing for loading, I had to get some help from chat to learn how to do this...
//     public void ShowSpinner(int seconds)
//     {
//         string[] spinner = { "|", "/", "-", "\\" };
//         DateTime endTime = DateTime.Now.AddSeconds(seconds);
//         int i = 0;
//         while (DateTime.Now < endTime)
//         {
//             Console.Write(spinner[i % spinner.Length]);
//             Thread.Sleep(200);
//             Console.Write("\b");
//             i++;
//         }
//     }

//     // this is the countdown till the activity starts
//     public void ShowCountdown(int seconds)
//     {
//         for (int i = seconds; i > 0; i--)
//         {
//             Console.Write($"{i} ");
//             Thread.Sleep(1000);
//             Console.Write("\b\b");
//         }
//     }

//     public virtual void Run() { }
// }

// // BREATHING ACTIVITY
// class BreathingActivity : Activity
// {
//     public BreathingActivity() : base("Breathing Activity",
//         "This activity will help you relax by walking you through some deep inhale and exhale breaths.") { }

//     // prompts the user and walks them through breathing in and out for a certain time
//     public override void Run()
//     {
//         StartMessage();
//         DateTime endTime = DateTime.Now.AddSeconds(_duration);
//         while (DateTime.Now < endTime)
//         {
//             Console.Write("Breathe in... ");
//             ShowCountdown(4);
//             Console.WriteLine();
//             Console.Write("Breathe out... ");
//             ShowCountdown(6);
//             Console.WriteLine();
//         }
//         EndMessage();
//     }
// }

// // REFLECTION ACTIVITY
// class ReflectionActivity : Activity
// {
//     // these two privates display a list of prompts and questions for the user to reflect
//     private List<string> _prompts = new()
//     {
//         "When was a time today that you did something really hard and what was it?",
//         "How and when were you able to serve someone today?",
//         "Was there a time today when you were able to stand up for someone else?",
//     };

//     private List<string> _questions = new()
//     {
//         "Why was this experience meaningful?",
//         "What did you learn from it?",
//         "How did you feel afterward?",
//         "How can you apply this experience in the future?"
//     };

//     // this sets the name and description through constructors
//     public ReflectionActivity() : base("Reflection Activity",
//         "This activity will help you reflect on times you have shown strength.")
//     { }

//     // this displays a rando refelction prompt and then it cycles through the questions and gives the user time to reflect and ponder
//     public override void Run()
//     {
//         StartMessage();
//         string prompt = _prompts[new Random().Next(_prompts.Count)];
//         Console.WriteLine($"\nPrompt: {prompt}");
//         ShowSpinner(3);

//         DateTime endTime = DateTime.Now.AddSeconds(_duration);
//         Random rand = new();
//         while (DateTime.Now < endTime)
//         {
//             string question = _questions[rand.Next(_questions.Count)];
//             Console.WriteLine($"\n> {question}");
//             ShowSpinner(5);
//         }

//         EndMessage();
//     }
// }

// // LISTING ACTIVITY
// class ListingActivity : Activity
// {
//     // this focuses on listing items
//     private List<string> _prompts = new()
//     {
//         "Who is someone that you are grateful for?",
//         "What is one of your strengths?",
//         "When was a time today that you felt pure happiness?",
//         "What are you grateful for today?"
//     };

//     public ListingActivity() : base("Listing Activity",
//         "This activity will help you reflect on the good things in your life by listing them.") { }

//     // this shows the prompt and a small count down then lets the user list as many things as they can durring the time given
//     public override void Run()
//     {
//         StartMessage();
//         string prompt = _prompts[new Random().Next(_prompts.Count)];
//         Console.WriteLine($"\nPrompt: {prompt}");
//         Console.WriteLine("You may begin listing in: ");
//         ShowCountdown(5);

//         List<string> items = new();
//         DateTime endTime = DateTime.Now.AddSeconds(_duration);
//         while (DateTime.Now < endTime)
//         {
//             Console.Write("> ");
//             items.Add(Console.ReadLine());
//         }

//         Console.WriteLine($"\nYou listed {items.Count} items.");
//         EndMessage();
//     }
// }

using System;
using System.Collections.Generic;
using System.Threading;

// this is the main start to the program
class Program
{
    static void Main()
    {
        // this is a list of all the activities for the mindfulness program
        List<Activity> activities = new()
        {
            new BreathingActivity(),
            new ReflectionActivity(),
            new ListingActivity()
        };

        while (true)
        {
            // this is the main menu loop, this is where the user will pick an activity haha or not and type quit
            Console.Clear();
            Console.WriteLine("Mindfulness Program Menu:");
            Console.WriteLine("1 - Breathing Activity");
            Console.WriteLine("2 - Reflection Activity");
            Console.WriteLine("3 - Listing Activity");
            Console.WriteLine("4 - Quit");

            // this will take what the user inputs and selelct the activity they want
            Console.Write("Choose an activity: ");
            string choice = Console.ReadLine();

            // this is for when someone types quit and it says goodbye and exits the loop
            if (choice == "4")
            {
                Console.WriteLine("Thank you for choosing to use the Mindfulness Program.");
                break;
            }

            // this is what converts the user input into a number and then the loop can run the activity that the user wants
            if (int.TryParse(choice, out int index) && index >= 1 && index <= 3)
            {
                activities[index - 1].Run();
            }
            // this is what happens if the user inputs something that is not a number or is not in the list and it says... nope
            else
            {
                Console.WriteLine("Not a choice... Try again...");
                Console.ReadLine();
            }
        }
    }
}

// BASE CLASS
class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void StartMessage()
    {
        Console.Clear();
        Console.WriteLine($"--- {_name} ---");
        Console.WriteLine(_description);
        Console.Write("Enter duration in seconds: ");
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to start...");
        ShowSpinner(3);
    }

    public void EndMessage()
    {
        Console.WriteLine("\nGreat Job!");
        ShowSpinner(2);
        Console.WriteLine($"You have completed {_duration} seconds of the {_name}.");
        ShowSpinner(3);
    }

    public void ShowSpinner(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int i = 0;
        while (DateTime.Now < endTime)
        {
            Console.Write(spinner[i % spinner.Length]);
            Thread.Sleep(200);
            Console.Write("\b");
            i++;
        }
    }

    public void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i} ");
            Thread.Sleep(1000);
            Console.Write("\b\b");
        }
    }

    public virtual void Run() { }
}

// BREATHING ACTIVITY
class BreathingActivity : Activity
{
    private string _art = @"
     ~ ~ ~ ~ ~ ~ ~ ~ ~
    (   inhale...    )
     ~ ~ ~ ~ ~ ~ ~ ~ ~
    (   exhale...    )
     ~ ~ ~ ~ ~ ~ ~ ~ ~
";

    public BreathingActivity() : base("Breathing Activity",
        "This activity will help you relax by walking you through some deep inhale and exhale breaths.") { }

    public override void Run()
    {
        StartMessage();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(_art);
        Console.ResetColor();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.Write("Breathe in... ");
            ShowCountdown(4);
            Console.WriteLine();
            Console.Write("Breathe out... ");
            ShowCountdown(6);
            Console.WriteLine();
        }
        EndMessage();
    }
}

// REFLECTION ACTIVITY
class ReflectionActivity : Activity
{
    private List<string> _prompts = new()
    {
        "When was a time today that you did something really hard and what was it?",
        "How and when were you able to serve someone today?",
        "Was there a time today when you were able to stand up for someone else?",
    };

    private List<string> _questions = new()
    {
        "Why was this experience meaningful?",
        "What did you learn from it?",
        "How did you feel afterward?",
        "How can you apply this experience in the future?"
    };

    private string _art = @"
   .-''''-.
  /        \
 |  THINK!  |
  \        /
   '-....-'
";

    public ReflectionActivity() : base("Reflection Activity",
        "This activity will help you reflect on times you have shown strength.") { }

    public override void Run()
    {
        StartMessage();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(_art);
        Console.ResetColor();

        string prompt = _prompts[new Random().Next(_prompts.Count)];
        Console.WriteLine($"\nPrompt: {prompt}");
        ShowSpinner(3);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        Random rand = new();
        while (DateTime.Now < endTime)
        {
            string question = _questions[rand.Next(_questions.Count)];
            Console.WriteLine($"\n> {question}");
            ShowSpinner(5);
        }

        EndMessage();
    }
}

// LISTING ACTIVITY
class ListingActivity : Activity
{
    private List<string> _prompts = new()
    {
        "Who is someone that you are grateful for?",
        "What is one of your strengths?",
        "When was a time today that you felt pure happiness?",
        "What are you grateful for today?"
    };

    private string _art = @"
  ___________
 |  TO-DO 📋  |
 |___________|
 |           |
 |  > Item   |
 |  > Item   |
 |___________|
";

    public ListingActivity() : base("Listing Activity",
        "This activity will help you reflect on the good things in your life by listing them.") { }

    public override void Run()
    {
        StartMessage();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(_art);
        Console.ResetColor();

        string prompt = _prompts[new Random().Next(_prompts.Count)];
        Console.WriteLine($"\nPrompt: {prompt}");
        Console.WriteLine("You may begin listing in: ");
        ShowCountdown(5);

        List<string> items = new();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            items.Add(Console.ReadLine());
        }

        Console.WriteLine($"\nYou listed {items.Count} items.");
        EndMessage();
    }
}
