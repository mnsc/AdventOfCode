using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solutions.Year2020
{

    class Day01 : ASolution
    {
        private readonly List<int> _input;

        public Day01() : base(01, 2020, "")
        {
            _input = Input.SplitByNewline().Select(int.Parse).ToList();
        }

        protected override string SolvePartOne()
        {
            for (var i = 0; i < _input.Count - 1; i++)
                for (var j = i + 1; j < _input.Count; j++)
                    if (_input[i] + _input[j] == 2020)
                        return (_input[i] * _input[j]).ToString();
            return "";
        }

        protected override string SolvePartTwo()
        {
            for (var i = 0; i < _input.Count - 2; i++)
                for (var j = i + 1; j < _input.Count - 1; j++)
                    for (var k = i + 1; k < _input.Count; k++)
                        if (_input[i] + _input[j] + _input[k] == 2020)
                            return (_input[i] * _input[j] * _input[k]).ToString();
            return "";
        }
    }
}
