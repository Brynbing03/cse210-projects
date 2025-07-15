using System;
using System.Collections.Generic;

// this is the base class: activity (because all the other classes are considered activitys so they will all come back to this base one)
// this class cant create an object on its own, it has to be inherited
abstract class Activity
{
    // these store the date of a specific activity and the length of it in minutes
    private string _date;
    private int _lengthMin;

    // this is the constructor for the base class that sets the date and length of the activity
    public Activity(string date, int lengthMin)
    {

        _date = date;
        _lengthMin = lengthMin;
    }

    // short getters
    public string Date => _date;
    public int LengthMin => _lengthMin;

    // these are the abstract methods that have to be implemented by the subclasses
    public abstract double GetDistance(); // km or miles
    public abstract double GetSpeed();    // kmph or mph
    public abstract double GetPace();     // min per km or mile

    // this can be overridden but not required
    public virtual string GetSummary()
    {
        return $"{_date} {GetType().Name} ({_lengthMin} min): " +
               $"Distance {GetDistance():0.0} km, Speed {GetSpeed():0.0} kph, Pace: {GetPace():0.0} min per km";
    }
}

// 1st activity class... the running class
// this shows it inherits from activity
class Running : Activity
{
    // running stores distance in kilos
    private double _distance; 

    // this is the constructor, it calls the base class constructor and sets the distance
    public Running(string date, int lengthMin, double distance)
        : base(date, lengthMin)
    {
        _distance = distance;
    }

    // these implament the abstract methods
    // speed = distance per hour and pace = mins per kilo
    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        return (_distance / LengthMin) * 60;
    }

    public override double GetPace()
    {
        return LengthMin / _distance;
    }
}

// the cycling bikeling class that ofc is inherited from activity
class Cycling : Activity
{
    // this stores speed in kph
    private double _speed;

    // the constructor that passes date and time to the base class and then stores the speed #imspeed - lightning mcqueen
    public Cycling(string date, int lengthMin, double speed)
        : base(date, lengthMin)
    {
        _speed = speed;
    }

    // distance = speed * time and pace = mins per km
    public override double GetDistance()
    {
        return _speed * LengthMin / 60;
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        return 60 / _speed;
    }
}

// just keep swimming class that inherits from activity
class Swimming : Activity
{
    // this stores the number of laps
    private int _laps;

    // constuctor that stores laps and passes date and time to base
    public Swimming(string date, int lengthMin, int laps)
        : base(date, lengthMin)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        // this converts laps to kilos
        return _laps * 50 / 1000.0; 
    }

    // speed and pace are calculated based on converted distance
    public override double GetSpeed()
    {
        return (GetDistance() / LengthMin) * 60;
    }

    public override double GetPace()
    {
        return LengthMin / GetDistance();
    }
}

// the main program bby! 
class Program
{
    static void Main()
    {
        // this creates a list of activities, using polymorphism to store different types
        List<Activity> activities = new List<Activity>
        {
            // haha i used fun dates that are associated with my roomies and i :) we are pretty good!
            // each item is a different subclass activity
            new Running("11 Jan 2025", 30, 4.8),
            new Cycling("01 April 2025", 45, 20.0),
            new Swimming("30 June 2025", 30, 20)
        };

        // loops through each activity
        // this uses polymorphism to call the correct method depending on the actual object type, either running, cycling or swimming
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
