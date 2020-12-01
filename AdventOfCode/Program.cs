using AdventOfCode.Solutions;

namespace AdventOfCode
{

    static class Program
    {
        public static Config Config = Config.Get("config.json");
        static SolutionCollector Solutions = new SolutionCollector(Config.Year, Config.Days);

        static void Main(string[] args)
        {
            foreach(ASolution solution in Solutions)
            {
                solution.Solve();
            }
        }
    }
}
