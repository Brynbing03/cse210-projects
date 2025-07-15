using System;
using System.Collections.Generic;

// this is the address class
class Address
{
    // these private variables hold the parts of a adress
    // i know this program focuses on inheritance, but i wanted to show how you can use encapsulation in it too and that is why i made them private
    private string street;
    private string city;
    private string state;
    private string country;

    // the constuctor that brings the address all together
    public Address(string street, string city, string state, string country)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    // this returns the full address as a string
    public string GetFullAddress()
    {
        // sting inter to put it all together then return it all in full
        return $"{street}, {city}, {state}, {country}";
    }
}

// the event class
class Event
{
    // the private variables that hold the event details
    // all events will have these attributes
    private string title;
    private string description;
    private string date;
    private string time;
    private Address address;

    // constructor
    public Event(string title, string description, string date, string time, Address address)
    {
        this.title = title;
        this.description = description;
        this.date = date;
        this.time = time;
        this.address = address;
    }

    public string GetStandardDetails()
    {
        // this returns the title, description, date, time of the event and the address
        return $"Title: {title}\nDescription: {description}\nDate: {date}\nTime: {time}\nAddress: {address.GetFullAddress()}";
    }

    // i made this virtual so that the kid classes can override it
    public virtual string GetFullDetails()
    {
        return GetStandardDetails();
    }

    public string GetShortDescription()
    {
        // i used gettype().name to get the actual type name
        return $"Event Type: {GetType().Name}\nTitle: {title}\nDate: {date}";
    }
}

// lecture class that INHERITS from event
class Lecture : Event
{
    // these are two new, additional foelds that are specific for the lecture class
    private string speaker;
    private int capacity;

    // the constructor that takes all the base things and adds the new ones
    // the :base() calls the parent constructors
    public Lecture(string title, string description, string date, string time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        this.speaker = speaker;
        this.capacity = capacity;
    }

    // this overrides the getfulldetails method from the parent class to include the lecture specific stuff
    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nEvent Type: Lecture\nSpeaker: {speaker}\nCapacity: {capacity}";
    }
}

// this is the reception class that also inherits from event
class Reception : Event
{
    // this is its own unique field which is a email address
    private string rsvpEmail;

    // the constructor that takes all the base things and adds the new ones
    public Reception(string title, string description, string date, string time, Address address, string rsvpEmail)
        : base(title, description, date, time, address)
    {
        this.rsvpEmail = rsvpEmail;
    }

    // this customizees the full details with the rsvp info
    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nEvent Type: Reception\nRSVP Email: {rsvpEmail}";
    }
}

// the outdoor gathering class that inherits from event
// this one is very similar to the two previous classes, just for a different type of event
class OutdoorGathering : Event
{
    private string weather;

    public OutdoorGathering(string title, string description, string date, string time, Address address, string weather)
        : base(title, description, date, time, address)
    {
        this.weather = weather;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nEvent Type: Outdoor Gathering\nWeather Forecast: {weather}";
    }
}

// main program
class Program
{
    static void Main()
    // creates a new address object
    {
        Address address1 = new Address("123 ABC RD.", "Rexburg", "ID", "USA");
        // creates a lecture event using address
        Lecture lecture = new Lecture("C# Tech Talk", "Understanding Inheritance", "July 15, 2025", "10:00 AM", address1, "Bro. Crosby", 150);

        // this creates one of each type of event with different data
        Address address2 = new Address("1121 E. 1557 S.", "Gooding", "ID", "USA");
        Reception reception = new Reception("Dairy Business Party", "Meet and Greet the cows", "July 25, 2025", "6:00 PM", address2, "rsvp.da.cows@PRL&L.com");

        Address address3 = new Address("500 Fairgrounds Rd.", "Castle Rock", "CO", "USA");
        OutdoorGathering outdoor = new OutdoorGathering("Douglas County Fair", "Food, Music and the RODEO", "July 25, 2025", "8:00 PM", address3, "Sunset golden hour, warm");

        // stores all the events in a list of the base type event (if i understnad it right, i think this allows polymorphism)
        List<Event> events = new List<Event> { lecture, reception, outdoor };

        // loops through the list and prints out the full details of each event
        foreach (Event ev in events)
        {
            Console.WriteLine("----- Standard Details -----");
            Console.WriteLine(ev.GetStandardDetails());
            Console.WriteLine("\n----- Full Details -----");
            Console.WriteLine(ev.GetFullDetails());
            Console.WriteLine("\n----- Short Description -----");
            Console.WriteLine(ev.GetShortDescription());
            Console.WriteLine("\n-----------------------------\n");
        }
    }
}
