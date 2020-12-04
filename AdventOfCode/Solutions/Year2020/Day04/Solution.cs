using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solutions.Year2020
{
    public class Passport
    {
        public string byr; // (Birth Year)
        public string iyr; // (Issue Year)
        public string eyr; // (Expiration Year)
        public string hgt; // (Height)
        public string hcl; // (Hair Color)
        public string ecl; // (Eye Color)
        public string pid; // (Passport ID)
        public string cid; // (Country ID)

        public bool IsValid()
        {
            return
                byr != null
&& iyr != null
&& eyr != null
&& hgt != null
&& hcl != null
&& ecl != null
&& pid != null
//&& cid != null missing country is ok!
;
        }
    }
    class Day04 : ASolution
    {
        private List<Passport> _passports = new List<Passport>();

        public Day04() : base(04, 2020, "")
        {
            //            DebugInput = @"ecl:gry pid:860033327 eyr:2020 hcl:#fffffd
            //byr:1937 iyr:2017 cid:147 hgt:183cm

            //iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884
            //hcl:#cfa07d byr:1929

            //hcl:#ae17e1 iyr:2013
            //eyr:2024
            //ecl:brn pid:760753108 byr:1931
            //hgt:179cm

            //hcl:#cfa07d eyr:2025 pid:166559648
            //iyr:2011 ecl:brn hgt:59in
            //";
            var passportTmp = new Passport();
            foreach (var line in Input.SplitByNewline(emptyLines: true))
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    _passports.Add(passportTmp);
                    passportTmp = new Passport();
                    continue;
                }
                foreach (var keyvalue in line.Split(" "))
                {
                    var split = keyvalue.Split(":");
                    switch (split[0])
                    {
                        case "byr":
                            passportTmp.byr = split[1];
                            break;
                        case "iyr":
                            passportTmp.iyr = split[1];
                            break;
                        case "eyr":
                            passportTmp.eyr = split[1];
                            break;
                        case "hgt":
                            passportTmp.hgt = split[1];
                            break;
                        case "hcl":
                            passportTmp.hcl = split[1];
                            break;
                        case "ecl":
                            passportTmp.ecl = split[1];
                            break;
                        case "pid":
                            passportTmp.pid = split[1];
                            break;
                        case "cid":
                            passportTmp.cid = split[1];
                            break;
                    }
                }
            }
            _passports.Add(passportTmp);
        }

        protected override string SolvePartOne()
        {
            return _passports.Count(prop => prop.IsValid()).ToString();
        }

        protected override string SolvePartTwo()
        {
            return null;
        }
    }
}
