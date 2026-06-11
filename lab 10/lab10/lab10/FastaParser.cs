using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab10;

public static class FastaParser
{
    public static List<FastaSequence> ReadFastaFiles(IEnumerable<string> paths)
    {
        List<FastaSequence> result = new();

        foreach (string path in paths)
        {
            result.AddRange(ReadSingleFile(path));
        }

        return result;
    }

    private static List<FastaSequence> ReadSingleFile(string path)
    {
        List<FastaSequence> sequences = new();

        string[] lines = File.ReadAllLines(path);

        if (lines.Length == 0)
            throw new Exception("Plik jest pusty.");

        string? currentHeader = null;
        StringBuilder currentSequence = new();

        foreach (string rawLine in lines)
        {
            string line = rawLine.Trim();

            if (line == "")
                continue;

            if (line.StartsWith(">"))
            {
                if (currentHeader != null)
                {
                    AddSequence(sequences, currentHeader, currentSequence.ToString());
                    currentSequence.Clear();
                }

                currentHeader = line.Substring(1).Trim();

                if (currentHeader == "")
                    throw new Exception("Nagłówek FASTA nie może być pusty.");
            }
            else
            {
                if (currentHeader == null)
                    throw new Exception("Plik FASTA musi zaczynać się od znaku >.");

                if (line.Any(c => !char.IsLetter(c)))
                    throw new Exception("Sekwencja może zawierać tylko litery.");

                currentSequence.Append(line.ToUpper());
            }
        }

        if (currentHeader != null)
        {
            AddSequence(sequences, currentHeader, currentSequence.ToString());
        }

        if (sequences.Count == 0)
            throw new Exception("Nie znaleziono żadnej sekwencji.");

        return sequences;
    }

    private static void AddSequence(List<FastaSequence> list, string header, string sequence)
    {
        if (sequence.Length == 0)
            throw new Exception($"Sekwencja '{header}' jest pusta.");

        list.Add(new FastaSequence
        {
            Header = header,
            Name = header.Split(' ')[0],
            Sequence = sequence
        });
    }
}
