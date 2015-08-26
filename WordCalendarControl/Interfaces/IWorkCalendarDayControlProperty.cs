using System.Drawing;

namespace AGSoft.WorkCalendarControl.Interfaces
{
    public interface IWorkCalendarDayControlProperty
    {
        bool IsSelected { get; set; }
        //------------------------------------
        Color BgLeaveColor { get; set; }
        //------------------------------------
        Color OrdinaryFontColor { get; set; }
        Color HollydaysAndWeekendsDayColor { get; set; }
    }
}