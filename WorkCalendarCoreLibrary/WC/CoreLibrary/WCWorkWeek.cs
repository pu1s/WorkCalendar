//**********************************************************
// Базовые классы, перечисления и интерфейсы для работы 
// с производственным календарем 
// MS Framework .Net 4.5
// С# version 6.0
// Горин Александр 19.08.2015
// Alex Gorin Software 2015
//*********************************************************

// ReSharper disable InconsistentNaming
namespace AGSoft.WC.CoreLibrary
{
    /// <summary>
    ///     Рабочая неделя
    /// </summary>
    public enum WC_WorkWeek
    {
        /// <summary>
        ///     Пятидневная
        /// </summary>
        FiveDaysWorkWeek = 0,

        /// <summary>
        ///     Шестидневная
        /// </summary>
        SixDaysWorkWeek,

        /// <summary>
        ///     Неопределенная
        /// </summary>
        UndefinedWorkWeek
    };
}