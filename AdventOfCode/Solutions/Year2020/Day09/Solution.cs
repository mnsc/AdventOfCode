using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Solutions.Year2020
{

    class Day09 : ASolution
    {
        int preamble = 25;

        public Day09() : base(09, 2020, "")
        {

        }

        protected override string SolvePartOne()
        {
            var input = Input.SplitByNewline().Select(long.Parse).ToArray();

            for (int chk = preamble; chk < input.Length; chk++)
            {
                bool match = false;
                var toCheck = input[chk];
                for (int i = chk - 1; i > chk - preamble; i--)
                {
                    for (int j = i - 1; j > chk - preamble - 1; j--)
                    {
                        if (input[i] + input[j] == toCheck)
                        {
                            match = true;
                            goto Hell;
                        }
                    }
                }
            Hell:
                if (!match)
                    return toCheck.ToString();

            }


            return null;
        }

        protected override string SolvePartTwo()
        {
            var input = Input.SplitByNewline().Select(long.Parse).ToArray();

            for (int chk = preamble; chk < input.Length; chk++)
            {
                bool match = false;
                var toCheck = input[chk];
                for (int i = chk - 1; i > chk - preamble; i--)
                {
                    for (int j = i - 1; j > chk - preamble - 1; j--)
                    {
                        if (input[i] + input[j] == toCheck)
                        {
                            match = true;
                            goto Hell;
                        }
                    }
                }
            Hell:
                if (!match)
                {
                    for (int i = chk - 1; i > 2; i--)
                    {
                        long contSum = 0;
                        long min = long.MaxValue;
                        long max = 0;
                        for (int j = i; j > 0 - 1; j--)
                        {
                            var current = input[j];
                            contSum += current;
                            if (current > max)
                            {
                                max = current;
                            }
                            if (current < min)
                            {
                                min = current;
                            }
                            if (contSum == toCheck)
                            {
                                return $"Missing number {toCheck} is sum of range {i} - {j}, smallest and largest in range is {min}, {max}. Answer: {min + max}";

                            }
                        }
                    }
                }


            }


            return null;
        }
    }
}
