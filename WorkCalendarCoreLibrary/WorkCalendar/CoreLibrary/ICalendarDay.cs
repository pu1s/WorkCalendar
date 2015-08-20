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