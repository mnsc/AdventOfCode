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
            DebugInput = @"mask = 000000000000000000000000000000X1001X
mem[42] = 100
mask = 00000000000000000000000000000000X0XX
mem[26] = 1";
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
                    var writeToMemory = (WriteToMemory)instr;
                    memory[writeToMemory.Memory] = ApplyMask(writeToMemory.Value, currentmask);
                }
            }

            return $"memory total sum is: {memory.Sum(kv => kv.Value)}";
        }

        private long ApplyMask(int value, string mask)
        {
            var valueAsBits = Convert.ToString(value, 2).PadLeft(36, '0');
            var masked = string.Concat(valueAsBits.Zip(mask, (v, mask) => mask == 'X' ? v : mask));
            return Convert.ToInt64(masked, 2);
        }

        protected override string SolvePartTwo()
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
                    var writeToMemory = (WriteToMemory)instr;
                    var setValue = ApplyMask(writeToMemory.Value, currentmask);
                    var floatingAddress = ApplyMaskWithFloating(writeToMemory.Memory, currentmask);
                    var addressesToWrite = GetAllFixedAddresses(floatingAddress);

                    foreach (var address in addressesToWrite)
                    {
                        memory[address] = setValue;
                    }
                }
            }

            return null;
        }

        private List<int> GetAllFixedAddresses(string floatingAddress)
        {
            return new List<int>{ 1, 2, 3};
        }

        private string ApplyMaskWithFloating(int value, string mask)
        {
            var valueAsBits = Convert.ToString(value, 2).PadLeft(36, '0');
            return string.Concat(valueAsBits.Zip(mask, (v, mask) => mask == 'X' ? 'F' : mask == '1' ? '1' : v));
        }
    }
}
