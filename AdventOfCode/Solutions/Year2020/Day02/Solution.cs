using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solutions.Year2020
{
    public record Entry(
        int Min,
        int Max,
        char Letter,
        string Password
    );

    class Day02 : ASolution
    {
        readonly List<Entry> _parsed = new List<Entry>();

        public Day02() : base(02, 2020, "")
        {
            foreach (var row in Input.SplitByNewline())
            {
                var split = row.Split(new string[] { ":", " ", "-" }, StringSplitOptions.RemoveEmptyEntries);
                
                _parsed.Add(new Entry(int.Parse(split[0]), int.Parse(split[1]), split[2][0], split[3]));
            }

        }

        protected override string SolvePartOne()
        {
            var numValids = _parsed
                .Select(entry => (Entry: entry, LetterOccurences: entry.Password.Count(c => entry.Letter == c)))
                .Count(enrichedEntry => enrichedEntry.LetterOccurences >= enrichedEntry.Entry.Min && enrichedEntry.LetterOccurences <= enrichedEntry.Entry.Max);

            return numValids.ToString();
        }

        protected override string SolvePartTwo()
        {
            return null;
        }
    }
}
