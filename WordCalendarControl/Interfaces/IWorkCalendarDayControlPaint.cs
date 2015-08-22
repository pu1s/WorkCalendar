using System.Drawing;

namespace AGSoft.WorkCalendarControl.Interfaces
{
    public interface IWorkCalendarDayControlPaint
    {
        void DrawDate(Graphics gfx);
        void DrawMarker(Graphics gfx);
        void DrawBg(Graphics gfx);
    }
}