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
                .OrderByDescending(tuple => tuple.busId).ToArray();


            Console.WriteLine("Input");
            foreach (var bus in buses)
            {
                Console.WriteLine($"(t + {bus.remainder}) mod {bus.busId} should be 0");

            }
            Console.WriteLine();
            Console.WriteLine("Lets go!");
            Console.WriteLine();
            long t = 0;
            int currentIndex = 0;
            long jump = 1;
            while (true)
            {
                if ((t + buses[currentIndex].remainder) % buses[currentIndex].busId == 0)
                {
                    Console.WriteLine($"Maybe {t}?");

                    bool allgood = true;
                    for (int i = currentIndex; i < buses.Length; i++)
                    {
                        if ((t + buses[i].remainder) % buses[i].busId == 0)
                        {
                            Console.WriteLine($"Ok... {t + buses[i].remainder} % {buses[i].busId} == 0");
                        }
                        else
                        {
                            Console.WriteLine($"Nooo! {t + buses[i].remainder} % {buses[i].busId} != 0 ({(t + buses[i].remainder) % buses[i].busId})");
                            allgood = false;
                            break;
                        }
                    }
                    if (allgood)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Wohoo!! {t} did it!");
                        Console.WriteLine();
                        foreach (var bus in buses)
                        {
                            Console.WriteLine($"{t} + {bus.remainder} = {t + bus.remainder} % {bus.busId} == 0");
                        }
                        return t.ToString();
                    }
                    Console.WriteLine();
                    Console.Write("Increasing jump from " + jump);
                    jump *= buses[currentIndex].busId;
                    Console.WriteLine(" to " + jump);
                    Console.WriteLine();
                    currentIndex++;
                }

                t += jump;
            }
        }
    }
}
