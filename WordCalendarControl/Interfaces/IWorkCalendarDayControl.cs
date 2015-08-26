using System.Drawing;
using AGSoft.WorkCalendar.CoreLibrary;

namespace AGSoft.WorkCalendarControl.Interfaces
{
    public interface IWorkCalendarDayControl
    {
        /// <summary>
        ///     Календарный день
        /// </summary>
        CalendarDay CalendarDay { get; set; }

        Color BackColor { get; set; }
        Font Font { get; set; }

        /// <summary>
        ///     Свойство, показывающее выделен ли компонент
        /// </summary>
        bool IsSelected { get; set; }

        Color BgLeaveColor { get; set; }
        Color OrdinaryDayFontColor { get; set; }
        Color HollydaysAndWeekendsDayColor { get; set; }

        void DrawDate(Graphics gfx);
        void DrawMarker(Graphics gfx);
        void DrawBg(Graphics gfx);
    }
}