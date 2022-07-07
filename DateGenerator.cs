using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LouisVuittonCode
{
    public static class DateGenerator
    {
        public static string GenerateEarly1980Code(uint manufacturingYear, uint manufacturingMonth)
        {
            if (manufacturingMonth <= 0 || manufacturingMonth > 12)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingMonth));
            }

            if (manufacturingYear < 1980 || manufacturingYear >= 1990)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingYear));
            }

            StringBuilder code = new StringBuilder();
            code.Append(manufacturingYear);
            code.Append(manufacturingMonth);
            string result = code.ToString();

            return result[2..];
        }

        public static string GenerateEarly1980Code(DateTime manufacturingDate)
        {
            if (manufacturingDate < new DateTime(1980, 1, 1) || manufacturingDate >= new DateTime(1990, 1, 1))
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingDate));
            }

            StringBuilder code = new StringBuilder();
            code.Append(manufacturingDate.ToString("yy", CultureInfo.CurrentCulture));
            code.Append(manufacturingDate.Month);
            string result = code.ToString();

            return result;
        }

        public static string GenerateLate1980Code(string factoryLocationCode, uint manufacturingYear, uint manufacturingMonth)
        {
            if (manufacturingMonth <= 0 || manufacturingMonth > 12)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingMonth));
            }

            if (manufacturingYear < 1980 || manufacturingYear >= 1990)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingYear));
            }

            if (string.IsNullOrWhiteSpace(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            if (factoryLocationCode.Length != 2 || !Regex.IsMatch(factoryLocationCode, @"^[a-zA-Z]+$"))
            {
                throw new ArgumentException("incorrect argument");
            }

            StringBuilder code = new StringBuilder();
            code.Append(manufacturingYear);
            code.Append(manufacturingMonth);
            code.Append(factoryLocationCode.ToUpper(CultureInfo.CurrentCulture));
            string result = code.ToString();

            return result[2..];
        }

        public static string GenerateLate1980Code(string factoryLocationCode, DateTime manufacturingDate)
        {
            if (manufacturingDate < new DateTime(1980, 1, 1) || manufacturingDate >= new DateTime(1990, 1, 1))
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingDate));
            }

            if (string.IsNullOrWhiteSpace(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            if (factoryLocationCode.Length != 2 || !Regex.IsMatch(factoryLocationCode, @"^[a-zA-Z]+$"))
            {
                throw new ArgumentException("incorrect argument");
            }

            StringBuilder code = new StringBuilder();
            code.Append(manufacturingDate.ToString("yy", CultureInfo.CurrentCulture));
            code.Append(manufacturingDate.Month);
            code.Append(factoryLocationCode.ToUpper(CultureInfo.CurrentCulture));
            string result = code.ToString();

            return result;
        }

        public static string Generate1990Code(string factoryLocationCode, uint manufacturingYear, uint manufacturingMonth)
        {
            if (manufacturingMonth <= 0 || manufacturingMonth > 12)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingMonth));
            }

            if (manufacturingYear < 1990 || manufacturingYear > 2006)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingYear));
            }

            if (string.IsNullOrWhiteSpace(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            if (factoryLocationCode.Length != 2 || !Regex.IsMatch(factoryLocationCode, @"^[a-zA-Z]+$"))
            {
                throw new ArgumentException("incorrect argument");
            }

            StringBuilder code = new StringBuilder();
            code.Append(factoryLocationCode.ToUpper(CultureInfo.CurrentCulture));
            var month = manufacturingMonth.ToString(CultureInfo.CurrentCulture);
            var year = manufacturingYear.ToString(CultureInfo.CurrentCulture);

            if (month.Length < 2)
            {
                code.Append("0");
            }
            else
            {
                code.Append(month[^2]);
            }

            code.Append(year[^2]);
            code.Append(month[^1]);
            code.Append(year[^1]);

            string result = code.ToString();

            return result;
        }

        public static string Generate1990Code(string factoryLocationCode, DateTime manufacturingDate)
        {
            if (manufacturingDate < new DateTime(1990, 1, 1) || manufacturingDate > new DateTime(2006, 12, 1))
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingDate));
            }

            if (string.IsNullOrWhiteSpace(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            if (factoryLocationCode.Length != 2 || !Regex.IsMatch(factoryLocationCode, @"^[a-zA-Z]+$"))
            {
                throw new ArgumentException("incorrect argument");
            }

            StringBuilder code = new StringBuilder();
            code.Append(factoryLocationCode.ToUpper(CultureInfo.CurrentCulture));
            var month = manufacturingDate.Month.ToString(CultureInfo.CurrentCulture);
            var year = manufacturingDate.Year.ToString(CultureInfo.CurrentCulture);

            if (month.Length < 2)
            {
                code.Append("0");
            }
            else
            {
                code.Append(month[^2]);
            }

            code.Append(year[^2]);
            code.Append(month[^1]);
            code.Append(year[^1]);

            string result = code.ToString();

            return result;
        }

        public static string Generate2007Code(string factoryLocationCode, uint manufacturingYear, uint manufacturingWeek)
        {
            if (manufacturingWeek <= 0 || manufacturingWeek >= 53)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingWeek));
            }

            if (manufacturingYear < 2007 || manufacturingYear > DateTime.Now.Year)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingYear));
            }

            if (string.IsNullOrEmpty(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            if (factoryLocationCode.Length != 2 || !Regex.IsMatch(factoryLocationCode, @"^[a-zA-Z]+$"))
            {
                throw new ArgumentException("incorrect argument");
            }

            StringBuilder code = new StringBuilder();
            code.Append(factoryLocationCode.ToUpper(CultureInfo.CurrentCulture));
            var week = manufacturingWeek.ToString(CultureInfo.CurrentCulture);
            var year = manufacturingYear.ToString(CultureInfo.CurrentCulture);

            if (week.Length < 2)
            {
                code.Append("0");
            }
            else
            {
                code.Append(week[^2]);
            }

            code.Append(year[^2]);
            code.Append(week[^1]);
            code.Append(year[^1]);

            string result = code.ToString();

            return result;
        }

        public static string Generate2007Code(string factoryLocationCode, DateTime manufacturingDate)
        {
            if (manufacturingDate < new DateTime(2006, 12, 1))
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingDate));
            }

            if (string.IsNullOrWhiteSpace(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            if (factoryLocationCode.Length != 2 || !Regex.IsMatch(factoryLocationCode, @"^[a-zA-Z]+$"))
            {
                throw new ArgumentException("incorrect argument");
            }

            StringBuilder code = new StringBuilder();
            code.Append(factoryLocationCode.ToUpper(CultureInfo.CurrentCulture));
            var year = manufacturingDate.Year.ToString(CultureInfo.CurrentCulture);

            var week = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(manufacturingDate, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday).ToString(CultureInfo.CurrentCulture);

            if (week.Length < 2)
            {
                code.Append("0");
            }
            else
            {
                code.Append(week[^2]);
            }

            code.Append(year[^2]);
            code.Append(week[^1]);
            code.Append(year[^1]);

            string result = code.ToString();

            return result;
        }
    }
}
