//**********************************************************
// Базовые классы, перечисления и интерфейсы для работы 
// с производственным календарем 
// MS Framework .Net 4.5
// С# version 6.0
// Горин Александр 19.08.2015
// Alex Gorin Software 2015
//*********************************************************

using System;

namespace AGSoft.WC.CoreLibrary
{
    /// <summary>
    ///     Интерфейс, определяющий календарный день
    /// </summary>
    public interface IWCDay
    {
        /// <summary>
        ///     Дата, соответствующая календарному дню
        /// </summary>
        DateTime WCDayDate { get; }

        /// <summary>
        ///     Свойство, определяющее аттрибуты дня в производственном календаре
        /// </summary>
        WCDayAttribute WCDayAttribute { get; }

        /// <summary>
        ///     Свойство, определяюшее состояние календарного дня
        /// </summary>
        WCDayDescription WCDayDescription { get; }

        /// <summary>
        ///     Комментарий для календарного дня
        /// </summary>
        string WCDayComment { get; set; }

        /// <summary>
        ///     Уникальный индентификатор календарного дня
        /// </summary>
        int WCDayHandle { get; }
    }
}