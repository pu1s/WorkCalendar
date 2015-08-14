namespace AGSoft.WorkCalendar
{
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
}