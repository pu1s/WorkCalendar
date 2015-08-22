using System;
using System.Drawing;

namespace AGSoft.WorkCalendarControl.Interfaces
{
    public interface IWorkCalendarDayControlProperty
    {
        bool IsSelected { get; set; }
        //------------------------------------
        Color BgLeaveColor { get; set; }
        //------------------------------------
    }
}

