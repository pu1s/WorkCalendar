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
using System.Collections.Generic;
using AGSoft.WorkCalendar.Core;
using AGSoft.WorkCalendarCoreLibrary.Core;

// ReSharper disable once CheckNamespace
namespace AGSoft
{


    namespace WorkCalendarCoreLibrary.Core
    {
        /// <summary>
        /// Базовая структура, описывающая календарный день
        /// </summary>
        public struct CalendarDay : ICalendarDay
        {
            #region Поля

            private readonly DateTime _calendarDayDate; // отметим только для чтения
            private WorkDayAttribute _calendarDayAttribute;
            private CalendarDayDescription _calendarDayDescription;
            private string _calendarDayComment;
            private readonly int _calendarDayHandle;

            #endregion

            #region Свойства
            /// <summary>
            /// Дата календарного дня
            /// </summary>
            public DateTime CalendarDayDate
            {
                // возвращаем дату
                get { return _calendarDayDate; }
            }
            /// <summary>
            /// Аттрибуты календарного дня (рабочий календарь)
            /// </summary>
            public WorkDayAttribute CalendarDayAttribute
            {
                get { return _calendarDayAttribute; }
            }
            /// <summary>
            /// Расшифровка календарного дня
            /// </summary>
            public CalendarDayDescription CalendarDayDescription
            {
                get { return _calendarDayDescription; }
            }
            /// <summary>
            /// Комметарий к текущему календарному дню
            /// </summary>
            public string CalendarDayComment
            {
                get { return _calendarDayComment; }
                set { _calendarDayComment = value ?? string.Empty; } // если комметарий пустой, заполняем поле "пусой" строкой
            }
            /// <summary>
            /// Индентификатор календарного дня
            /// </summary>

            public int CalendarDayHandle
            {
                get { return _calendarDayHandle; }
            }

            #endregion

            #region Конструкторы

            /// <summary>
            /// Базовый конструктор
            /// </summary>
            /// <param name="calendarDayDate">Дата календарного дня</param>
            /// <param name="calendarDayAttribute">Аттрибуты календарного дня</param>
            /// <param name="calendarDayDescription">Расшифровка параметров календарного дня</param>
            /// <param name="calendarDayComment">Комментарий</param>
            public CalendarDay(DateTime calendarDayDate, WorkDayAttribute calendarDayAttribute,
                CalendarDayDescription calendarDayDescription, string calendarDayComment) : this()
            {
                // Вычисляем индентификатор календарного дня
                _calendarDayHandle = WorkCalendar.Core.CalendarDayHandle.SetCalendarDayHandle(calendarDayDate);
                // Присваеваем полям значения 
                _calendarDayDate = calendarDayDate;
                _calendarDayAttribute = calendarDayAttribute;
                _calendarDayDescription = calendarDayDescription;
                // Если комментарий не указан полю присваиватся пустая строка
                _calendarDayComment = string.IsNullOrEmpty(calendarDayComment) ? string.Empty : calendarDayComment;

            }


            /// <summary>
            /// Конструктор по дате календарного дня
            /// </summary>
            /// <param name="calendarDayDate">Дате</param>
            public CalendarDay(DateTime calendarDayDate) : this()
            {
                // Вычисляем индентификатор календарного дня
                _calendarDayHandle = WorkCalendar.Core.CalendarDayHandle.SetCalendarDayHandle(calendarDayDate);
                // Присваеваем дату календарного дня
                _calendarDayDate = calendarDayDate;
                // Вычисляем аттрибуты календарного дня в календаре по умолчанию
                // Если этот день суббота или воскресенье, считаем его не рабочим днем
                _calendarDayAttribute = calendarDayDate.DayOfWeek == DayOfWeek.Saturday &&
                                        calendarDayDate.DayOfWeek == DayOfWeek.Sunday
                    ? WorkDayAttribute.UnWorkDay
                    // В противном случае день - рабочий
                    : WorkDayAttribute.WorkDay;
                //
                // Вычисляем аннотации к календарному дню
                
                _calendarDayDescription = CalendarDayDescription.OrdinaryDay;
                // Комметарии в этом случае "пустые"
                _calendarDayComment = string.Empty;
            }

            public CalendarDay(DateTime calendarDayDate, bool calculateHollydays) : this()
            {
                // вычисляем уникальный индентификатор календарного дня
                _calendarDayHandle = WorkCalendar.Core.CalendarDayHandle.SetCalendarDayHandle(calendarDayDate);
                // вычисляем дату календарного дня
                _calendarDayDate = calendarDayDate;

                if (!calculateHollydays)
                {
                    // Присваевем значение аттирибутов календарного дня 
                    // Если этот день суббота или воскресенье, считаем его не рабочим днем
                    _calendarDayAttribute = calendarDayDate.DayOfWeek == DayOfWeek.Saturday &&
                                            calendarDayDate.DayOfWeek == DayOfWeek.Sunday
                        ? WorkDayAttribute.UnWorkDay
                        // В противном случае день - рабочий
                        : WorkDayAttribute.WorkDay;
                    // Вычисляем 
                }
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
            /// <param name="calendarDayDescription">Описание календарного дня</param>
            public void ChaingeCaledarDayDescription(CalendarDayDescription calendarDayDescription)
            {
                _calendarDayDescription = calendarDayDescription;
            }


            #endregion
        }
    }

}