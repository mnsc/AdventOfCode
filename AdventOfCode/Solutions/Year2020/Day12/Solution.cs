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
            Position MoveNorth(Position pos, int amt) => pos with { Lng = pos.Lng - amt };
            Position MoveEast(Position pos, int amt) => pos with { Lat = pos.Lat + amt };
            Position MoveSouth(Position pos, int amt) => pos with { Lng = pos.Lng + amt };
            Position MoveWest(Position pos, int amt) => pos with { Lat = pos.Lat - amt };

            var currentPosition = new Position(0, 0, 90);

            foreach (var instruction in _instructions)
            {
                currentPosition = (currentPosition, instruction) switch
                {
                    (var pos, ("R", var amt)) => pos with { Direction = (360 + pos.Direction + amt) % 360 },
                    (var pos, ("L", var amt)) => pos with { Direction = (360 + pos.Direction - amt) % 360 },

                    (var pos, ("N", var amt)) => MoveNorth(pos, amt),
                    (var pos, ("S", var amt)) => MoveSouth(pos, amt),
                    (var pos, ("W", var amt)) => MoveWest(pos, amt),
                    (var pos, ("E", var amt)) => MoveEast(pos, amt),

                    (var pos, ("F", var amt)) and ((_, _, 90), (_, _)) => MoveEast(pos, amt),
                    (var pos, ("F", var amt)) and ((_, _, 180), (_, _)) => MoveSouth(pos, amt),
                    (var pos, ("F", var amt)) and ((_, _, 270), (_, _)) => MoveWest(pos, amt),
                    (var pos, ("F", var amt)) and ((_, _, 0), (_, _)) => MoveNorth(pos, amt),
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
