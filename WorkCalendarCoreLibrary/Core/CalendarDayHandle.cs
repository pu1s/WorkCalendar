using System;

namespace AGSoft.Core
{
    /// <summary>
    /// ���������� ������������ ������������ ���
    /// </summary>
    public static class CalendarDayHandle
    {
        /// <summary>
        /// ����������� ���������� �������������� ������������ ���
        /// </summary>
        /// <param name="date">����</param>
        /// <returns>�����, ���������� �������������� ������������ ���</returns>
        public static int SetCalendarDayHandle(DateTime date)
        {
            // ��������� ����� �����, ���������� �������������� ������������ ���
            return ((date.Year*1000) + date.DayOfYear);
        }
    }
}