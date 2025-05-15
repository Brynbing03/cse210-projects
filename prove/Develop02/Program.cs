// ORIGINAL TRIAL CODE haha it is a BUST! ;O
// using System;
// using System.Collections.Generic;
// using System.IO;
// using System.Reflection.Metadata.Ecma335;

// class Entry
// {
//     public string Date {get; set; }
//     public string Prompt {get; set; }
//     public string Response {get; set; }

//     public Entry(string prompt, string response)
//     {
//         Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
//         Prompt = prompt;
//         Response = response;
//     }
//     public void Display()
//     {
//         Console.WriteLine($"\nDate: {Date}");
//         Console.WriteLine($"Prompt: {Prompt}");
//         Console.WriteLine($"Response: {Response}\n");
//     }
// }

// class PromptGenerator
// {
//     private List<string> prompts = new List<string>
//     {
//         "What is something amazing that happened to you today?",
//         "What is something new that you learned today?",
//         "What is something you are grateful for today?",
//         "What is a challenge that you overcame today?",
//         "What was the happiest part of your day today?"
//     };

//     private Random random = new Random();

//     public string GetRandomPrompt()
//     {
//         int index = random.Next(prompts.Count);
//         return prompts[index];
//     }

// }

// class Journal
// {
//     private List<Entry> entries = new List<Entry>();

//     public void AddEntry(Entry entry)
//     {
//         entries.Add(entry);
//     }

//     public void DisplayEntries()
//     {
//         if (entries.Count == 0)
//         {
//             Console.WriteLine("\nNo entries to display.\n");
//         }
//         else
//         {
//             foreach (Entry entry in entries)
//             {
//                 entry.Display();
//             }
//         }
//     }

//     public void SaveToFile(string filename)
//     {
//         try
//         {
//             using (StreamWriter writer = new StreamWriter(filename))
//             {
//                 foreach (Entry entry in entries)
//                 {
//                     writer.WriteLine($"{entry.Date} | {entry.Prompt} | {entry.Response}");
//                 }    
//             }
//             Console.WriteLine("Journal saved successfully.");
//         }
//         catch (Exception ex)
//         {
//             Console.WriteLine($"Error saving file: {ex.Message}");
//         }
//     }
// }

// class Program
// {
//     static void Main(string[] args)
//     {
//         Journal journal = new Journal();
//         PromptGenerator promptGenerator = new PromptGenerator();

//         while (true)
//         {
//             Console.WriteLine("\n Journal Menu:");
//             Console.WriteLine("1. Write");
//             Console.WriteLine("2. Display");
//             Console.WriteLine("3. Save");
//             Console.WriteLine("4. Load");
//             Console.WriteLine("5. Quit");

//             Console.Write("What would you like to do? (1-5)");
//             string choice = Console.ReadLine();

//             switch (choice)
//             {
//                 case "1":
//                     string prompt = promptGenerator.GetRandomPrompt();
//                     Console.WriteLine($"\nPrompt: {prompt}");
//                     Console.Write("Your response:");
//                     string response = Console.ReadLine();
//                     Entry entry = new Entry(prompt, response);
//                     journal.AddEntry(entry);
//                     break;

//                 case "2":
//                     journal.DisplayEntries();
//                     break;

//                 case "3":
//                     Console.Write("Enter filename to save to:");
//                     string saveFile = Console.ReadLine();
//                     journal.SaveToFile(saveFile);
//                     break;

//                 case "4":
//                     Console.Write("Enter filename to load froom:");
//                     string loadFile = Console.ReadLine();
//                     journal.LoadFromFile(loadFile);
//                     break;

//                 case "5":
//                     Console.WriteLine("See ya!");
//                     return;

//                 default:
//                     Console.WriteLine("Invalid choice. Please enter a number anywhere from 1 to 5.");
//                     break;
//             }
//         }
//     }
// }

// NEXT TRY, still was rough...
// using System;
// using System.Collections.Generic;
// using System.IO;

