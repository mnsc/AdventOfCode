//using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solutions.Year2020
{

    class Day10 : ASolution
    {

        public Day10() : base(10, 2020, "")
        {
        }

        protected override string SolvePartOne()
        {
            return null;
        }

        protected override string SolvePartTwo()
        {
            var adapters = Input.SplitByNewline().Append("0").Select(x => int.Parse(x)).OrderBy(x => x).ToArray();
            var combinationsToDevice = new Dictionary<int, long>();
            var largestAdapterIndex = adapters.Length - 1;
            combinationsToDevice.Add(adapters[largestAdapterIndex], 1);

            for (var i = largestAdapterIndex - 1; i >= 0; i--)
            {
                var current = adapters[i];
                long currentCombinationsToDevice = 0;
                if (i + 1 <= largestAdapterIndex && adapters[i + 1] - current <= 3)
                {
                    currentCombinationsToDevice += combinationsToDevice[adapters[i + 1]];
                }
                if (i + 2 <= largestAdapterIndex && adapters[i + 2] - current <= 3)
                {
                    currentCombinationsToDevice += combinationsToDevice[adapters[i + 2]];
                }
                if (i + 3 <= largestAdapterIndex && adapters[i + 3] - current <= 3)
                {
                    currentCombinationsToDevice += combinationsToDevice[adapters[i + 3]];
                }

                combinationsToDevice.Add(current, currentCombinationsToDevice);
            }

            return combinationsToDevice.Last().Value.ToString();
        }
    }
}
