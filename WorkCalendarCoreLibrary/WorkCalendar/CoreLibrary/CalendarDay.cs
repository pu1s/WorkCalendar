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
using System.Globalization;

namespace AGSoft.WorkCalendar.CoreLibrary
{
    /// <summary>
    ///     Базовая структура, описывающая календарный день
    /// </summary>
    [Serializable]
    public struct CalendarDay : ICalendarDay
    {
        #region Поля

        private readonly DateTime _calendarDayDate; // отметим только для чтения
        private string _calendarDayComment;
        private readonly int _calendarDayHandle;

        #endregion

        #region Свойства

        /// <summary>
        ///     Дата календарного дня
        /// </summary>
        public DateTime CalendarDayDate => _calendarDayDate;

        /// <summary>
        ///     Аттрибуты календарного дня (рабочий календарь)
        /// </summary>
        public WorkDayAttribute CalendarDayAttribute { get; private set; }

        /// <summary>
        ///     Расшифровка календарного дня
        /// </summary>
        public CalendarDayDescription CalendarDayDescription { get; private set; }

        /// <summary>
        ///     Комметарий к текущему календарному дню
        /// </summary>
        public string CalendarDayComment
        {
            get { return _calendarDayComment; }
            set { _calendarDayComment = value ?? string.Empty; }
            // если комметарий пустой, заполняем поле "пусой" строкой
        }

        /// <summary>
        ///     Индентификатор календарного дня
        /// </summary>
        public int CalendarDayHandle => _calendarDayHandle;

        #endregion

        #region Конструкторы


        /// <summary>
        ///     Базовый конструктор
        /// </summary>
        /// <param name="calendarDayDate">Дата календарного дня</param>
        /// <param name="calendarDayAttribute">Аттрибуты календарного дня</param>
        /// <param name="calendarDayDescription">Расшифровка параметров календарного дня</param>
        /// <param name="calendarDayComment">Комментарий</param>
        public CalendarDay(DateTime calendarDayDate, WorkDayAttribute calendarDayAttribute,
            CalendarDayDescription calendarDayDescription, string calendarDayComment) : this()
        {
            // Вычисляем индентификатор календарного дня
            _calendarDayHandle = CoreLibrary.CalendarDayHandle.SetCalendarDayHandle(calendarDayDate);
            // Присваеваем полям значения 
            _calendarDayDate = calendarDayDate;
            CalendarDayAttribute = calendarDayAttribute;
            CalendarDayDescription = calendarDayDescription;
            // Если комментарий не указан полю присваиватся пустая строка
            _calendarDayComment = string.IsNullOrEmpty(calendarDayComment) ? string.Empty : calendarDayComment;
        }


        /// <summary>
        ///     Конструктор по дате календарного дня
        /// </summary>
        /// <param name="calendarDayDate">Дате</param>
        public CalendarDay(DateTime calendarDayDate) : this()
        {
            // Вычисляем индентификатор календарного дня
            _calendarDayHandle = CoreLibrary.CalendarDayHandle.SetCalendarDayHandle(calendarDayDate);
            // Присваеваем дату календарного дня
            _calendarDayDate = calendarDayDate;
            // Вычисляем аттрибуты календарного дня в календаре по умолчанию
            // Если этот день суббота или воскресенье, считаем его не рабочим днем
            CalendarDayAttribute = calendarDayDate.DayOfWeek == DayOfWeek.Saturday &&
                                   calendarDayDate.DayOfWeek == DayOfWeek.Sunday
                ? WorkDayAttribute.UnWorkDay
                // В противном случае день - рабочий
                : WorkDayAttribute.WorkDay;
            //
            // Вычисляем аннотации к календарному дню

            CalendarDayDescription = CalendarDayDescription.OrdinaryDay;
            // Комметарии в этом случае "пустые"
            _calendarDayComment = string.Empty;
        }

