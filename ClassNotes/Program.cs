// // ## Instructions for creating a new project in this solution:

// // 1. Create a new folder: `mkdir unitX/MyProject`
// // 2. Create the project: `cd unitX/MyProject;dotnet new console;cd ../..`
// // 3. Add the project to the solution: `dotnet sln add ./unitX/MyProject/MyProject.csproj`


// // See https://aka.ms/new-console-template for more information
// // The line below is a test to make sure that everything is working correctly
// // Console.WriteLine("Hello, World!");

// // LISTS using C#
// // making a string list
// List<string> animals = new List<string>();
// // making a number list
// List<int> debits = new List<int>();

// // to add things to the list, do this
// animals.Add("Cow");
// animals.Add("Horse");
// animals.Add("Pig");

// // to loop through lists - make sure to state what kind of list you are making (exp.String)
// foreach(String animal in animals)
// {
//     Console.WriteLine(animal);
// }
// // we can also figure out the len(in python) or count of what you have
// Console.WriteLine(animals.Count);

// // this is an if else statement that it going through the list to define if there is Dog in the list or not
// if (animals.Contains("Dog"))
// {
//     Console.WriteLine("There is Dog");
// }
// else
// {
//     Console.WriteLine("There is not a Dog...");
// }




// // Python Function Defined
// // def add_numbers(a, b);
// //      sum = a + b
// //      return sum

// int AddNumbers(int a, int b)
// {
//     int sum = a + b;
//     return sum;
// }

// Console.WriteLine(AddNumbers(1, 2));


// public class SecretFamilyRecipe
// {
//     public string _password = "GrandmaDespisesBroccoli";

//     public string _recipe = "Quesadilla: Spread a thin layer of mayo on one tortilla, and shredded scheed and optional fillinfs, top with another tortilla, then cook in a skillet until crispy brown";

//     public string Reveal(string password)
//     {
//         if (password == _password)
//             return _recipe;
//         else
//         {
//             return "Nope, you're wrong...";
//         }
//     }
// }