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
            DebugInput = @"1068781
7,13,x,x,59,x,31,19";
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
                .OrderByDescending(tuple => tuple.busId).ToArray();

            foreach (var bus in buses)
            {
                Console.WriteLine($"t mod {bus.busId} should be {bus.remainder}");

            }

            long t = 1068781;
            int currentIndex = 0;
            long jump = 1;
            while (true)
            {
                if (t % buses[currentIndex].busId == buses[currentIndex].remainder)
                {
                    Console.WriteLine($"{t} % {buses[currentIndex].busId} == {buses[currentIndex].remainder}");

                    bool allgood = true;
                    for (int i = currentIndex; i < buses.Length; i++)
                    {
                        if (t % buses[i].busId != buses[i].remainder)
                        {
                            Console.WriteLine($"{t} % {buses[i].busId} != {buses[i].remainder}");
                            allgood = false;
                        }
                    }
                    if (!allgood)
                    {
                        Console.Write("Increasing jump from " + jump);
                        jump *= buses[currentIndex].busId;
                        Console.WriteLine(" to " + jump);
                        currentIndex++;
                    }
                }

                t = t + jump;
            }
            return null;
        }
    }
}
