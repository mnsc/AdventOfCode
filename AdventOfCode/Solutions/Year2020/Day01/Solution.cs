using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Solutions.Year2020
{

    class Day01 : ASolution
    {

        public Day01() : base(01, 2020, "")
        {
        }

        protected override string SolvePartOne()
        {
            var input = Input.SplitByNewline().Select(i => int.Parse(i)).ToList();

            for (int i = 0; i < input.Count - 1; i++)
                for (int j = i + 1; j < input.Count; j++)
                    if (input[i] + input[j] == 2020)
                        return (input[i] * input[j]).ToString();
            return "";
        }

        protected override string SolvePartTwo()
        {
            var input = Input.SplitByNewline().Select(i => int.Parse(i)).ToList();

            for (int i = 0; i < input.Count - 2; i++)
                for (int j = i + 1; j < input.Count - 1; j++)
                    for (int k = i + 1; k < input.Count; k++)
                        if (input[i] + input[j] + input[k] == 2020)
                            return (input[i] * input[j] * input[k]).ToString();
            return "";
        }
    }
}
