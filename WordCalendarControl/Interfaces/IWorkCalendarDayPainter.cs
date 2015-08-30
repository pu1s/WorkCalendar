using System.Drawing;
using System.Timers;

namespace AGSoft.WorkCalendarControl.Interfaces
{
    public abstract class WorkCalendarDayPainter
    {
        public abstract void DrawMarker(WorkCalendarDayControl control, Graphics gfx);
        public abstract void DrawDate(WorkCalendarDayControl control, Graphics gfx);
    }

    public abstract class WorkCalendarDayBgPainter
    {
        public abstract void DrawBg(WorkCalendarDayControl control, Graphics gfx);
    }

    public class BgPainter : WorkCalendarDayBgPainter
    {
        public override void DrawBg(WorkCalendarDayControl control, Graphics gfx)
        {
            using (var brush = new SolidBrush(control.BackColor))
            {
                gfx.FillRectangle(brush, control.ClientRectangle);
            }
        }
    }



}
