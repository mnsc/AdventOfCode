using System;
using System.Collections.Generic;
using System.Linq;
using static AdventOfCode.Solutions.Utilities;

namespace AdventOfCode.Solutions.Year2020
{
    public record Position(int Lat, int Lng, int Direction);

    class Day12 : ASolution
    {
        List<Instruction> _instructions;
        public Day12() : base(12, 2020, "")
        {
            _instructions = Input.SplitByNewline().Select(x => x.GetInstruction()).ToList();
        }

        protected override string SolvePartOne()
        {
            var currentPosition = new Position(0, 0, 90);

            foreach (var instruction in _instructions)
            {
                currentPosition = (currentPosition, instruction) switch
                {
                    (var pos, ("R", var amt)) => pos with { Direction = (360 + pos.Direction + amt) % 360 },
                    (var pos, ("L", var amt)) => pos with { Direction = (360 + pos.Direction - amt) % 360 },

                    (var pos, (var label, var amt)) when (pos.Direction == 0 && label == "F") || label == "N" => pos with { Lng = pos.Lng - amt },
                    (var pos, (var label, var amt)) when (pos.Direction == 90 && label == "F") || label == "E" => pos with { Lat = pos.Lat + amt },
                    (var pos, (var label, var amt)) when (pos.Direction == 180 && label == "F") || label == "S" => pos with { Lng = pos.Lng + amt },
                    (var pos, (var label, var amt)) when (pos.Direction == 270 && label == "F") || label == "W" => pos with { Lat = pos.Lat - amt },

                    (var pos, var instr) => throw new ArgumentOutOfRangeException(pos.ToString() + "," + instr.ToString())
                };
                Console.WriteLine($"{instruction} -> {currentPosition}");
            }

            return $"{currentPosition} => manhattan = {Math.Abs(currentPosition.Lat) + Math.Abs(currentPosition.Lng)}";
        }

        protected override string SolvePartTwo()
        {
            return null;
        }
    }
}
