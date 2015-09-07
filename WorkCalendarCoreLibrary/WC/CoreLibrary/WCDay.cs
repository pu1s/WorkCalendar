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

namespace AGSoft.WC.CoreLibrary
{
    /// <summary>
    ///     Базовая структура, описывающая календарный день
    /// </summary>
    [Serializable]
    public struct WCDay
    {
        #region Поля

        private string _wdDayComment;

        #endregion

        #region Свойства

        /// <summary>
        ///     Дата календарного дня
        /// </summary>
        public DateTime WCDayDate { get; }

        /// <summary>
        ///     Аттрибуты календарного дня (рабочий календарь)
        /// </summary>
        public WCDayAttribute WCDayAttribute { get; private set; }

        /// <summary>
        ///     Расшифровка календарного дня
        /// </summary>
        public WCDayDescription WCDayDescription { get; private set; }

        /// <summary>
        ///     Комметарий к текущему календарному дню
        /// </summary>
        public string WDDayComment
        {
            get { return _wdDayComment; }
            set { _wdDayComment = value ?? string.Empty; }
            // если комметарий пустой, заполняем поле "пусой" строкой
        }

        /// <summary>
        ///     Индентификатор календарного дня
        /// </summary>
        public int WCDayHandle { get; }

        #endregion

        #region Конструкторы

        /// <summary>
        ///     Базовый конструктор
        /// </summary>
        /// <param name="wcDayDate">Дата календарного дня</param>
        /// <param name="wcDayAttribute">Аттрибуты календарного дня</param>
        /// <param name="wcDayDescription">Расшифровка параметров календарного дня</param>
        /// <param name="calendarDayComment">Комментарий</param>
        public WCDay(DateTime wcDayDate, WCDayAttribute wcDayAttribute,
            WCDayDescription wcDayDescription, string calendarDayComment) : this()
        {
            // Вычисляем индентификатор календарного дня
            WCDayHandle = CoreLibrary.WCDayHandle.SetCalendarDayHandle(wcDayDate);
            // Присваеваем полям значения 
            WCDayDate = wcDayDate;
            WCDayAttribute = wcDayAttribute;
            WCDayDescription = wcDayDescription;
            // Если комментарий не указан полю присваиватся пустая строка
            _wdDayComment = string.IsNullOrEmpty(calendarDayComment) ? string.Empty : calendarDayComment;
        }


        /// <summary>
        ///     Конструктор по дате календарного дня
        /// </summary>
        /// <param name="wcDayDate">Дате</param>
        public WCDay(DateTime wcDayDate) : this()
        {
            // Вычисляем индентификатор календарного дня
            WCDayHandle = CoreLibrary.WCDayHandle.SetCalendarDayHandle(wcDayDate);
            // Присваеваем дату календарного дня
            WCDayDate = wcDayDate;
            CalculateWCDayAttribute(wcDayDate);
        }

        private void CalculateWCDayAttribute(DateTime wcDayDate)
        {
            // Вычисляем аттрибуты календарного дня в календаре по умолчанию
            // Если этот день суббота или воскресенье, считаем его не рабочим днем
            WCDayAttribute = wcDayDate.DayOfWeek == DayOfWeek.Saturday &&
                             wcDayDate.DayOfWeek == DayOfWeek.Sunday
                ? WCDayAttribute.UnWorkDay
                // В противном случае день - рабочий
                : WCDayAttribute.WorkDay;
            //
            // Вычисляем аннотации к календарному дню

            WCDayDescription = WCDayDescription.OrdinaryDay;
            // Комметарии в этом случае "пустые"
            _wdDayComment = string.Empty;
        }

        public WCDay(DateTime wcDayDate, bool calculateHollydays) : this()
        {
            // вычисляем уникальный индентификатор календарного дня
            WCDayHandle = CoreLibrary.WCDayHandle.SetCalendarDayHandle(wcDayDate);
            // вычисляем дату календарного дня
            WCDayDate = wcDayDate;
            // Присваевем значение аттирибутов календарного дня 
            // Если этот день суббота или воскресенье, считаем его не рабочим днем
            WCDayAttribute = wcDayDate.DayOfWeek == DayOfWeek.Saturday &&
                             wcDayDate.DayOfWeek == DayOfWeek.Sunday
                ? WCDayAttribute.UnWorkDay
                // В противном случае день - рабочий
                : WCDayAttribute.WorkDay;
            if (calculateHollydays)
            {
                WCHollydaysInfo.GetWCDayDescriptionAndAttribute(wcDayDate, ref this);
            }
        }

