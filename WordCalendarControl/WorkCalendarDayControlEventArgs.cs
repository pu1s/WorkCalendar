using System;
using AGSoft.WorkCalendar.CoreLibrary;

namespace AGSoft.WorkCalendarControl
{
    /// <summary>
    /// Описание события изменений в рабочем календаре
    /// </summary>
    public class WorkCalendarDayControlEventArgs : EventArgs
    {
        /// <summary>
        /// Календарный день
        /// </summary>
        private CalendarDay CalendarDay { get; set; }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="calendarDay">Календарный день</param>
        public WorkCalendarDayControlEventArgs(CalendarDay calendarDay)
        {
            CalendarDay = calendarDay;
        }
    }
}