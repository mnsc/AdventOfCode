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
//            DebugInput = @"
//35
//20
//15
//25
//47
//40
//62
//55
//65
//95
//102
//117
//150
//182
//127
//219
//299
//277
//309
//576
//";
            if (DebugInput != null)
            {
                preamble = 5;
            }

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
                        for (int j = i; j > 0 - 1; j--)
                        {
                            contSum += input[j];
                            if (contSum == toCheck)
                            {
                                return $"Missing number {toCheck} is sum of range {i} - {j}, lowest and highest is {input[j]}, {input[i]}. Answer: {input[i] + input[j]}";
                                
                            }
                        }
                    }
                }


            }


            return null;
        }
    }
}
