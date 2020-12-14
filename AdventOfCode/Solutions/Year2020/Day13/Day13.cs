using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Solutions.Year2020
{

    class Day13 : ASolution
    {

        public Day13() : base(13, 2020, "")
        {

        }

        protected override string SolvePartOne()
        {
            return null;
        }

        protected override string SolvePartTwo()
        {
            long minimumTimestamp = 100000000000000;
            var buses = Input
                .Split("\n")[1]
                .Split(",")
                .Select((busId, idx) => (busId, idx))
                .Where(x => x.busId != "x")
                .Select(tuple => (busId: int.Parse(tuple.busId), remainder: tuple.idx))
                .OrderBy(tuple => tuple.busId).ToArray();

            foreach (var bus in buses)
            {
                Console.WriteLine($"t mod {bus.busId} = {bus.remainder}");
                Console.WriteLine($"100000000000000 mod {bus.busId} = {100000000000000 % bus.busId}");
                Console.WriteLine("Not right!");
            }
            Console.WriteLine("So what is t?");
            Console.WriteLine("I'm remainded of a chinese problem... ");

            return null;
        }
    }
}
