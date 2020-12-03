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
            const int startVerticalPos = 1;

            var treeHits = SlideDownTheSlope(startHorisontalPos, startVerticalPos);
            return treeHits.ToString();
        }

        private int SlideDownTheSlope(int startHorisontalPos, int startVerticalPos)
        {
            int horisontalPos = startHorisontalPos;
            int treeHits = 0;
            for (int verticalPos = startVerticalPos; verticalPos < _slopeHeight; verticalPos++)
            {
                var check = _slope[verticalPos, horisontalPos];
                if (check == '#')
                {
                    treeHits++;
                }

                Console.WriteLine(new string('.', horisontalPos) + (check == '#' ? "# (ouch!)" : "O"));
                horisontalPos = (horisontalPos + startHorisontalPos) % _slopeWidth;
            }

            return treeHits;
        }

        protected override string SolvePartTwo()
        {
            return null;
        }
    }
}