// // this class represents one journal enrty
// // it stores the prompt, the answer to the prompt and the date
// // it auto sets the date when a new entry is created
// // there is then a display that shows the entry on the screen
// class Entry
// {
//     public string _date { get; set; }
//     public string _prompt { get; set; }
//     public string _response { get; set; }

//     public Entry(string prompt, string response)
//     {
//         _date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
//         _prompt = prompt;
//         _response = response;
//     }

//     public void Display()
//     {
//         Console.WriteLine($"\nDate: {Date}");
//         Console.WriteLine($"Prompt: {Prompt}");
//         Console.WriteLine($"Response: {Response}\n");
//     }
// }

// // this class gives a random prompt/question for the user to answer
// // it stores a list of writing prompts
// // it then randomly picks a prompt/question to be answered
// class PromptGenerator
// {
//     private List<string> prompts = new List<string>
//     {
//         "What is something amazing that happened to you today?",
//         "What is something new that you learned today?",
//         "What is something you are grateful for today?",
//         "What is a challenge that you overcame today?",
//         "What was the happiest part of your day today?"
//     };

//     private Random random = new Random();

//     public string GetRandomPrompt()
//     {
//         int index = random.Next(prompts.Count);
//         return prompts[index];
//     }
// }

// // this class holds all the entries in the journal
// // this keeps track of all entires it can: add an entry, display entries, save it to a file and load entries from a file
// class Journal
// {
//     private List<Entry> entries = new List<Entry>();

//     public void AddEntry(Entry entry)
//     {
//         entries.Add(entry);
//     }

//     public void DisplayEntries()
//     {
//         if (entries.Count == 0)
//         {
//             Console.WriteLine("\nNo entries to display.\n");
//         }
//         else
//         {
//             foreach (Entry entry in entries)
//             {
//                 entry.Display();
//             }
//         }
//     }

//     public void SaveToFile(string filename)
//     {
//         try
//         {
//             using (StreamWriter writer = new StreamWriter(filename))
//             {
//                 foreach (Entry entry in entries)
//                 {
//                     writer.WriteLine($"{entry.Date} | {entry.Prompt} | {entry.Response}");
//                 }
//             }
//             Console.WriteLine("Journal saved successfully.");
//         }
//         catch (Exception ex)
//         {
//             Console.WriteLine($"Error saving file: {ex.Message}");
//         }
//     }

//     public void LoadFromFile(string filename)
//     {
//         try
//         {
//             entries.Clear();
//             using (StreamReader reader = new StreamReader(filename))
//             {
//                 string line;
//                 while ((line = reader.ReadLine()) != null)
//                 {
//                     string[] parts = line.Split(" | ");
//                     if (parts.Length == 3)
//                     {
//                         Entry entry = new Entry(parts[1], parts[2])
//                         {
//                             Date = parts[0]
//                         };
//                         entries.Add(entry);
//                     }
//                 }
//             }
//             Console.WriteLine("Journal loaded successfully.");
//         }
//         catch (Exception ex)
//         {
//             Console.WriteLine($"Error loading file: {ex.Message}");
//         }
//     }
// }

// // this is where the actual program starts and runs in a loop
// // creates a journal and a prompt generator
// // this shows the 5 menu options which are: 1.write, 2.display, 3.save, 4.load and 5.quit
// // depending on what number the user chooses, it will do the matching task
// class Program
// {
//     static void Main(string[] args)
//     {
//         Journal journal = new Journal();
//         PromptGenerator promptGenerator = new PromptGenerator();

//         while (true)
//         {
//             Console.WriteLine("\nJournal Menu:");
//             Console.WriteLine("1. Write");
//             Console.WriteLine("2. Display");
//             Console.WriteLine("3. Save");
//             Console.WriteLine("4. Load");
//             Console.WriteLine("5. Quit");

//             Console.Write("What would you like to do? (1-5): ");
//             string choice = Console.ReadLine();

