namespace AGSoft.WorkCalendar.Core


{
    /// <summary>
    ///     ������������ ��������� ������������ ���
    /// </summary>
    public enum CalendarDayDescription
    {
        /// <summary>
        /// �������� �� ���������
        /// </summary>
        Empty = 0,
        /// <summary>
        ///     ������� ����
        /// </summary>
        OrdinaryDay,

        /// <summary>
        ///     ��������
        /// </summary>
        WeekendDay,

        /// <summary>
        ///     ����������� ����
        /// </summary>
        HollyDay
    };
}