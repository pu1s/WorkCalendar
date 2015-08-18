using System;

namespace AGSoft.WorkCalendar.Core
{
    /// <summary>
    ///     ���������, ������������ ����������� ����
    /// </summary>
    public interface ICalendarDay
    {
        /// <summary>
        ///     ����, ��������������� ������������ ���
        /// </summary>
        DateTime CalendarDayDate { get; }

        /// <summary>
        ///     ��������, ������������ ��������� ��� � ���������������� ���������
        /// </summary>
        WorkDayAttribute CalendarDayAttribute { get; }

        /// <summary>
        ///     ��������, ������������ ��������� ������������ ���
        /// </summary>
        CalendarDayDescription CalendarDayDescription { get; }

        /// <summary>
        ///     ����������� ��� ������������ ���
        /// </summary>
        string CalendarDayComment { get; set; }

        /// <summary>
        ///     ���������� �������������� ������������ ���
        /// </summary>
        int CalendarDayHandle { get; }
    }
}