        #endregion

        #region Перегруженные методы

        /// <summary>
        ///     Returns the hash code for this instance.
        /// </summary>
        /// <returns>
        ///     A 32-bit signed integer that is the hash code for this instance.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override int GetHashCode()
        {
            if (WCDayHandle != null) return WCDayHandle;
            return 0;
        }

        /// <summary>
        ///     Returns the fully qualified type name of this instance.
        /// </summary>
        /// <returns>
        ///     A <see cref="T:System.String" /> containing a fully qualified type name.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return string.IsNullOrEmpty(WCDayDate.ToString(CultureInfo.CurrentCulture))
                ? WCDayDate.ToLongDateString()
                : "Undefined Date";
        }

        /// <summary>
        ///     Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <returns>
        ///     true if <paramref name="obj" /> and this instance are the same type and represent the same value; otherwise, false.
        /// </returns>
        /// <param name="obj">The object to compare with the current instance. </param>
        /// <filterpriority>2</filterpriority>
        public override bool Equals(object obj)
        {
            return obj != null || GetType() == typeof (WCDay);
        }

        #endregion

        #region Перегрузка операторов

        /// <summary>
        ///     Переопределенный оператор равенства
        /// </summary>
        /// <param name="a">Объект а</param>
        /// <param name="b"> Объект b</param>
        /// <returns>Возвращает истина, если совпадают хеши объектов, и ложь - если нет </returns>
        public static bool operator ==(WCDay a, WCDay b)
        {
            return a.GetHashCode() == b.GetHashCode();
        }

        /// <summary>
        ///     Переопределенный оператор неравенства
        /// </summary>
        /// <param name="a">Объект а</param>
        /// <param name="b">Объект b</param>
        /// <returns>Возвращает истина, если совпадают хеши объектов, и ложь - если нет</returns>
        public static bool operator !=(WCDay a, WCDay b)
        {
            return !(a == b);
        }

        #endregion

        #region Методы

        /// <summary>
        ///     Изменяет аттрибут календарного лня календаря
        /// </summary>
        /// <param name="calendarWorkDayAttribute">Аттрибут календарного дня</param>
        public void ChangeCalendarDayAttribute(WCDayAttribute calendarWorkDayAttribute)
        {
            WCDayAttribute = calendarWorkDayAttribute;
        }


        /// <summary>
        ///     Изменяет описание календарного дня
        /// </summary>
        /// <param name="calendarDayDescription">Описание календарного дня</param>
        public void ChangeCaledarDayDescription(WCDayDescription calendarDayDescription)
        {
            WCDayDescription = calendarDayDescription;
        }

        #endregion
    }

    /// <summary>
    ///     Статический класс, изменяющий аттрибуты календарного дня
    /// </summary>
    public static class ChangeCalendarDay
    {
        public delegate void CallBack();

        /// <summary>
        ///     Изменяет аттрибуты календарного дня
        /// </summary>
        /// <param name="calendarDayDescription">Расшифровка календарного дня</param>
        /// <param name="calendarWorkDayAttribute">Аттрибуты календарного дня</param>
        /// <param name="calendarDayComment">Комментарий</param>
        /// <param name="calendarDay">структура, календарный день, переданная по ссылке</param>
        /// <param name="callBackMetod">Метод, запускаемый при изменнени аттрибутов календарного дня</param>
        public static void Change(WCDayDescription calendarDayDescription,
            WCDayAttribute calendarWorkDayAttribute,
            string calendarDayComment, ref WCDay calendarDay, CallBack callBackMetod)
        {
            calendarDay.ChangeCalendarDayAttribute(calendarWorkDayAttribute);
            calendarDay.ChangeCaledarDayDescription(calendarDayDescription);
            calendarDay.WDDayComment = calendarDayComment;
            // Если указан делегат, то выполняем его
            if (callBackMetod != null) callBackMetod.Invoke();
        }
    }
}