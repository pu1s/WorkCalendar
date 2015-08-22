//**********************************************************
// ������� ������, ������������ � ���������� ��� ������ 
// � ���������������� ���������� 
// MS Framework .Net 4.5
// �# version 6.0
// ����� ��������� 19.08.2015
// Alex Gorin Software 2015
//*********************************************************
namespace AGSoft.WorkCalendar.CoreLibrary


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