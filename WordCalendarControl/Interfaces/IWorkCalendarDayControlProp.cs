using System.Drawing;

namespace AGSoft.WorkCalendarControl.Interfaces
{
    public interface IWorkCalendarDayControlProp
    {
        Color BackColor { get; set; }

        /// <summary>
        ///     Свойство, показывающее выделен ли компонент
        /// </summary>
        bool IsControlSelected { get; set; }

        Color LeaveControlColor { get; set; }
        Color OrdinaryDayFontColor { get; set; }
        Color ShortWorkDayColor { get; set; }
        Color HollydaysAndWeekendsDayFontColor { get; set; }
    }
}