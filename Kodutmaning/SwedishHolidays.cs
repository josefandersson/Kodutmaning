using System;
using System.Collections.Generic;

namespace Kodutmaning
{
    class SwedishHolidays
    {

        private static Dictionary<int, DateTime> easterSundayCache = new Dictionary<int, DateTime>();


        public static bool isSwedishHoliday(DateTime date)
        {
            return IsNyårsdagen(date)
                || IsTrettondedagJul(date)
                || IsLångfredagen(date)
                || IsPåskafton(date)
                || IsAnnandagPåsk(date)
                || IsFörstaMaj(date)
                || IsKristiHimmelsfärdsdag(date)
                || IsPingstdagen(date)
                || IsSverigesNationaldag(date)
                || IsMidsommardagen(date)
                || IsAllaHelgonsDag(date)
                || IsJuldagen(date)
                || IsAnnandagJul(date);
        }


        public static bool IsNyårsdagen(DateTime date)
        {
            return date.Month == 1
                && date.Day == 1;
        }

        
        public static bool IsTrettondedagJul(DateTime date)
        {
            return date.Month == 1
                && date.Day == 6;
        }


        public static bool IsLångfredagen(DateTime date)
        {
            DateTime långfredagen = EasterSunday(date.Year).AddDays(-2);
            return date.Month == långfredagen.Month
                && date.Day == långfredagen.Day;
        }


        public static bool IsPåskafton(DateTime date)
        {
            DateTime påskafton = EasterSunday(date.Year).AddDays(-1);
            return date.Month == påskafton.Month
                && date.Day == påskafton.Day;
        }


        public static bool IsPåskdagen(DateTime date)
        {
            DateTime påskdagen = EasterSunday(date.Year);
            return date.Month == påskdagen.Month
                && date.Day == påskdagen.Day;
        }


        public static bool IsAnnandagPåsk(DateTime date)
        {
            DateTime annandagPåsk = EasterSunday(date.Year).AddDays(1);
            return date.Month == annandagPåsk.Month
                && date.Day == annandagPåsk.Day;
        }


        public static bool IsFörstaMaj(DateTime date)
        {
            return date.Month == 5
                && date.Day == 1;
        }


        public static bool IsKristiHimmelsfärdsdag(DateTime date)
        {
            DateTime kristiHimmelsfärdsdag = EasterSunday(date.Year).AddDays(26);
            return date.Month == kristiHimmelsfärdsdag.Month
                && date.Day == kristiHimmelsfärdsdag.Day;
        }


        public static bool IsPingstafton(DateTime date)
        {
            DateTime pingstafton = EasterSunday(date.Year).AddDays(48);
            return date.Month == pingstafton.Month
                && date.Day == pingstafton.Day;
        }


        public static bool IsPingstdagen(DateTime date)
        {
            DateTime pingstdagen = EasterSunday(date.Year).AddDays(49);
            return date.Month == pingstdagen.Month
                && date.Day == pingstdagen.Day;
        }


        public static bool IsSverigesNationaldag(DateTime date)
        {
            return date.Month == 6
                && date.Day == 6;
        }


        public static bool IsMidsommardagen(DateTime date)
        {
            return date.Month == 6
                && date.DayOfWeek == DayOfWeek.Saturday
                && 20 <= date.Day
                && date.Day <= 26;
        }


        public static bool IsAllaHelgonsDag(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday
                && ((date.Month == 10 && date.Day == 31)
                    || (date.Month == 11 && date.Day <= 6));
        }


        public static bool IsJuldagen(DateTime date)
        {
            return date.Month == 12
                && date.Day == 25;
        }


        public static bool IsAnnandagJul(DateTime date)
        {
            return date.Month == 12
                && date.Day == 26;
        }


        // taken from https://social.msdn.microsoft.com/Forums/vstudio/en-US/36d8ad39-647f-40b0-b745-36d3b639a576/c-monthcalendar-and-easter?forum=csharpgeneral
        public static DateTime EasterSunday(int year)
        {
            if (!easterSundayCache.ContainsKey(year))
            {
                int day = 0;
                int month = 0;

                int g = year % 19;
                int c = year / 100;
                int h = (c - (int)(c / 4) - (int)((8 * c + 13) / 25) + 19 * g + 15) % 30;
                int i = h - (int)(h / 28) * (1 - (int)(h / 28) * (int)(29 / (h + 1)) * (int)((21 - g) / 11));

                day = i - ((year + (int)(year / 4) + i + 2 - c + (int)(c / 4)) % 7) + 28;
                month = 3;

                if (day > 31)
                {
                    month++;
                    day -= 31;
                }

                easterSundayCache.Add(year, new DateTime(year, month, day));
            }

            return easterSundayCache[year];
        }
    }
}
