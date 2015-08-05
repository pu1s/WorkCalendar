//**********************************************************
// Базовые классы, перечисления и интерфейсы для работы 
// с производственным календарем 
// MS Framework .Net 4.5
// Горин Александр 19.07.2015
// Alex Gorin Software 2015
//*********************************************************

#define DEBUG
#define TRIAL
using System;

namespace WorkCalendarCoreLibrary.Core
{

    #region Перечисления

    /// <summary>
    /// Перечисление состояния рабочих дней
    /// </summary>
    // ReSharper disable once EnumUnderlyingTypeIsInt
    public enum WorkDayAttribute : int
    {
        /// <summary>
        /// Рабочий день
        /// </summary>
        WorkDay = 0,

        /// <summary>
        /// Короткий день
        /// </summary>
        ShortDay,

        /// <summary>
        /// Не рабочий день
        /// </summary>
        UnWorkDay
    };

    /// <summary>
    /// Перечисление состояния календарного дня
    /// </summary>
    // ReSharper disable once EnumUnderlyingTypeIsInt
    public enum CalendarDayDescription : int
    {
        /// <summary>
        /// Обычный день
        /// </summary>
        OrdinaryDay = 0,

        /// <summary>
        /// Выходной
        /// </summary>
        WeekendDay,

        /// <summary>
        /// Праздничный день
        /// </summary>
        HollyDay
    };

    #endregion
    
    #region Интерфейсы

    /// <summary>
    /// Интерфейс, определяющий календарный день
    /// </summary>
    public interface ICalendarDay
    {
        /// <summary>
        /// Дата, соответствующая календарному дню
        /// </summary>
        DateTime CalendarDayDate { get; }

        /// <summary>
        /// Свойство, определяющее аттрибуты дня в производственном календаре
        /// </summary>
        WorkDayAttribute CalendarDayAttribute { get; }

        /// <summary>
        /// Свойство, определяюшее состояние календарного дня
        /// </summary>
        CalendarDayDescription CalendarDayDescription { get; }

        /// <summary>
        /// Комментарий для календарного дня
        /// </summary>
        string CalendarDayComment { get; set; }
    }

    #endregion

    /// <summary>
    /// Базовая структура, описывающая календарный день
    /// </summary>
    public struct CalendarDay : ICalendarDay
    {
        #region Поля

        private DateTime _calendarDayDate;
        private WorkDayAttribute _calendarDayAttribute;
        private CalendarDayDescription _calendarDayDescription;
        private string _calendarDayComment;

       #endregion

  
    
        #region Свойства

        public DateTime CalendarDayDate
        {
            get { return _calendarDayDate; }
        }

        public WorkDayAttribute CalendarDayAttribute
        {
            get { return _calendarDayAttribute; }
        }

        public CalendarDayDescription CalendarDayDescription
        {
            get { return _calendarDayDescription; }
        }

        public string CalendarDayComment
        {
            get { return _calendarDayComment; }
            set { _calendarDayComment = value ?? string.Empty; }
        }

        #endregion

        #region Конструкторы
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="calendarCalendarDayDate">Дата календарного дня</param>
        /// <param name="calendarWorkCalendarDayAttribute">Аттрибуты календарного дня</param>
        /// <param name="calendarCalendarDayDescription">Расшифровка параметров календарного дня</param>
        /// <param name="calendarDayComment">Комментарий</param>
        public CalendarDay(DateTime calendarCalendarDayDate, WorkDayAttribute calendarWorkCalendarDayAttribute,
            CalendarDayDescription calendarCalendarDayDescription, string calendarDayComment): this()
        {
            // Присваеваем полям значения 
            _calendarDayDate = calendarCalendarDayDate;
            _calendarDayAttribute = calendarWorkCalendarDayAttribute;
            _calendarDayDescription = calendarCalendarDayDescription;
            // Если комментарий не указан полю присваиватся пустая строка
            _calendarDayComment = string.IsNullOrEmpty(calendarDayComment) ? string.Empty : calendarDayComment;
        }
        /// <summary>
        /// Конструктор с датой календарного дня
        /// </summary>
        /// <param name="calendarDayDate">Дата</param>
        public CalendarDay(DateTime calendarDayDate) : this()
        {
            // Присваеваем полям значения по умолчанию
            _calendarDayDate = calendarDayDate;
            // Расчитываем аттрибуты календарного дня
            _calendarDayAttribute = CalculateWorkDayAttribute(_calendarDayDate);
            // Расчитываем описание дня
            _calendarDayDescription = CalculateWorkDayDescription(_calendarDayDate);
        }

        #endregion


        #region Методы

        /// <summary>
        /// Расчет аттрибутов календарного дня по умолчанию
        /// </summary>
        /// <param name="calendarDayDate">Дата</param>
        /// <returns>Аттрибут календарного дня</returns>
        private WorkDayAttribute CalculateWorkDayAttribute(DateTime calendarDayDate)
        {
            // Если календарный день суббота или воскресенье
            return calendarDayDate.DayOfWeek == DayOfWeek.Sunday && calendarDayDate.DayOfWeek == DayOfWeek.Saturday
                // возвращаем нерабочий день
                ? WorkDayAttribute.UnWorkDay
                // иначе вернем рабочий день
                : WorkDayAttribute.WorkDay;
        }

        private CalendarDayDescription CalculateWorkDayDescription(DateTime calendarDayDate)
        {
            
        }
        #endregion

    }
}
