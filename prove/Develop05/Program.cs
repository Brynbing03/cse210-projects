using System;
using System.Collections.Generic;
using System.IO;

// goal is an abstract class
// the next three fields are protected so that the child classes can access them 
abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;

    // these are constructors for name, description and points
    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }
    // abstract - it must be implemented in each derived class
    // the last one, getpoints is a virtual method meaning it can be overridden but not required
    public abstract void RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetStatusString();
    public abstract string GetSaveString();
    public virtual int GetPoints() => _points;
}

// this simple goal inherets from goal
class SimpleGoal : Goal
{
    private bool _isCompleted;

    // constructors calls base class constructor, then it is set at complete
    public SimpleGoal(string name, string description, int points, bool isCompleted = false)
        : base(name, description, points)
    {
        _isCompleted = isCompleted;
    }

    // once it is marked as complete, it can't be completed again
    public override void RecordEvent()
    {
        if (!_isCompleted)
            _isCompleted = true;
    }

    public override bool IsComplete() => _isCompleted;

    public override string GetStatusString()
    {
        string ascii = _isCompleted ? "✔️ Simple & Done!" : "🔲 Simple Goal!";
        return $"{ascii} [{(_isCompleted ? "X" : " ")}] {_name} ({_description})";
    }

    public override string GetSaveString() => $"SimpleGoal:{_name}|{_description}|{_points}|{_isCompleted}";
}

// the eternal goal class
class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points) { }

    // even if recorded as complete, it will never be marked as done because you know... it is eternal
    public override void RecordEvent() { }

    public override bool IsComplete() => false;

    public override string GetStatusString()
    {
        string ascii = "♾️ Eternal Quest!";
        return $"{ascii} [ ] {_name} ({_description})";
    }

    public override string GetSaveString() => $"EternalGoal:{_name}|{_description}|{_points}";
}

// this tracks how many times the goal needs to be completed and how many times it has been previously completed
class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int targetCount, int currentCount = 0, int bonus = 0)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _currentCount = currentCount;
        _bonus = bonus;
    }

    // this records progress only if it isn't complete yet
    public override void RecordEvent()
    {
        if (!IsComplete())
            _currentCount++;
    }

    public override bool IsComplete() => _currentCount >= _targetCount;

    public override int GetPoints()
    {
        return _points;
    }

    // this includes progress information in the status string and saves string
    public override string GetStatusString()
    {
        string ascii = _currentCount >= _targetCount ? "✅ Checklist Complete!" : "📋 Checklist Goal!";
        return $"{ascii} [{(_currentCount >= _targetCount ? "X" : " ")}] {_name} ({_description}) -- Completed {_currentCount}/{_targetCount}";
    }

    public override string GetSaveString()
        => $"ChecklistGoal:{_name}|{_description}|{_points}|{_targetCount}|{_currentCount}|{_bonus}";
}

// goal manager class
// this class manages a list of goals and the total score
class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    // this makes the user slelct the type of goal they want to set
    public void CreateGoal()
    {
        Console.WriteLine("Select goal type:");
        Console.WriteLine("1. Simple Goal\n2. Eternal Goal\n3. Checklist Goal");
        Console.Write("Enter choice: ");
        string choice = Console.ReadLine();

        // this gets common goal information
        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter goal description: ");
        string desc = Console.ReadLine();
        Console.Write("Enter point value: ");
        int pts = int.Parse(Console.ReadLine());

        // this creates and adds the desired typs of goal to the list
        switch (choice)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, desc, pts));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, desc, pts));
                break;
            case "3":
                Console.Write("Enter target count: ");
                int count = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points (required but unused in core version): ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, desc, pts, count, 0, bonus));
                break;
        }
    }

    // this displays each goal using their specific status string
    public void ListGoals()
    {
        Console.WriteLine("\nYour Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetStatusString()}");
        }
    }

    // this lets the user pick a goal to complete, it then records it and updates the score
    public void RecordEvent()
    {
        ListGoals();
        Console.Write("Which goal did you complete? ");
        int index = int.Parse(Console.ReadLine()) - 1;
        _goals[index].RecordEvent();
        int earned = _goals[index].GetPoints();
        Console.WriteLine($"You earned {earned} points!");
        _score += earned;
    }

    // this displays the users current score
    public void ShowScore()
    {
        Console.WriteLine($"\nYour current score is: {_score} points.\n");
    }

    // this saves the score and each goal to a certain file
    public void SaveGoals(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetSaveString());
            }
        }
    }

    // this reads the file, sets the score and loads goal objects based on their type
    public void LoadGoals(string filename)
    {
        _goals.Clear();
        string[] lines = File.ReadAllLines(filename);
        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(":");
            string[] data = parts[1].Split("|");
            switch (parts[0])
            {
                case "SimpleGoal":
                    _goals.Add(new SimpleGoal(data[0], data[1], int.Parse(data[2]), bool.Parse(data[3])));
                    break;
                case "EternalGoal":
                    _goals.Add(new EternalGoal(data[0], data[1], int.Parse(data[2])));
                    break;
                case "ChecklistGoal":
                    _goals.Add(new ChecklistGoal(data[0], data[1], int.Parse(data[2]), int.Parse(data[3]), int.Parse(data[4]), int.Parse(data[5])));
                    break;
            }
        }
    }
}

// this is the program class
// this is the entry point
// creates goalmanager
class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        string input;

        // this displays the menu and handles input
        do
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Show Score");
            Console.WriteLine("7. Quit");
            Console.Write("Choose an option: ");
            input = Console.ReadLine();

            // this loops it over and over again until the user quits
            switch (input)
            {
                case "1": manager.CreateGoal(); break;
                case "2": manager.ListGoals(); break;
                case "3":
                    Console.Write("Filename to save: ");
                    manager.SaveGoals(Console.ReadLine());
                    break;
                case "4":
                    Console.Write("Filename to load: ");
                    manager.LoadGoals(Console.ReadLine());
                    break;
                case "5": manager.RecordEvent(); break;
                case "6": manager.ShowScore(); break;
            }
        } while (input != "7");
    }
}
