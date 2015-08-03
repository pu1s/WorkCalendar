﻿//**********************************************************
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

        private DateTime _dayDate;
        private WorkDayAttribute _dayAttribute;
        private CalendarDayDescription _dayDescription;
        private string _calendarDayComment;

        #endregion

        #region Свойства

        public DateTime CalendarDayDate
        {
            get { return _dayDate; }
        }

        public WorkDayAttribute CalendarDayAttribute
        {
            get { return _dayAttribute; }
        }

        public CalendarDayDescription CalendarDayDescription
        {
            get { return _dayDescription; }
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
        /// <param name="calendarDayDate">Дата календарного дня</param>
        /// <param name="calendarWorkDayAttribute">Аттрибуты календарного дня</param>
        /// <param name="calendarDayDescription">Расшифровка параметров календарного дня</param>
        /// <param name="calendarDayComment">Комментарий</param>
        public CalendarDay(DateTime calendarDayDate, WorkDayAttribute calendarWorkDayAttribute,
            CalendarDayDescription calendarDayDescription, string calendarDayComment): this()
        {
            // Присваеваем полям значения 
            _dayDate = calendarDayDate;
            _dayAttribute = calendarWorkDayAttribute;
            _dayDescription = calendarDayDescription;
            // Если комментарий не указан полю присваиватся пустая строка
            _calendarDayComment = string.IsNullOrEmpty(calendarDayComment) ? string.Empty : calendarDayComment;
        }

        #endregion
    }
}