        public CalendarDay(DateTime calendarDayDate, bool calculateHollydays) : this()
        {
            // вычисляем уникальный индентификатор календарного дня
            _calendarDayHandle = CoreLibrary.CalendarDayHandle.SetCalendarDayHandle(calendarDayDate);
            // вычисляем дату календарного дня
            _calendarDayDate = calendarDayDate;
            // Присваевем значение аттирибутов календарного дня 
            // Если этот день суббота или воскресенье, считаем его не рабочим днем
            CalendarDayAttribute = calendarDayDate.DayOfWeek == DayOfWeek.Saturday &&
                                   calendarDayDate.DayOfWeek == DayOfWeek.Sunday
                ? WorkDayAttribute.UnWorkDay
                // В противном случае день - рабочий
                : WorkDayAttribute.WorkDay;
            if (calculateHollydays)
            {
                HollydaysInfo.GetCalendarDayDescriptionAndAttribute(calendarDayDate, ref this);
            }
        }

        #endregion

        #region Перегруженные методы

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer that is the hash code for this instance.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override int GetHashCode()
        {
            return _calendarDayHandle != 0 ? _calendarDayHandle : 0;
        }

        /// <summary>
        /// Returns the fully qualified type name of this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> containing a fully qualified type name.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return string.IsNullOrEmpty(_calendarDayDate.ToString(CultureInfo.CurrentCulture)) ? _calendarDayDate.ToLongDateString() : "Undefined Date";
        }

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <returns>
        /// true if <paramref name="obj"/> and this instance are the same type and represent the same value; otherwise, false. 
        /// </returns>
        /// <param name="obj">The object to compare with the current instance. </param><filterpriority>2</filterpriority>
        public override bool Equals(object obj)
        {
            return obj != null || GetType() == typeof(CalendarDay);
        }

        #endregion

        #region Перегрузка операторов
        /// <summary>
        /// Переопределенный оператор равенства
        /// </summary>
        /// <param name="a">Объект а</param>
        /// <param name="b"> Объект b</param>
        /// <returns>Возвращает истина, если совпадают хеши объектов, и ложь - если нет </returns>
        public static bool operator ==(CalendarDay a, CalendarDay b)
        {
            return a.GetHashCode() == b.GetHashCode();
        }
        /// <summary>
        /// Переопределенный оператор неравенства
        /// </summary>
        /// <param name="a">Объект а</param>
        /// <param name="b">Объект b</param>
        /// <returns>Возвращает истина, если совпадают хеши объектов, и ложь - если нет</returns>
        public static bool operator !=(CalendarDay a, CalendarDay b)
        {
            return !(a == b);
        }

        #endregion


        #region Методы

        /// <summary>
        ///     Изменяет аттрибут календарного лня календаря
        /// </summary>
        /// <param name="calendarWorkDayAttribute">Аттрибут календарного дня</param>
        public void ChangeCalendarDayAttribute(WorkDayAttribute calendarWorkDayAttribute)
        {
            CalendarDayAttribute = calendarWorkDayAttribute;
        }


        /// <summary>
        ///     Изменяет описание календарного дня
        /// </summary>
        /// <param name="calendarDayDescription">Описание календарного дня</param>
        public void ChangeCaledarDayDescription(CalendarDayDescription calendarDayDescription)
        {
            CalendarDayDescription = calendarDayDescription;
        }

        #endregion

    }
    /// <summary>
    /// Статический класс, изменяющий аттрибуты календарного дня
    /// </summary>
    public static class ChangeCalendarDay
    {
        public delegate void CallBack();


        /// <summary>
        /// Изменяет аттрибуты календарного дня
        /// </summary>
        /// <param name="calendarDayDescription">Расшифровка календарного дня</param>
        /// <param name="calendarWorkDayAttribute">Аттрибуты календарного дня</param>
        /// <param name="calendarDayComment">Комментарий</param>
        /// <param name="calendarDay">структура, календарный день, переданная по ссылке</param>
        /// <param name="callBackMetod">Метод, запускаемый при изменнени аттрибутов календарного дня</param>
        public static void Change(CalendarDayDescription calendarDayDescription,
            WorkDayAttribute calendarWorkDayAttribute,
            string calendarDayComment, ref CalendarDay calendarDay, CallBack callBackMetod)
        {
            calendarDay.ChangeCalendarDayAttribute(calendarWorkDayAttribute);
            calendarDay.ChangeCaledarDayDescription(calendarDayDescription);
            calendarDay.CalendarDayComment = calendarDayComment;
            // Если указан делегат, то выполняем его
            callBackMetod?.Invoke(); // Новые фишки
        }
    }
}
