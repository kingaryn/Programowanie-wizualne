using System;
using System.Linq;

namespace lab10;

public class FastaSequence
{
    public string Header { get; set; } = "";
    public string Name { get; set; } = "";
    public string Sequence { get; set; } = "";

    public int Length => Sequence.Length;

    public int CountA => Sequence.Count(c => c == 'A');
    public int CountT => Sequence.Count(c => c == 'T');
    public int CountG => Sequence.Count(c => c == 'G');
    public int CountC => Sequence.Count(c => c == 'C');

    public int CodonCount => Length / 3;

    public double GCContent
    {
        get
        {
            if (Length == 0) return 0;
            return Math.Round((double)(CountG + CountC) / Length * 100, 2);
        }
    }
}
