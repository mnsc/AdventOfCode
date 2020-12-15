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
//            DebugInput = @"mask = 000000000000000000000000000000X1001X
//mem[42] = 100
//mask = 00000000000000000000000000000000X0XX
//mem[26] = 1";
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

            var memory = new Dictionary<long, long>();
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
                    var floatingAddress = ApplyMaskWithFloating(writeToMemory.Memory, currentmask);
                    foreach (var address in GetAllFixedAddresses(floatingAddress))
                    {
                        memory[address] = writeToMemory.Value;
                    }
                }
            }


            return $"memory total sum is: {memory.Sum(kv => kv.Value)}";
        }

        private List<long> GetAllFixedAddresses(string floatingAddress)
        {
            List<long> addresses = new List<long>();
            var floatsWithPos = floatingAddress.Select((c, idx) => (c, idx)).Where(t => t.c == 'F').ToArray();
            for (int i = 0; i < Math.Pow(2, floatsWithPos.Length); i++)
            {
                var bitCombo = Convert.ToString(i, 2).PadLeft(floatsWithPos.Length, '0');
                var fixedAddress = floatingAddress.ToArray();
                for (int j = 0; j < floatsWithPos.Length; j++)
                {
                    fixedAddress[floatsWithPos[j].idx] = bitCombo[j];
                }
                addresses.Add(Convert.ToInt64(string.Concat(fixedAddress), 2));
            }
            return addresses;
        }

        private string ApplyMaskWithFloating(int value, string mask)
        {
            var valueAsBits = Convert.ToString(value, 2).PadLeft(36, '0');
            return string.Concat(valueAsBits.Zip(mask, (v, mask) => mask == 'X' ? 'F' : mask == '1' ? '1' : v));
        }
    }
}
