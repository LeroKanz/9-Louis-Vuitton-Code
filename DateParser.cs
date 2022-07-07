using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LouisVuittonCode
{
    public static class DateParser
    {
        public static void ParseEarly1980Code(string dateCode, out uint manufacturingYear, out uint manufacturingMonth)
        {
            if (string.IsNullOrEmpty(dateCode))
            {
                throw new ArgumentNullException(nameof(dateCode));
            }

            if (dateCode.Length < 3 || dateCode.Length > 4)
            {
                throw new ArgumentException("Incorrect value");
            }

            manufacturingYear = uint.Parse(dateCode[..2], CultureInfo.CurrentCulture) + 1900;
            manufacturingMonth = uint.Parse(dateCode[2..], CultureInfo.CurrentCulture);

            if (manufacturingMonth <= 0 || manufacturingMonth > 12)
            {
                throw new ArgumentException("Incorrect value");
            }

            if (manufacturingYear < 1980 || manufacturingYear >= 1990)
            {
                throw new ArgumentException("Incorrect value");
            }
        }

        public static void ParseLate1980Code(string dateCode, out Country[] factoryLocationCountry, out string factoryLocationCode, out uint manufacturingYear, out uint manufacturingMonth)
        {
            if (string.IsNullOrEmpty(dateCode))
            {
                throw new ArgumentNullException(nameof(dateCode));
            }

            if (dateCode.Length < 5 || dateCode.Length > 6)
            {
                throw new ArgumentException("Incorrect value");
            }

            factoryLocationCode = dateCode[^2..];
            factoryLocationCountry = Parser.GetCountry(factoryLocationCode);
            manufacturingYear = uint.Parse(dateCode[..2], CultureInfo.CurrentCulture) + 1900;
            manufacturingMonth = uint.Parse(dateCode[2..^2], CultureInfo.CurrentCulture);

            if (manufacturingMonth <= 0 || manufacturingMonth > 12)
            {
                throw new ArgumentException("Incorrect value");
            }

            if (manufacturingYear < 1980 || manufacturingYear >= 1990)
            {
                throw new ArgumentException("Incorrect value");
            }
        }

        public static void Parse1990Code(string dateCode, out Country[] factoryLocationCountry, out string factoryLocationCode, out uint manufacturingYear, out uint manufacturingMonth)
        {
            if (string.IsNullOrEmpty(dateCode))
            {
                throw new ArgumentNullException(nameof(dateCode));
            }

            if (dateCode.Length != 6)
            {
                throw new ArgumentException("Incorrect value");
            }

            factoryLocationCode = dateCode[..2];
            factoryLocationCountry = Parser.GetCountry(factoryLocationCode);

            StringBuilder month = new StringBuilder();
            month.Append(dateCode[2]);
            month.Append(dateCode[4]);

            manufacturingMonth = uint.Parse(month.ToString(), CultureInfo.CurrentCulture);

            StringBuilder year = new StringBuilder();
            year.Append(dateCode[3]);
            year.Append(dateCode[5]);

            manufacturingYear = uint.Parse(year.ToString(), CultureInfo.CurrentCulture);
            if (manufacturingYear >= 90)
            {
                manufacturingYear += 1900u;
            }
            else
            {
                manufacturingYear += 2000u;
            }

            if (manufacturingMonth <= 0 || manufacturingMonth > 12)
            {
                throw new ArgumentException("Incorrect value");
            }

            if (manufacturingYear < 1990 || manufacturingYear > 2006)
            {
                throw new ArgumentException("Incorrect value");
            }
        }

        public static void Parse2007Code(string dateCode, out Country[] factoryLocationCountry, out string factoryLocationCode, out uint manufacturingYear, out uint manufacturingWeek)
        {
            if (string.IsNullOrEmpty(dateCode))
            {
                throw new ArgumentNullException(nameof(dateCode));
            }

            if (dateCode.Length != 6)
            {
                throw new ArgumentException("Incorrect value");
            }

            factoryLocationCode = dateCode[..2];
            factoryLocationCountry = Parser.GetCountry(factoryLocationCode);

            StringBuilder week = new StringBuilder();
            week.Append(dateCode[2]);
            week.Append(dateCode[4]);

            manufacturingWeek = uint.Parse(week.ToString(), CultureInfo.CurrentCulture);

            StringBuilder year = new StringBuilder();
            year.Append(dateCode[3]);
            year.Append(dateCode[5]);

            manufacturingYear = uint.Parse(year.ToString(), CultureInfo.CurrentCulture);
            if (manufacturingYear >= 90)
            {
                manufacturingYear += 1900u;
            }
            else
            {
                manufacturingYear += 2000u;
            }

            if (manufacturingWeek <= 0 || manufacturingWeek >= 53)
            {
                throw new ArgumentException("Incorrect value");
            }

            if (manufacturingYear < 2007 || manufacturingYear > DateTime.Now.Year)
            {
                throw new ArgumentException("Incorrect value");
            }
        }
    }
}
