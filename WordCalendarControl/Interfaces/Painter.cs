
#define TEST

using System.Diagnostics.CodeAnalysis;
using System.Drawing;

using System.Drawing.Text;
using AGSoft.WorkCalendar.CoreLibrary;

namespace AGSoft.WorkCalendarControl.Interfaces
{
    /// <summary>
    /// Класс для отрисовки контрола
    /// </summary>
    public sealed class Painter : WorkCalendarDayPainter
    {
        /// <summary>
        /// Отрисовывает дату
        /// </summary>
        /// <param name="control">Контрол</param>
        /// <param name="gfx">Графический контент</param>
        [SuppressMessage("ReSharper", "RedundantAssignment")]
        public override void DrawDate(WorkCalendarDayControl control, Graphics gfx)
        {
           
            GraphicStateManager.Save(gfx);
            // определяем какой день будем рисовать
            var day = control.CalendarDay.CalendarDayDescription;
            var dayAttribute = control.CalendarDay.CalendarDayAttribute;
            // создаем кисть
            SolidBrush brush;
            // определяем шрифт
            Font font;
            // устанавливаем цвет кисти стиль шрифта
            if (day == CalendarDayDescription.HollyDay)
            {
                // для праздничного дня
                brush = new SolidBrush(control.HollydaysAndWeekendsDayFontColor);
                font = new Font(control.Font.FontFamily, control.Font.Size, FontStyle.Bold);
            }
            if (day == CalendarDayDescription.WeekendDay)
            {
                // для выходного дня
                brush = new SolidBrush(control.HollydaysAndWeekendsDayFontColor);
                font = new Font(control.Font.FontFamily, control.Font.Size, FontStyle.Regular);
            }
            else
            {
                // для обычного дня
                brush = new SolidBrush(control.OrdinaryDayFontColor);
                font = new Font(control.Font.FontFamily, control.Font.Size, FontStyle.Regular);
            }
            if (dayAttribute == WorkDayAttribute.ShortDay)
            {
                // для короткого дня
                brush = new SolidBrush(control.ShortWorkDayColor);
                font = new Font(control.Font.FontFamily, control.Font.Size, FontStyle.Regular);
            }
            // вычисляем размер надписи
            var sizefData = gfx.MeasureString(control.CalendarDay.CalendarDayDate.Date.Day.ToString(), font);
            // вычисляем горизонтальный отступ
            var hOffset = ((control.Width-1) - sizefData.Width) / 2.0f; // не понимаю почему, но с единичкой ровно
            // вычисляем вертикальный размер
            var vOffset = ((control.Height-1) - sizefData.Height) / 2.0f;
            // устанавливаем качество прорисовки текста
            gfx.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            // отрисовываем тект
            gfx.DrawString(control.CalendarDay.CalendarDayDate.Date.Day.ToString(), font,
                brush, new PointF(hOffset, vOffset));
            // возвращаем качество прорисовки в исходное положение
            gfx.TextRenderingHint = TextRenderingHint.SystemDefault;
            brush.Dispose();
            GraphicStateManager.Restore(gfx);
        }

        public override void DrawMarker(WorkCalendarDayControl control, Graphics gfx)
        {
            Color markerColor;

            if (!string.IsNullOrEmpty(control.CalendarDay.CalendarDayComment))
            {
                 markerColor = control.GreenMarkerColor;
            }

            else
            {
                return;
            }
            using (var brush = new SolidBrush(markerColor))
            {
                //gfx.SmoothingMode = SmoothingMode.AntiAlias;
                gfx.FillRectangle( brush, new Rectangle(new Point(control.ClientRectangle.X+1, control.ClientRectangle.Y + 16),  new Size(18, 2)));
                //gfx.SmoothingMode= SmoothingMode.Default;
            }

        }
    }
}