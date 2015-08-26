using System.Drawing;

namespace AGSoft.WorkCalendarControl.Interfaces
{
    public interface IWorkCalendarDayControlPainter
    {
        void DrawDate(Graphics gfx);
        void DrawMarker(Graphics gfx);
        void DrawBg(Graphics gfx);
    }
}