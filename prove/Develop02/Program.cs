using System;

class Program
{
    // Exceeding requirements:
    // Each entry includes an optional mood that is displayed, saved,
    // and loaded with the date, prompt, and response.

    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        string choice = "";

        Console.WriteLine("Welcome to the Journal Program!");

        while (choice != "5")
        {
            Console.WriteLine();
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            choice = Console.ReadLine();
            Console.WriteLine();

            if (choice == null)
            {
                break;
            }

            if (choice == "1")
            {
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine(prompt);
                Console.Write("> ");
                string response = Console.ReadLine();

                if (response == null)
                {
                    break;
                }

                if (string.IsNullOrWhiteSpace(response))
                {
                    Console.WriteLine("The entry was empty, so it was not added.");
                    continue;
                }

                Console.Write("How are you feeling? (Press Enter to skip.) ");
                string mood = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(mood))
                {
                    mood = "Not recorded";
                }

                Entry entry = new Entry();
                entry._date = DateTime.Now.ToShortDateString();
                entry._promptText = prompt;
                entry._entryText = response;
                entry._mood = mood;

                journal.AddEntry(entry);
                Console.WriteLine("Entry added. Choose Save to save it to a file.");
            }
            else if (choice == "2")
            {
                journal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("What is the filename? ");
                string fileName = Console.ReadLine();
                journal.LoadFromFile(fileName);
            }
            else if (choice == "4")
            {
                Console.Write("What is the filename? ");
                string fileName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(fileName))
                {
                    Console.WriteLine("Please enter a filename, such as journal.txt.");
                }
                else
                {
                    journal.SaveToFile(fileName);
                }
            }
            else if (choice != "5")
            {
                Console.WriteLine("Please enter a number from 1 to 5.");
            }
        }

        Console.WriteLine("Goodbye!");
    }
}
