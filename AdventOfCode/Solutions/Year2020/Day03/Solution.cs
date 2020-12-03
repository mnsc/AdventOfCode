using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Solutions.Year2020
{

    class Day03 : ASolution
    {

        int _slopeHeight;
        int _slopeWidth;
        char[,] _slope;

        public Day03() : base(03, 2020, "")
        {
//            DebugInput =
//@"..##.......
//#...#...#..
//.#....#..#.
//..#.#...#.#
//.#...##..#.
//..#.##.....
//.#.#.#....#
//.#........#
//#.##...#...
//#...##....#
//.#..#...#.#";
            var rows = Input.SplitByNewline();
            var firstrow = rows[0];
            _slopeHeight = rows.Length;
            _slopeWidth = firstrow.Length;

            _slope = new char[_slopeHeight, _slopeWidth];
            for (int i = 0; i < _slopeHeight; i++)
            {
                for (int j = 0; j < _slopeWidth; j++)
                {
                    _slope[i, j] = rows[i][j];
                }
            }
        }

        protected override string SolvePartOne()
        {
            const int startHorisontalPos = 3;
            const int verticalJump = 1;

            Console.WriteLine("Part 1!");
            var treeHits = SlideDownTheSlope(startHorisontalPos, verticalJump);
            return treeHits.ToString();
        }

        private int SlideDownTheSlope(int startHorisontalPos, int verticalJump)
        {
            Console.WriteLine($"Here we go, starting from {startHorisontalPos}, jumping {verticalJump}!");
            int horisontalPos = startHorisontalPos;
            int treeHits = 0;
            for (int verticalPos = 0 + verticalJump; verticalPos < _slopeHeight; verticalPos += verticalJump)
            {
                var check = _slope[verticalPos, horisontalPos];
                if (check == '#')
                {
                    treeHits++;
                    Console.Write("Ouch! ");
                }

                
                horisontalPos = (horisontalPos + startHorisontalPos) % _slopeWidth;
            }
            Console.WriteLine("");
            Console.WriteLine($"Hits: {treeHits}");
            return treeHits;
        }

        protected override string SolvePartTwo()
        {
            Console.WriteLine("Part 2!");
            var total = 1;
            total *= SlideDownTheSlope(1, 1);
            total *= SlideDownTheSlope(3, 1);
            total *= SlideDownTheSlope(5, 1);
            total *= SlideDownTheSlope(7, 1);
            total *= SlideDownTheSlope(1, 2);

            return total.ToString();
        }
    }
}
