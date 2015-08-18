namespace AGSoft.WorkCalendar.Core
{
    /// <summary>
    ///     Перечисление состояния рабочих дней
    /// </summary>
    public enum WorkDayAttribute
    {
        /// <summary>
        /// Значение не присвоено
        /// </summary>
        Empty = 0,
        /// <summary>
        ///     Рабочий день
        /// </summary>
        WorkDay,

        /// <summary>
        ///     Короткий день
        /// </summary>
        ShortDay,

        /// <summary>
        ///     Не рабочий день
        /// </summary>
        UnWorkDay
    };
}