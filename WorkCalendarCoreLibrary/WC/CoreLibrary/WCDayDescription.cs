//**********************************************************
// Базовые классы, перечисления и интерфейсы для работы 
// с производственным календарем 
// MS Framework .Net 4.5
// С# version 6.0
// Горин Александр 19.08.2015
// Alex Gorin Software 2015
//*********************************************************

namespace AGSoft.WC.CoreLibrary


{
    /// <summary>
    ///     Перечисление состояния календарного дня
    /// </summary>
    public enum WCDayDescription
    {
        /// <summary>
        ///     Значение не присвоено
        /// </summary>
        Empty = 0,

        /// <summary>
        ///     Обычный день
        /// </summary>
        OrdinaryDay,

        /// <summary>
        ///     Выходной
        /// </summary>
        WeekendDay,

        /// <summary>
        ///     Праздничный день
        /// </summary>
        HollyDay
    };
}