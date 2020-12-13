using System;
using System.Diagnostics;

namespace AdventOfCode.Solutions.Year2020
{

    class Day11 : ASolution
    {
        enum Strategy
        {
            Immediate, Sight
        }

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
        private (bool, char[,]) Tick(char[,] inState, Strategy strategy)
        {
            var outState = new char[inState.GetLength(0), inState.GetLength(1)];
            var modified = false;
            for (var i = 0; i < inState.GetLength(0); i++)
            {
                for (var j = 0; j < inState.GetLength(1); j++)
                {
                    var neighboursOccupied = CountNeighbourSeatsOccupied(inState, i, j, strategy);
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
                    else if (neighboursOccupied >= (strategy == Strategy.Immediate ? 4 : 5))
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

        private int CountNeighbourSeatsOccupied(char[,] inState, int i, int j, Strategy strategy)
        {
            var occupied = 0;
            int step = 1;
            //↖
            while (i - step >= 0 && j - step >= 0)
            {
                if(inState[i - step, j - step] == '#')
                {
                    occupied++;
                    break;
                }
                else if (strategy == Strategy.Sight)
                {
                    step++;
                }
                else
                {
                    break;
                }
            }
            //⬆
            while (i - step >= 0)
            {
                if (inState[i - step, j] == '#')
                {
                    occupied++;
                    break;
                }
                else if (strategy == Strategy.Sight)
                {
                    step++;
                }
                else
                {
                    break;
                }
            }
            //↗
            while (i - step >= 0 && j + step < inState.GetLength(1))
            {
                if (inState[i - step, j + step] == '#')
                {
                    occupied++;
                    break;
                }
                else if (strategy == Strategy.Sight)
                {
                    step++;
                }
                else
                {
                    break;
                }
            }

            //⬅
            while (j - step >= 0)
            {
                if (inState[i, j - step] == '#')
                {
                    occupied++;
                    break;
                }
                else if (strategy == Strategy.Sight)
                {
                    step++;
                }
                else
                {
                    break;
                }
            }

            //➡
            while (j + step < inState.GetLength(1))
            {
                if (inState[i, j + step] == '#')
                {
                    occupied++;
                    break;
                }
                else if (strategy == Strategy.Sight)
                {
                    step++;
                }
                else
                {
                    break;
                }
            }

            // ↙
            while (i + step < inState.GetLength(0) && j - step >= 0)
            {
                if (inState[i + step, j - step] == '#')
                {
                    occupied++;
                    break;
                }
                else if (strategy == Strategy.Sight)
                {
                    step++;
                }
                else
                {
                    break;
                }
            }

            //⬇
            while (i + step < inState.GetLength(0))
            {
                if (inState[i + step, j] == '#')
                {
                    occupied++;
                    break;
                }
                else if (strategy == Strategy.Sight)
                {
                    step++;
                }
                else
                {
                    break;
                }
            }
            //↘
            while (i + step < inState.GetLength(0) && j + step < inState.GetLength(1))
            {
                if (inState[i + step, j + step] == '#')
                {
                    occupied++;
                    break;
                }
                else if (strategy == Strategy.Sight)
                {
                    step++;
                }
                else
                {
                    break;
                }
            }

          
            return occupied;
        }

        protected override string SolvePartOne()
        {
            PrintState(_startState);

            Console.WriteLine("Lets go!");
            (var _, var currentState) = Tick(_startState, Strategy.Immediate);
            var stable = false;
            while (!stable)
            {
                (var modifiedNow, var newState) = Tick(currentState, Strategy.Immediate);
                stable = !modifiedNow;
                currentState = newState;
            }

            var seatsOccupied = CountTotalOccupiedSeats(currentState);
            Debug.Assert(seatsOccupied == 37);
            return seatsOccupied.ToString();
        }

        private static int CountTotalOccupiedSeats(char[,] currentState)
        {
            var seatsOccupied = 0;
            foreach (var seat in currentState)
            {
                if (seat == '#')
                {
                    seatsOccupied++;
                }
            }

            return seatsOccupied;
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
            PrintState(_startState);

            Console.WriteLine("Lets go!");
            (var _, var currentState) = Tick(_startState, Strategy.Sight);
            PrintState(currentState);
           
            var stable = false;
            while (!stable)
            {
                (var modifiedNow, var newState) = Tick(currentState, Strategy.Sight);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                PrintState(newState);
                stable = !modifiedNow;
                currentState = newState;
            }

            var seatsOccupied = CountTotalOccupiedSeats(currentState);
            return seatsOccupied.ToString();
        }
    }
}
