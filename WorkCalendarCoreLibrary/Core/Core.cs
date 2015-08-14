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


// ReSharper disable once CheckNamespace
namespace AGSoft
{


    namespace WorkCalendarCoreLibrary.Core
    {

        #region Перечисления

        /// <summary>
        /// Перечисление состояния рабочих дней
        /// </summary>
        public enum WorkDayAttribute
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
        public enum CalendarDayDescription
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
            /// <summary>
            /// Уникальный индентификатор календарного дня
            /// </summary>
            int CalendarDayHandle { get; }

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
            private readonly int _calendarDayHandle;

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

            public int CalendarDayHandle
            {
                get { return _calendarDayHandle; }
            }

            #endregion

            #region Конструкторы

            /// <summary>
            /// Базовый конструктор
            /// </summary>
            /// <param name="calendarCalendarDayDate">Дата календарного дня</param>
            /// <param name="calendarWorkCalendarDayAttribute">Аттрибуты календарного дня</param>
            /// <param name="calendarCalendarDayDescription">Расшифровка параметров календарного дня</param>
            /// <param name="calendarDayComment">Комментарий</param>
            public CalendarDay(DateTime calendarCalendarDayDate, WorkDayAttribute calendarWorkCalendarDayAttribute,
                CalendarDayDescription calendarCalendarDayDescription, string calendarDayComment) : this()
            {
                // Вычисляем индентификатор календарного дня
                _calendarDayHandle = Core.CalendarDayHandle.SetCalendarDayHandle(calendarCalendarDayDate);
                // Присваеваем полям значения 
                _calendarDayDate = calendarCalendarDayDate;
                _calendarDayAttribute = calendarWorkCalendarDayAttribute;
                _calendarDayDescription = calendarCalendarDayDescription;
                // Если комментарий не указан полю присваиватся пустая строка
                _calendarDayComment = string.IsNullOrEmpty(calendarDayComment) ? string.Empty : calendarDayComment;

            }


            /// <summary>
            /// Конструктор по дате календарного дня
            /// </summary>
            /// <param name="calendarCalendarDayDate">Дате</param>
            public CalendarDay(DateTime calendarCalendarDayDate) : this()
            {
                // Вычисляем индентификатор календарного дня
                _calendarDayHandle = Core.CalendarDayHandle.SetCalendarDayHandle(calendarCalendarDayDate);
                // Присваеваем дату календарного дня
                _calendarDayDate = calendarCalendarDayDate;
                // Вычисляем аттрибуты календарного дня в календаре по умолчанию
                // Если этот день суббота или воскресенье, считаем его не рабочим днем
                _calendarDayAttribute = calendarCalendarDayDate.DayOfWeek == DayOfWeek.Saturday &&
                                        calendarCalendarDayDate.DayOfWeek == DayOfWeek.Sunday
                    ? WorkDayAttribute.UnWorkDay
                    // В противном случае день - рабочий
                    : WorkDayAttribute.WorkDay;
                //
                // Вычисляем аннотации к календарному дню
                // В процессе разработки
                _calendarDayDescription = CalendarDayDescription.OrdinaryDay;
                // Комметарии в этом случае "пустые"
                _calendarDayComment = string.Empty;
            }

            #endregion

            #region Методы

            /// <summary>
            /// Изменяет аттрибут ралендарного лня календаря
            /// </summary>
            /// <param name="calendarWorkDayAttribute">Аттрибут календарного дня</param>
            public void ChangeCalendarDayAttribute(WorkDayAttribute calendarWorkDayAttribute)
            {
                _calendarDayAttribute = calendarWorkDayAttribute;
            }


            /// <summary>
            /// Изменяет описание календарного дня
            /// </summary>
            /// <param name="calendarDayDescription"></param>
            public void ChaingeCaledarDayDescription(CalendarDayDescription calendarDayDescription)
            {
                _calendarDayDescription = calendarDayDescription;
            }

            #endregion

        }

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
}