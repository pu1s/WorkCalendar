//**********************************************************
// Базовые классы, перечисления и интерфейсы для работы 
// с производственным календарем 
// MS Framework .Net 4.5
// С# version 6.0
// Горин Александр 19.08.2015
// Alex Gorin Software 2015
//*********************************************************

using System;

namespace AGSoft.WorkCalendar.CoreLibrary
{
    /// <summary>
    ///     Определяет уникальность календарного дня
    /// </summary>
    public static class CalendarDayHandle
    {
        /// <summary>
        ///     Опеределяет уникальный индентификатор календарного дня
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