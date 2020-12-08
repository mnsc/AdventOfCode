using System;
using System.Collections.Generic;

namespace AdventOfCode.Solutions.Year2020
{

    class Day08 : ASolution
    {

        public Day08() : base(08, 2020, "")
        {
        }

        protected override string SolvePartOne()
        {
            var code = Input.SplitByNewline();

            try
            {
                var returnvalue = RunCode(code);
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
            var code = Input.SplitByNewline();
            var returnvalue = 0;

            for (var i = 0; i < code.Length; i++)
            {
                var codeCopy = (string[])code.Clone();
                var line = codeCopy[i];
                var parse = line.Split(" ");
                var instr = parse[0];
                var modified = false;
                if (instr == "jmp")
                {
                    codeCopy[i] = codeCopy[i].Replace("jmp", "nop");
                    modified = true;
                }
                if (instr == "nop")
                {
                    codeCopy[i] = codeCopy[i].Replace("nop", "jmp");
                    modified = true;
                }
                if (modified)
                {
                    try
                    {
                        returnvalue = RunCode(codeCopy);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                    return returnvalue.ToString();
                }
            }

            return null;
        }

        private static int RunCode(string[] code)
        {
            var ptr = 0;
            var acc = 0;
            var visited = new HashSet<int>();

            while (ptr < code.Length)
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
