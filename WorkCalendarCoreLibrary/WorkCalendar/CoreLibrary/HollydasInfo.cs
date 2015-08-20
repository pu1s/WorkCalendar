using System;

namespace AGSoft.WorkCalendar.CoreLibrary
{
    public static class HollydasInfo
    {
        public static CalendarDayDescription GetCalendarDayDescription(DateTime date)
        {
            return CalendarDayDescription.HollyDay;
        }
    }
}