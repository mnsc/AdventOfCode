using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Solutions.Year2020
{

    class Day02 : ASolution
    {
        public record Entry
        {
            public int Min { get; init; }
            public int Max { get; init; }
            public char Letter { get; init; }
            public string Password { get; init; }
            public int LetterOccurences { get; init; }
        }

        List<Entry> _parsed = new List<Entry>();

        public Day02() : base(02, 2020, "")
        {
            foreach (var row in Input.SplitByNewline())
            {
                string[] split = row.Split(new string[] { ":", " ", "-" }, StringSplitOptions.RemoveEmptyEntries);
                _parsed.Add(new Entry { Min = int.Parse(split[0]), Max = int.Parse(split[1]), Letter = split[2][0], Password = split[3] });
            }

        }

        protected override string SolvePartOne()
        {
            var numValids = _parsed
                .Select(entry => entry with { LetterOccurences = entry.Password.Count(c => entry.Letter == c) })
                .Count(enrichedEntry => enrichedEntry.LetterOccurences >=  enrichedEntry.Min && enrichedEntry.LetterOccurences <= enrichedEntry.Max);

            return numValids.ToString();
        }

        protected override string SolvePartTwo()
        {
            return null;
        }
    }
}
