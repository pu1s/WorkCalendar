using System;

namespace AGSoft.WorkCalendar.CoreLibrary
{
    public static class HollydaysInfo
    {
        public static CalendarDayDescription GetCalendarDayDescription(DateTime date)
        {
            return CalendarDayDescription.HollyDay;
        }
    }
}