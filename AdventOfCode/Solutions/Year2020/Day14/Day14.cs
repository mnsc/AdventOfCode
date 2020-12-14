using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Solutions.Year2020
{

    class Day14 : ASolution
    {
        public record Instruction();
        public record ChangeMask(string NewMask) : Instruction();
        public record WriteToMemory(int Memory, int Value) : Instruction();

        private List<Instruction> _input;

        public Day14() : base(14, 2020, "")
        {
            _input = Input
                .SplitByNewline()
                .Select(ConvertToInstruction)
            .ToList();
        }

        private Instruction ConvertToInstruction(string line)
        {
            var tmp = line.Split(new char[] { '=', '[', ']' }, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            if (tmp.Length == 3)
                return new WriteToMemory(int.Parse(tmp[1]), int.Parse(tmp[2]));
            else
                return new ChangeMask(tmp[1]);
        }

        protected override string SolvePartOne()
        {
            var memory = new Dictionary<int, long>();
            string currentmask = "";
            foreach (var instr in _input)
            {
                if (instr is ChangeMask)
                {
                    currentmask = ((ChangeMask)instr).NewMask;
                }
                else
                {
                    var setValue = (WriteToMemory)instr;
                    memory[setValue.Memory] = ApplyMask(setValue.Value, currentmask);
                }
            }

            return $"memory total sum is: {memory.Sum(kv => kv.Value)}";
        }

        private long ApplyMask(int value, string mask)
        {
            var valueAsBits = Convert.ToString(value, 2).PadLeft(36, '0');
            var masked = String.Concat(valueAsBits.Zip(mask, (v, mask) => mask == 'X' ? v : mask));
            return Convert.ToInt64(masked, 2);
        }

        protected override string SolvePartTwo()
        {
            return null;
        }
    }
}
