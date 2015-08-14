using System;

namespace AGSoft.Core
{
    /// <summary>
    /// Определяет уникальность календарного дня
    /// </summary>
    public static class CalendarDayHandle
    {
        /// <summary>
        /// Опеределяет уникальный индентификатор календарного дня
        /// </summary>
        /// <param name="date">День</param>
        /// <returns>число, уникальный индентификатор календарного дня</returns>
        public static int SetCalendarDayHandle(DateTime date)
        {
            // Вычисляем целое число, уникальный индентификатор календарного дня
            return ((date.Year*1000) + date.DayOfYear);
        }
    }
}