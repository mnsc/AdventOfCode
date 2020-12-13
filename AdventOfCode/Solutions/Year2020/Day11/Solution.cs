using System;

namespace AdventOfCode.Solutions.Year2020
{

    class Day11 : ASolution
    {
        private readonly char[,] _startState;

        public Day11() : base(11, 2020, "")
        {
            DebugInput =
@"L.LL.LL.LL
LLLLLLL.LL
L.L.L..L..
LLLL.LL.LL
L.LL.LL.LL
L.LLLLL.LL
..L.L.....
LLLLLLLLLL
L.LLLLLL.L
L.LLLLL.LL";
            _startState = Input.ParseCharArray2D();
        }
        private (bool, char[,]) Tick(char[,] inState)
        {
            var outState = new char[inState.GetLength(0), inState.GetLength(1)];
            var modified = false;
            for (var i = 0; i < inState.GetLength(0); i++)
            {
                for (var j = 0; j < inState.GetLength(1); j++)
                {
                    var neighboursOccupied = CountNeighbourSeatsOccupied(inState, i, j);
                    if (neighboursOccupied == 0)
                    {
                        if (inState[i, j] == 'L')
                        {
                            outState[i, j] = '#';
                            modified = true;
                        }
                        else
                        {
                            outState[i, j] = inState[i, j];
                        }
                    }
                    else if (neighboursOccupied >= 4)
                    {
                        if (inState[i, j] == '#')
                        {
                            outState[i, j] = 'L';
                            modified = true;
                        }
                        else
                        {
                            outState[i, j] = inState[i, j];
                        }
                    }
                    else
                    {
                        outState[i, j] = inState[i, j];
                    }
                }
            }

            return (modified, outState);
        }

        private int CountNeighbourSeatsOccupied(char[,] inState, int i, int j)
        {
            var occupied = 0;
            //I||
            if (i - 1 >= 0 && j - 1 >= 0)
            {
                occupied += inState[i - 1, j - 1] == '#' ? 1 : 0;
            }
            if (i - 1 >= 0)
            {
                occupied += inState[i - 1, j] == '#' ? 1 : 0;
            }
            if (i - 1 >= 0 && j + 1 < inState.GetLength(1))
            {
                occupied += inState[i - 1, j + 1] == '#' ? 1 : 0;
            }

            //|I|
            if (j - 1 >= 0)
            {
                occupied += inState[i, j - 1] == '#' ? 1 : 0;
            }
            if (j + 1 < inState.GetLength(1))
            {
                occupied += inState[i, j + 1] == '#' ? 1 : 0;
            }

            //||I
            if (i + 1 < inState.GetLength(0) && j - 1 >= 0)
            {
                occupied += inState[i + 1, j - 1] == '#' ? 1 : 0;
            }
            if (i + 1 < inState.GetLength(0))
            {
                occupied += inState[i + 1, j] == '#' ? 1 : 0;
            }
            if (i + 1 < inState.GetLength(0) && j + 1 < inState.GetLength(1))
            {
                occupied += inState[i + 1, j + 1] == '#' ? 1 : 0;
            }
            return occupied;
        }

        protected override string SolvePartOne()
        {
            PrintState(_startState);

            Console.WriteLine("Lets go!");
            (var _, var currentState) = Tick(_startState);
            PrintState(currentState);
            var stable = false;
            while (!stable)
            {
                Console.WriteLine("");
                Console.WriteLine("Tick!");
                Console.WriteLine("");
                (var modifiedNow, var newState) = Tick(currentState);
                PrintState(newState);
                stable = !modifiedNow;
                currentState = newState;
            }

            var seatsOccupied = 0;
            foreach (var seat in currentState)
            {
                if (seat == '#')
                {
                    seatsOccupied++;
                }
            }
            return seatsOccupied.ToString();
        }

        private void PrintState(char[,] state)
        {
            for (var i = 0; i < state.GetLength(0); i++)
            {
                for (var j = 0; j < state.GetLength(1); j++)
                {
                    Console.Write(state[i, j]);
                }
                Console.WriteLine();
            }
        }

        protected override string SolvePartTwo()
        {
            return null;
        }
    }
}
