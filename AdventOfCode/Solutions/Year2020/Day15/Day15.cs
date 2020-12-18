using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Solutions.Year2020
{

    class Day15 : ASolution
    {

        public Day15() : base(15, 2020, "")
        {
         
        }

        protected override string SolvePartOne()
        {
            const int startSize = 6;
            const int gameSize = 2020;
            int[] game = new int[startSize] { 10, 16, 6, 0, 1, 17 };
            Array.Resize(ref game, gameSize);

            for (int i = startSize; i < game.Length; i++)
            {
                int lastspoken = game[i - 1];
                var mostrecentIndex = Array.FindLastIndex(game, i - 2, i => i == lastspoken);
                game[i] = mostrecentIndex == -1 ? 0 : i - (mostrecentIndex + 1) ;
            }
            return game[gameSize-1].ToString();
        }

        protected override string SolvePartTwo()
        {
            const int startSize = 6;
            const int gameSize = 30000000;
            int[] game = new int[startSize] { 10, 16, 6, 0, 1, 17 };
            Array.Resize(ref game, gameSize);

            for (int i = startSize; i < game.Length; i++)
            {
                int lastspoken = game[i - 1];
                var mostrecentIndex = Array.FindLastIndex(game, i - 2, i => i == lastspoken);
                game[i] = mostrecentIndex == -1 ? 0 : i - (mostrecentIndex + 1);
            }
            return game[gameSize - 1].ToString();
        }
    }
}
