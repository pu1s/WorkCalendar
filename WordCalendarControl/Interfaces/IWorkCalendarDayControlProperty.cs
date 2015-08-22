using System;

namespace AGSoft.WorkCalendarControl.Interfaces
{
    public interface IWorkCalendarDayControlProperty
    {
        bool IsDescripted { get; set; }
        bool IsCommented { get; set; }
        bool IsAttributed { get; set; }

        event EventHandler ChangeWorkCalendarDayProperty;
    }
}

