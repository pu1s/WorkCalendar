//**********************************************************
// Базовые классы, перечисления и интерфейсы для работы 
// с производственным календарем 
// MS Framework .Net 4.5
// С# version 6.0
// Горин Александр 19.08.2015
// Alex Gorin Software 2015
//*********************************************************

namespace AGSoft.WorkCalendar.CoreLibrary
{
    /// <summary>
    ///     Перечисление состояния рабочих дней
    /// </summary>
    public enum WorkDayAttribute
    {
        /// <summary>
        ///     Значение не присвоено
        /// </summary>
        Empty = 0,

        /// <summary>
        ///     Рабочий день
        /// </summary>
        WorkDay,

        /// <summary>
        ///     Короткий день
        /// </summary>
        ShortDay,

        /// <summary>
        ///     Не рабочий день
        /// </summary>
        UnWorkDay
    };
}