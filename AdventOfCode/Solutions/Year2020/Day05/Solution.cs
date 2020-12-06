using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Solutions.Year2020
{

    public class BoardingPass
    {
        public BoardingPass(string code)
        {
            Code = code;
            Row = Convert.ToInt32(code.Substring(0, 7).Replace("B", "1").Replace("F", "0"), 2);
            Column = Convert.ToInt32(code.Substring(7, 3).Replace("R", "1").Replace("L", "0"), 2);
            SeatId = Row * 8 + Column;
        }

        public string Code { get; }
        public int Row { get; }
        public int Column { get; }
        public int SeatId { get; }
    }
    class Day05 : ASolution
    {
        private List<BoardingPass> _boardingPasses = new List<BoardingPass>();

        public Day05() : base(05, 2020, "")
        {
            _boardingPasses = Input.SplitByNewline().Select(c => new BoardingPass(c)).ToList();
        }

        protected override string SolvePartOne()
        {
            return _boardingPasses.Max(bp => bp.SeatId).ToString();
        }

        protected override string SolvePartTwo()
        {
            var orderedSeats = _boardingPasses.Select(bp=>bp.SeatId).OrderBy(seatId => seatId);
            int current = orderedSeats.First();
            foreach (var seat in orderedSeats.Skip(1))
            {
                if(seat-current == 2)
                {
                    return (current + 1).ToString();
                }
                current = seat;
            }
            return null;
        }
    

    }
}
