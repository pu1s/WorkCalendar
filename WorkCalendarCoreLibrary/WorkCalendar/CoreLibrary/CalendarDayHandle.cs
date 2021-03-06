/**********************************************************
 ������� ������, ������������ � ���������� ��� ������ 
 � ���������������� ���������� 
 MS Framework .Net 4.5
==========================================================
���� ���� �������� ������ ��������� WorkCalendar
����������� ��������� ��� ������������� �� ������������ � 
� ������������� �����
==========================================================
����� ���� ���������: ����� ��������� pu1s@outlook.com
Copyright � Alex Gorin Software 2015 All rights reserved
==========================================================
��������� �������� ����������������� �������������� 
������. ��������� � �������� ���� ��������� ������
��������������� � �������.
��������� ��������������� � ������������ �
GNU GENERAL PUBLIC LICENSE
������ 2, ���� 1991�.
Copyright (C) 1989, 1991 Free Software Foundation, Inc.
59 Temple Place - Suite 330, Boston, MA 02111-1307, USA
==========================================================
*/
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