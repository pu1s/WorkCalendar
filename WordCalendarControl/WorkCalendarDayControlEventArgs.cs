using System;
using AGSoft.WC.CoreLibrary;


namespace AGSoft.WCControl
{
    /// <summary>
    ///     Описание события изменений в рабочем календаре
    /// </summary>
    public class WorkCalendarDayControlEventArgs : EventArgs
    {
        /// <summary>
        ///     Конструктор
        /// </summary>
        /// <param name="calendarDay">Календарный день</param>
        public WorkCalendarDayControlEventArgs(WCDay calendarDay)
        {
            CalendarDay = calendarDay;
        }

        /// <summary>
        ///     Календарный день
        /// </summary>
        private WCDay CalendarDay { get; set; }
    }
}