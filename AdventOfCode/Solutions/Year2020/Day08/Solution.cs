using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Solutions.Year2020
{

    class Day08 : ASolution
    {

        public Day08() : base(08, 2020, "")
        {
//            DebugInput = @"
//nop +0
//acc +1
//jmp +4
//acc +3
//jmp -3
//acc -99
//acc +1
//jmp -4
//acc +6
//";

        }

        protected override string SolvePartOne()
        {
            var code = Input.SplitByNewline();

            try
            {
                int returnvalue = RunCode(code);
            }
            catch (InfiniteLoopException ile)
            {
                return ile.Acc.ToString();
                throw;
            }
            return null; // expected loop
        }

        protected override string SolvePartTwo()
        {
            return null;
        }

        private static int RunCode(string[] code)
        {
            int ptr = 0;
            int acc = 0;
            HashSet<int> visited = new HashSet<int>();

            while (ptr <= code.Length)
            {
                if (visited.Contains(ptr))
                {
                    throw new InfiniteLoopException("Infinte loop found!", acc);
                }
                visited.Add(ptr);
                var line = code[ptr];
                var parse = line.Split(" ");
                var instr = parse[0];
                var arg = int.Parse(parse[1]);
                switch (instr)
                {
                    case "nop":
                        ptr++;
                        break;
                    case "acc":
                        acc += arg;
                        ptr++;
                        break;
                    case "jmp":
                        ptr += arg;
                        break;
                    default:
                        throw new Exception("Bad instr");
                }
            }
            return acc;
        }
    }

    class InfiniteLoopException : Exception
    {
        public int Acc { get; }
        public InfiniteLoopException()
        {
        }

        public InfiniteLoopException(string message) : base(message)
        {
        }

        public InfiniteLoopException(string message, int acc) : base(message)
        {
            Acc = acc;
        }

        public InfiniteLoopException(string message, Exception innerException) : base(message, innerException)
        {
        }

    }
}
