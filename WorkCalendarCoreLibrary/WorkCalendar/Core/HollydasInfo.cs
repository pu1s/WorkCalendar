using System;
using AGSoft.WorkCalendar.Core;

namespace AGSoft
{
    public static class HollydasInfo
    {
        public static CalendarDayDescription GetCalendarDayDescription(DateTime date)
        {
            return CalendarDayDescription.HollyDay;
        }
    }
}