namespace AGSoft.WorkCalendar.Core


{
    /// <summary>
    ///     Перечисление состояния календарного дня
    /// </summary>
    public enum CalendarDayDescription
    {
        /// <summary>
        /// Значение не присвоено
        /// </summary>
        Empty = 0,
        /// <summary>
        ///     Обычный день
        /// </summary>
        OrdinaryDay,

        /// <summary>
        ///     Выходной
        /// </summary>
        WeekendDay,

        /// <summary>
        ///     Праздничный день
        /// </summary>
        HollyDay
    };
}