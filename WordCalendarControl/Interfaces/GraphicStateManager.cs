using System.Drawing;
using System.Drawing.Drawing2D;

namespace AGSoft.WorkCalendarControl.Interfaces
{
    public static class GraphicStateManager
    {
        private static GraphicsState _gfxState;


        public static void Save(Graphics gfx)
        {
            _gfxState = gfx.Save();
        }

        public static void Restore(Graphics gfx)
        {
            gfx.Restore(_gfxState);
        }
    }
}