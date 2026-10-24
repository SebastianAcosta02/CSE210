using System;
using System.Collections.Generic;
using System.IO;

public class ScriptureLibrary
{
    private List<Scripture> _scriptures = new List<Scripture>();

    // each line in the file looks like this:
    // Book|Chapter|StartVerse|EndVerse|Text
    // EndVerse is 0 if it's only one verse
    public void LoadFromFile(string fileName)
    {
        string[] lines = File.ReadAllLines(fileName);

        foreach (string line in lines)
        {
            string[] parts = line.Split('|');

            string book = parts[0];
            int chapter = int.Parse(parts[1]);
            int startVerse = int.Parse(parts[2]);
            int endVerse = int.Parse(parts[3]);
            string text = parts[4];

            Reference reference;
            if (endVerse == 0)
            {
                reference = new Reference(book, chapter, startVerse);
            }
            else
            {
                reference = new Reference(book, chapter, startVerse, endVerse);
            }

            Scripture scripture = new Scripture(reference, text);
            _scriptures.Add(scripture);
        }
    }

    public Scripture GetRandomScripture()
    {
        Random random = new Random();
        int index = random.Next(_scriptures.Count);
        return _scriptures[index];
    }
}
