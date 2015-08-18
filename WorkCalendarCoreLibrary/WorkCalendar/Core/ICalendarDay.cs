using System;

namespace AGSoft.WorkCalendar.Core
{
    /// <summary>
    ///     Интерфейс, определяющий календарный день
    /// </summary>
    public interface ICalendarDay
    {
        /// <summary>
        ///     Дата, соответствующая календарному дню
        /// </summary>
        DateTime CalendarDayDate { get; }

        /// <summary>
        ///     Свойство, определяющее аттрибуты дня в производственном календаре
        /// </summary>
        WorkDayAttribute CalendarDayAttribute { get; }

        /// <summary>
        ///     Свойство, определяюшее состояние календарного дня
        /// </summary>
        CalendarDayDescription CalendarDayDescription { get; }

        /// <summary>
        ///     Комментарий для календарного дня
        /// </summary>
        string CalendarDayComment { get; set; }

        /// <summary>
        ///     Уникальный индентификатор календарного дня
        /// </summary>
        int CalendarDayHandle { get; }
    }
}