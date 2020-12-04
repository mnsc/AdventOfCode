using System;
using System.Collections.Generic;

namespace AdventOfCode.Solutions.Year2020
{
    public class Passport
    {
        string byr; // (Birth Year)
        string iyr; // (Issue Year)
        string eyr; // (Expiration Year)
        string hgt; // (Height)
        string hcl; // (Hair Color)
        string ecl; // (Eye Color)
        string pid; // (Passport ID)
        string cid; // (Country ID)


        public Passport(string byr, string iyr, string eyr, string hgt, string hcl, string ecl, string pid, string cid)
        {
            if (byr == null)
                throw new ArgumentNullException(nameof(byr));
            this.byr = byr;

            if (iyr == null)
                throw new ArgumentNullException(nameof(iyr));
            this.iyr = iyr;

            if (eyr == null)
                throw new ArgumentNullException(nameof(eyr));
            this.eyr = eyr;

            if (hgt == null)
                throw new ArgumentNullException(nameof(hgt));
            this.hgt = hgt;

            if (hcl == null)
                throw new ArgumentNullException(nameof(hcl));
            this.hcl = hcl;

            if (ecl == null)
                throw new ArgumentNullException(nameof(ecl));
            this.ecl = ecl;

            if (pid == null)
                throw new ArgumentNullException(nameof(pid));
            this.pid = pid;
            this.cid = cid;
        }
    }
    class Day04 : ASolution
    {
        private List<Passport> _passports = new List<Passport>();

        public Day04() : base(04, 2020, "")
        {
            string byr = null;
            string iyr = null;
            string eyr = null;
            string hgt = null;
            string hcl = null;
            string ecl = null;
            string pid = null;
            string cid = null;
            foreach (var line in Input.SplitByNewline(emptyLines: true))
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    AddPassport(byr, iyr, eyr, hgt, hcl, ecl, pid, cid);
                    byr = null;
                    iyr = null;
                    eyr = null;
                    hgt = null;
                    hcl = null;
                    ecl = null;
                    pid = null;
                    cid = null;
                    continue;
                }
                foreach (var keyvalue in line.Split(" "))
                {
                    var split = keyvalue.Split(":");
                    switch (split[0])
                    {
                        case "byr":
                            byr = split[1];
                            break;
                        case "iyr":
                            iyr = split[1];
                            break;
                        case "eyr":
                            eyr = split[1];
                            break;
                        case "hgt":
                            hgt = split[1];
                            break;
                        case "hcl":
                            hcl = split[1];
                            break;
                        case "ecl":
                            ecl = split[1];
                            break;
                        case "pid":
                            pid = split[1];
                            break;
                        case "cid":
                            cid = split[1];
                            break;
                    }
                }
            }
            AddPassport(byr, iyr, eyr, hgt, hcl, ecl, pid, cid);
        }

        private void AddPassport(string byr, string iyr, string eyr, string hgt, string hcl, string ecl, string pid, string cid)
        {
            try
            {
                var passportTmp = new Passport(byr, iyr, eyr, hgt, hcl, ecl, pid, cid);
                _passports.Add(passportTmp);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        protected override string SolvePartOne()
        {
            return _passports.Count.ToString();
        }

        protected override string SolvePartTwo()
        {
            return null;
        }
    }
}
