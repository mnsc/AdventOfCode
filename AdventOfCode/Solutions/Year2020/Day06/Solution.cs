using System;
using System.Linq;

namespace AdventOfCode.Solutions.Year2020
{

    class Day06 : ASolution
    {
        private string[][] _declarations;

        public Day06() : base(06, 2020, "")
        {
            _declarations = Input
               .Split(new[] { "\r\r", "\n\n", "\r\n\r\n" }, StringSplitOptions.None)
               .Select(group => group.Split(new[] { "\r", "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToArray())
               .ToArray();
        }

        protected override string SolvePartOne()
        {
            return _declarations
                .Select(
                    group =>
                    group.SelectMany(person => person.ToCharArray())
                    .Distinct()
                    .Count()
                )
                .Sum()
                .ToString();

        }

        protected override string SolvePartTwo()
        {
            return _declarations
                .Select(
                    group =>
                    {
                        var personsAnswers = group.Select(person => person.ToCharArray());
                        var firstperson = personsAnswers.First();
                        var intersected = personsAnswers.Aggregate(firstperson, (distinct, nextPerson) => distinct.Intersect(nextPerson).ToArray());
                        return intersected.Length;
                    }
                )
               .Sum()
               .ToString();
        }
    }
}
