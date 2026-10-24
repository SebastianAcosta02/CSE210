using System;
using System.IO;

// Exceeding requirements:
// - The program loads scriptures from a file (scriptures.txt) and picks a random one
//   each time it runs, instead of only having one scripture.
// - When hiding words it only picks words that aren't already hidden (stretch challenge).
// - You can type "hint" to bring back one hidden word if you get stuck.

class Program
{
    static void Main(string[] args)
    {
        ScriptureLibrary library = new ScriptureLibrary();
        string filePath = Path.Combine(AppContext.BaseDirectory, "scriptures.txt");
        library.LoadFromFile(filePath);

        Scripture scripture = library.GetRandomScripture();

        string input = "";

        while (input != "quit")
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            if (scripture.IsCompletelyHidden())
            {
                break;
            }

            Console.WriteLine("Press enter to continue, type 'hint' for a hint, or type 'quit' to finish:");
            input = Console.ReadLine() ?? "";

            if (input == "hint")
            {
                scripture.ShowHint();
            }
            else if (input != "quit")
            {
                scripture.HideRandomWords(3);
            }
        }
    }
}
