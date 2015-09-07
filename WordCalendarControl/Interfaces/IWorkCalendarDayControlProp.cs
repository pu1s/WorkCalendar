using System.Drawing;

namespace AGSoft.WCControl.Interfaces
{
    public interface IWorkCalendarDayControlProp
    {
        Color BackColor { get; set; }

        /// <summary>
        ///     Свойство, показывающее выделен ли компонент
        /// </summary>
        bool IsSelected { get; set; }
        Color BgLeaveColor { get; set; }
        Color OrdinaryDayFontColor { get; set; }
        Color HollydaysAndWeekendsDayColor { get; set; }
    }
}