using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode.Solutions.Year2020
{
    public class Passport
    {
        static readonly List<string> validColors = new List<string>() { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };

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
            if (int.TryParse(byr, out int byrTmp) && byrTmp >= 1920 && byrTmp <= 2002)
                this.byr = byr;
            else
                throw new ArgumentOutOfRangeException(nameof(byr), byr);

            if (iyr == null)
                throw new ArgumentNullException(nameof(iyr));
            if (int.TryParse(iyr, out int iyrTmp) && iyrTmp >= 2010 && iyrTmp <= 2020)
                this.iyr = iyr;
            else
                throw new ArgumentOutOfRangeException(nameof(iyr), iyr);

            if (eyr == null)
                throw new ArgumentNullException(nameof(eyr));
            if (int.TryParse(eyr, out int eyrTmp) && eyrTmp >= 2020 && eyrTmp <= 2030)
                this.eyr = eyr;
            else
                throw new ArgumentOutOfRangeException(nameof(eyr), eyr);


            if (hgt == null)
                throw new ArgumentNullException(nameof(hgt));
            if (ValidateHeight(hgt))
                this.hgt = hgt;
            else
                throw new ArgumentOutOfRangeException(nameof(hgt), hgt);

            if (hcl == null)
                throw new ArgumentNullException(nameof(hcl));
            if (ValidateHairColor(hcl))
                this.hcl = hcl;
            else
                throw new ArgumentOutOfRangeException(nameof(hcl), hcl);

            if (ecl == null)
                throw new ArgumentNullException(nameof(ecl));
            if (ValidateEyeColor(ecl))
                this.ecl = ecl;
            else
                throw new ArgumentOutOfRangeException(nameof(ecl), ecl);

            if (pid == null)
                throw new ArgumentNullException(nameof(pid));
            if (ValidatePassportId(pid))
                this.pid = pid;
            else
                throw new ArgumentOutOfRangeException(nameof(pid), pid);

            this.cid = cid;
        }

        private static bool ValidateHeight(string hgt)
        {
            var match = Regex.Match(hgt, @"^(\d+)(in|cm)$");
            if (match.Groups.Count != 3)
                return false;

            int hgtTmp = int.Parse(match.Groups[1].Value);
            if (match.Groups[2].Value == "in")
            {
                //If in, the number must be at least 59 and at most 76.
                return hgtTmp >= 59 && hgtTmp <= 76;
            }
            if (match.Groups[2].Value == "cm")
            {
                //If cm, the number must be at least 150 and at most 193.
                return hgtTmp >= 150 && hgtTmp <= 193;
            }
            else return false;
        }

        private static bool ValidateHairColor(string hcl)
        {
            return Regex.IsMatch(hcl, "^#[0-9a-f]{6}$");
        }

        private static bool ValidateEyeColor(string ecl)
        {
            return validColors.Contains(ecl);
        }

        private static bool ValidatePassportId(string pid)
        {
            return Regex.IsMatch(pid, @"^\d{9}$");
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
                            byr += split[1];
                            break;
                        case "iyr":
                            iyr += split[1];
                            break;
                        case "eyr":
                            eyr += split[1];
                            break;
                        case "hgt":
                            hgt += split[1];
                            break;
                        case "hcl":
                            hcl += split[1];
                            break;
                        case "ecl":
                            ecl += split[1];
                            break;
                        case "pid":
                            pid += split[1];
                            break;
                        case "cid":
                            cid += split[1];
                            break;
                    }
                }
            }
            AddPassport(byr, iyr, eyr, hgt, hcl, ecl, pid, cid);
        }

        private void AddPassport(string byr, string iyr, string eyr, string hgt, string hcl, string ecl, string pid, string cid)
        {
            var dbg = $"{byr};{iyr};{eyr};{hgt};{hcl};{ecl};{pid};{cid}";
            try
            {

                var passportTmp = new Passport(byr, iyr, eyr, hgt, hcl, ecl, pid, cid);
                Console.WriteLine(dbg);
                _passports.Add(passportTmp);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(dbg + ";Parameter out of range: " + e.Message);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(dbg + ";" + e.Message);
            }

        }

        protected override string SolvePartOne()
        {
            return null;
        }

        protected override string SolvePartTwo()
        {
            return _passports.Count.ToString();
        }
    }
}
