//**********************************************************
// ������� ������, ������������ � ���������� ��� ������ 
// � ���������������� ���������� 
// MS Framework .Net 4.5
// �# version 6.0
// ����� ��������� 19.08.2015
// Alex Gorin Software 2015
//*********************************************************

using System;

namespace AGSoft.WorkCalendar.CoreLibrary
{
    /// <summary>
    ///     ���������� ������������ ������������ ���
    /// </summary>
    public static class CalendarDayHandle
    {
        /// <summary>
        ///     ����������� ���������� �������������� ������������ ���
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