namespace AGSoft.WorkCalendar.Core
{
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
}