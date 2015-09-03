/*
==========================================================
���� ���� �������� ������ ��������� WorkCalendar
����������� ��������� ��� ������������� �� ������������ � 
� ������������� �����
==========================================================
����� ����: ����� ��������� pu1s@outlook.com
Copyright � Alex Gorin Software 2015 All rights reserved
==========================================================
��������� ��������������� � ������������ �
GNU GENERAL PUBLIC LICENSE
������ 2, ���� 1991�.
Copyright (C) 1989, 1991 Free Software Foundation, Inc.
59 Temple Place - Suite 330, Boston, MA 02111-1307, USA
==========================================================
*/
#define TEST

using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Drawing.Text;
using AGSoft.WorkCalendar.CoreLibrary;

namespace AGSoft.WorkCalendarControl.Interfaces
{
    /// <summary>
    /// ����� ��� ��������� ��������
    /// </summary>
    public sealed class Painter : WorkCalendarDayPainter
    {
        /// <summary>
        /// ������������ ����
        /// </summary>
        /// <param name="control">�������</param>
        /// <param name="gfx">����������� �������</param>
        [SuppressMessage("ReSharper", "RedundantAssignment")]
        public override void DrawDate(WorkCalendarDayControl control, Graphics gfx)
        {
            //GraphicStateManager.Save(gfx);
            // ���������� ����� ���� ����� ��������
            var day = control.CalendarDay.CalendarDayDescription;
            var dayAttribute = control.CalendarDay.CalendarDayAttribute;
            // ������� �����
            SolidBrush brush;
            // ���������� �����
            Font font;
            // ������������� ���� ����� ����� ������
            if (day == CalendarDayDescription.HollyDay)
            {
                // ��� ������������ ���
                brush = new SolidBrush(control.HollydaysAndWeekendsDayFontColor);
                font = new Font(control.Font.FontFamily, control.Font.Size, FontStyle.Bold);
            }
            if (day == CalendarDayDescription.WeekendDay)
            {
                // ��� ��������� ���
                brush = new SolidBrush(control.HollydaysAndWeekendsDayFontColor);
                font = new Font(control.Font.FontFamily, control.Font.Size, FontStyle.Regular);
            }
            else
            {
                // ��� �������� ���
                brush = new SolidBrush(control.OrdinaryDayFontColor);
                font = new Font(control.Font.FontFamily, control.Font.Size, FontStyle.Regular);
            }
            if (dayAttribute == WorkDayAttribute.ShortDay)
            {
                // ��� ��������� ���
                brush = new SolidBrush(control.ShortWorkDayColor);
                font = new Font(control.Font.FontFamily, control.Font.Size, FontStyle.Regular);
            }
            // ��������� ������ �������
            var sizefData = gfx.MeasureString(control.CalendarDay.CalendarDayDate.Date.Day.ToString(), font);
            // ��������� �������������� ������
          
            var hOffset = ((control.Width-1) - sizefData.Width) / 2.0f; // �� ������� ������, �� � ��������� �����
            // ��������� ������������ ������
            var vOffset = ((control.Height-1) - sizefData.Height) / 2.0f;
            // ������������� �������� ���������� ������
            gfx.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            // ������������ ����
            gfx.DrawString(control.CalendarDay.CalendarDayDate.Date.Day.ToString(), font,
                brush, new PointF(hOffset, vOffset));
            // ���������� �������� ���������� � �������� ���������
            gfx.TextRenderingHint = TextRenderingHint.SystemDefault;
            brush.Dispose();
            font.Dispose();

            //GraphicStateManager.Restore(gfx);
        }

        public override void DrawMarker(WorkCalendarDayControl control, Graphics gfx)
        {
            if (string.IsNullOrEmpty(control.CalendarDay.CalendarDayComment))
                return;
            var markerColor = control.GreenMarkerColor;
            using (var brush = new SolidBrush(markerColor))
            {
                //GraphicStateManager.Save(gfx);
                //gfx.SmoothingMode = SmoothingMode.HighQuality;
                gfx.FillRectangle(brush, new Rectangle(new Point(control.ClientRectangle.X + 1, control.ClientRectangle.Y + 16), new Size(18, 2)));
                //gfx.SmoothingMode= SmoothingMode.Default;
                //GraphicStateManager.Restore(gfx);
            }

        }
    }
}