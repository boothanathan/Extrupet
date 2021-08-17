using System;

namespace Extrupet.BAL.Utilities
{

    public static class Extensions
    {
        const decimal _timeZione = 2;
        public static DateTime GetLocalDateTimeFromUtc(this DateTime UtcDateTime, decimal userTimeZone = _timeZione)
        {
            return UtcDateTime.AddHours((double)userTimeZone);
        }

        public static DateTime GetUtcDateTimeFromLocal(this DateTime UserDateTime, decimal userTimeZone = _timeZione)
        {
            return UserDateTime.AddHours(-(double)userTimeZone);
        }

        public static DateTime GetUtcDateTimeFromLocalWithoutLocaleTimePassed(this DateTime UserDateTime, bool isLowerBound, decimal userTimeZone = _timeZione)
        {
            string format = isLowerBound ? "dd/MMM/yyyy 00:00:00" : "dd/MMM/yyyy 23:59:59";
            return DateTime.Parse(UserDateTime.ToString(format)).AddHours(-(double)userTimeZone);
        }
    }

}
