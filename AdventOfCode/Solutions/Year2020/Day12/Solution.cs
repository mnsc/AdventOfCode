using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            var pos = new Position(0, 0, 90);

            foreach (var instruction in _instructions)
            {
                pos = instruction switch
                {
                    ("R", var amt) => pos with { Direction = (360 + pos.Direction + amt) % 360 },
                    ("L", var amt) => pos with { Direction = (360 + pos.Direction - amt) % 360 },

                    (var label, var amt) when (pos.Direction == 0 && label == "F") || label == "N" => pos with { Lng = pos.Lng - amt },
                    (var label, var amt) when (pos.Direction == 90 && label == "F") || label == "E" => pos with { Lat = pos.Lat + amt },
                    (var label, var amt) when (pos.Direction == 180 && label == "F") || label == "S" => pos with { Lng = pos.Lng + amt },
                    (var label, var amt) when (pos.Direction == 270 && label == "F") || label == "W" => pos with { Lat = pos.Lat - amt },

                    var instr => throw new ArgumentOutOfRangeException(pos.ToString() + "," + instr.ToString())
                };
                Debug.WriteLine($"{instruction} -> {pos}");
            }

            return $"{pos} => manhattan = {Math.Abs(pos.Lat) + Math.Abs(pos.Lng)}";
        }

        public record Waypoint(int East, int North);
        public record PositionPt2(int Lat, int Lng, Waypoint Waypoint);

        protected override string SolvePartTwo()
        {
            var pos = new PositionPt2(0, 0, new Waypoint(10, 1));

            foreach (var instruction in _instructions)
            {
                pos = instruction switch
                {
                    ("R", 90) or ("L", 270) => pos with { Waypoint = new Waypoint(pos.Waypoint.North, -pos.Waypoint.East) },
                    ("R", 270) or ("L", 90) => pos with { Waypoint = new Waypoint(-pos.Waypoint.North, pos.Waypoint.East) },
                    ("R", 180) or ("L", 180) => pos with { Waypoint = new Waypoint(-pos.Waypoint.East, -pos.Waypoint.North) },

                    ("N", var amt) => pos with { Waypoint = new Waypoint(pos.Waypoint.East, pos.Waypoint.North + amt) },
                    ("E", var amt) => pos with { Waypoint = new Waypoint(pos.Waypoint.East + amt, pos.Waypoint.North) },
                    ("S", var amt) => pos with { Waypoint = new Waypoint(pos.Waypoint.East, pos.Waypoint.North - amt) },
                    ("W", var amt) => pos with { Waypoint = new Waypoint(pos.Waypoint.East - amt, pos.Waypoint.North) },

                    ("F", var amt) => pos with { Lat = pos.Lat + (amt * pos.Waypoint.East), Lng = pos.Lng + (amt * pos.Waypoint.North) },

                    var instr => throw new ArgumentOutOfRangeException(pos.ToString() + "," + instr.ToString())
                };
                Debug.WriteLine($"{instruction} -> {pos}");
             }

            return $"{pos} => manhattan = {Math.Abs(pos.Lat) + Math.Abs(pos.Lng)}";
        }
    }
}