//             switch (choice)
//             {
//                 case "1":
//                     string prompt = promptGenerator.GetRandomPrompt();
//                     Console.WriteLine($"\nPrompt: {prompt}");
//                     Console.Write("Your response: ");
//                     string response = Console.ReadLine();
//                     Entry entry = new Entry(prompt, response);
//                     journal.AddEntry(entry);
//                     break;

//                 case "2":
//                     journal.DisplayEntries();
//                     break;

//                 case "3":
//                     Console.Write("Enter filename to save to: ");
//                     string saveFile = Console.ReadLine();
//                     journal.SaveToFile(saveFile);
//                     break;

//                 case "4":
//                     Console.Write("Enter filename to load from: ");
//                     string loadFile = Console.ReadLine();
//                     journal.LoadFromFile(loadFile);
//                     break;

//                 case "5":
//                     Console.WriteLine("See ya!");
//                     return;

//                 default:
//                     Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
//                     break;
//             }
//         }
//     }
// }

// CODE THAT IS WORKING!!!! LETS GO! FINALLY!!! :) :) :)
using System;
using System.Collections.Generic;
using System.IO;

// This class represents one journal entry
// It stores the prompt, the answer to the prompt, and the date
// It auto-sets the date when a new entry is created
// There is then a display method that shows the entry on the screen
class Entry
{
    public string _date { get; set; }
    public string _prompt { get; set; }
    public string _response { get; set; }

    public Entry(string prompt, string response)
    {
        _date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        _prompt = prompt;
        _response = response;
    }

    public void Display()
    {
        Console.WriteLine($"\nDate: {_date}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Response: {_response}\n");
    }
}

// This class gives a random prompt/question for the user to answer
// It stores a list of writing prompts
// It then randomly picks a prompt/question to be answered
class PromptGenerator
{
    private List<string> prompts = new List<string>
    {
        "What is something amazing that happened to you today?",
        "What is something new that you learned today?",
        "What is something you are grateful for today?",
        "What is a challenge that you overcame today?",
        "What was the happiest part of your day today?"
    };

    private Random random = new Random();

    public string GetRandomPrompt()
    {
        int index = random.Next(prompts.Count);
        return prompts[index];
    }
}

// This class holds all the entries in the journal
// It keeps track of all entries and can: add an entry, display entries, save to a file, and load from a file
class Journal
{
    private List<Entry> entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        entries.Add(entry);
    }

    public void DisplayEntries()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("\nNo entries to display.\n");
        }
        else
        {
            foreach (Entry entry in entries)
            {
                entry.Display();
            }
        }
    }

    public void SaveToFile(string filename)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (Entry entry in entries)
                {
                    writer.WriteLine($"{entry._date} | {entry._prompt} | {entry._response}");
                }
            }
            Console.WriteLine("Journal saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving file: {ex.Message}");
        }
    }

    public void LoadFromFile(string filename)
    {
        try
        {
            entries.Clear();
            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(" | ");
                    if (parts.Length == 3)
                    {
                        Entry entry = new Entry(parts[1], parts[2]);
                        entry._date = parts[0]; // Set the saved date
                        entries.Add(entry);
                    }
                }
            }
            Console.WriteLine("Journal loaded successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading file: {ex.Message}");
        }
    }
}

// This is where the actual program starts and runs in a loop
// It creates a journal and a prompt generator
// This shows the 5 menu options: 1.Write, 2.Display, 3.Save, 4.Load, 5.Quit
// Based on the user’s choice, it performs the appropriate action
class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        while (true)
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Quit");

            Console.Write("What would you like to do? (1-5): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"\nPrompt: {prompt}");
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();
                    Entry entry = new Entry(prompt, response);
                    journal.AddEntry(entry);
                    break;

                case "2":
                    journal.DisplayEntries();
                    break;

                case "3":
                    Console.Write("Enter filename to save to: ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    break;

                case "4":
                    Console.Write("Enter filename to load from: ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    break;

                case "5":
                    Console.WriteLine("See ya!");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                    break;
            }
        }
    }
}