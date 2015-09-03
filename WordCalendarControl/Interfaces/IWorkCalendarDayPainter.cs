/*
==========================================================
Этот файл является частью программы WorkCalendar
отображения календаря для использования на производстве и 
в бухгалтерском учете
==========================================================
Автор кода: Горин Александр pu1s@outlook.com
Copyright © Alex Gorin Software 2015 All rights reserved
==========================================================
Программа распостраняется в соответствии с
GNU GENERAL PUBLIC LICENSE
Версия 2, июнь 1991г.
Copyright (C) 1989, 1991 Free Software Foundation, Inc.
59 Temple Place - Suite 330, Boston, MA 02111-1307, USA
==========================================================
*/
using System.Drawing;


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
