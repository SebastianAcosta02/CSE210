using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("Your journal is empty. Choose Write to add an entry.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string fileName)
    {
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine(entry._date + "~|~" + entry._promptText
                    + "~|~" + entry._entryText + "~|~" + entry._mood);
            }
        }

        Console.WriteLine("Journal saved.");
    }

    public void LoadFromFile(string fileName)
    {
        if (!File.Exists(fileName))
        {
            Console.WriteLine("That file could not be found.");
            return;
        }

        string[] lines = File.ReadAllLines(fileName);
        List<Entry> loadedEntries = new List<Entry>();

        foreach (string line in lines)
        {
            string[] parts = line.Split("~|~");

            if (parts.Length != 4)
            {
                Console.WriteLine("This file is not in the journal format.");
                Console.WriteLine("Your current entries have not been changed.");
                return;
            }

            Entry entry = new Entry();
            entry._date = parts[0];
            entry._promptText = parts[1];
            entry._entryText = parts[2];
            entry._mood = parts[3];
            loadedEntries.Add(entry);
        }

        _entries = loadedEntries;
        Console.WriteLine("Journal loaded.");
    }
}
