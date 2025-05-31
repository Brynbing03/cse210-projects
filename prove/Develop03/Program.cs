// this program is going to help users memorize scriptures
// it is going to display a scripture vers and the gradually hide words in the verse every time the user presses enter to help them memorize it
// you can get out of the program when you type "quit" 

using System;
using System.Collections.Generic;
using System.Linq;

// this class is going to hold the scripture book, chapter and verse
class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
    }

    public string GetDisplayText()
    {
        return $"{_book} {_chapter}:{_verse}";
    }
}

// this class will represent each individual word in a scripture
class Word
{
    private string _text;
    private bool _isHidden;
    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        return _isHidden ? new string('_', _text.Length) : _text;
    }
}

// this class represents the full scripture itself, broken into workds and the connecter to its reference 
class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ')
                     .Select(word => new Word(word))
                     .ToList();
    }

    public void HideRandomWords(int count = 3)
    {
        var visibleWords = _words.Where(w => !w.IsHidden()).ToList();
        if (visibleWords.Count == 0) return;

        int hideCount = Math.Min(count, visibleWords.Count);
        for (int i = 0; i < hideCount; i++)
        {
            int index = _random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }

    public string GetDisplayText()
    {
        string referenceText = _reference.GetDisplayText();
        string wordsText = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        return $"{referenceText} - {wordsText}";
    }
}

// this is the main class that pretty much creates the program
// main points of main program class
// 1. creates a reference
// 2. creates the scripture with the text
// 3.loops until the user makes all the words disappear or quits the program
// 4. then it says bye and good job :)
class Program
{
    static void Main(string[] args)
    {
        // create a list of scripture options for user to choose 
        var scriptures = new List<Scripture>
        {
            new Scripture(new Reference("Proverbs", 3, 5), "Trust in the Lord with all thine heart and lean not unto thine own understanding."),
            new Scripture(new Reference("John", 3, 16), "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."),
            new Scripture(new Reference("Philippians", 4, 13), "I can do all things through Christ which strengtheneth me.")
        };

        // display scripture options to the user
        Console.WriteLine("Choose a scripture to memorize:\n");
        for (int i = 0; i < scriptures.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {scriptures[i].GetDisplayText()}");
        }

        // get user choice of scripture
        int choice;
        while (true)
        {
            Console.Write("\nEnter the number of your choice: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out choice) && choice >= 1 && choice <= scriptures.Count)
                break;
            Console.WriteLine("Invalid choice. Please enter a valid number.");
        }

        // use the selected scripture to memorize
        Scripture selectedScripture = scriptures[choice - 1];

        // start the memorization loop
        while (true)
        {
            Console.Clear();
            Console.WriteLine(selectedScripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to make words disappear or type 'quit' to end:");
            string userInput = Console.ReadLine();

            if (userInput.ToLower() == "quit" || selectedScripture.IsCompletelyHidden())
                break;

            selectedScripture.HideRandomWords();
        }

        Console.WriteLine("\nNow you have your scripture memorized! GREAT JOB! :)");
    }
}
