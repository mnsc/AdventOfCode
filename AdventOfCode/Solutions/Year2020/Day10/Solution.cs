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
            static int SolveManuallyInExcelWithSomeFormulasAndAPivotTable() { return 2030; }

            return SolveManuallyInExcelWithSomeFormulasAndAPivotTable().ToString();
        }

        protected override string SolvePartTwo()
        {
            var adapters = Input.SplitByNewline().Append("0").Select(x => int.Parse(x)).OrderBy(x => x).ToArray();
            var lastIndex = adapters.Length - 1;

            var combinationsFromAdapterToDevice = new Dictionary<int, long>();
            combinationsFromAdapterToDevice.Add(adapters[lastIndex], 1);

            for (var i = lastIndex - 1; i >= 0; i--)
            {
                var currentAdapter = adapters[i];
                long fromCurrentToDevice = 0;
                void CheckLaterAdapters(int lookForward)
                {
                    if (i + lookForward <= lastIndex && adapters[i + lookForward] - currentAdapter <= 3)
                    {
                        fromCurrentToDevice += combinationsFromAdapterToDevice[adapters[i + lookForward]];
                    }
                }
                CheckLaterAdapters(1);
                CheckLaterAdapters(2);
                CheckLaterAdapters(3);

                combinationsFromAdapterToDevice.Add(currentAdapter, fromCurrentToDevice);
            }

            return combinationsFromAdapterToDevice.Last().Value.ToString();


        }
    }
}
