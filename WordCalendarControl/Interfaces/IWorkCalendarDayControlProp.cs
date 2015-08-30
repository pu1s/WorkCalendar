using System.Drawing;

namespace AGSoft.WorkCalendarControl.Interfaces
{
    public interface IWorkCalendarDayControlProp
    {
        Color BackColor { get; set; }

        /// <summary>
        ///     ��������, ������������ ������� �� ���������
        /// </summary>
        bool IsControlSelected { get; set; }

        Color LeaveControlColor { get; set; }
        Color OrdinaryDayFontColor { get; set; }
        Color ShortWorkDayColor { get; set; }
        Color HollydaysAndWeekendsDayFontColor { get; set; }
    }
}