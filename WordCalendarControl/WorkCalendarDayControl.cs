using System;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using AGSoft.WorkCalendar.CoreLibrary;
using AGSoft.WorkCalendarControl.Interfaces;

namespace AGSoft.WorkCalendarControl
{
    [ToolboxItem(true), ToolboxBitmap(typeof(Button))]
    public partial class WorkCalendarDayControl : UserControl
    {
        public WorkCalendarDayControl()
        {
            InitializeComponent();
            // Параметры цветов по умолчанию
            _backColor = base.BackColor;
            _ordinaryDayFontColor = Color.Black;
            _hollydaysAndWeekendsDayColor = Color.Crimson;
            // Шрифты по умолчанию
            _font = base.Font;
        }

        public WorkCalendarDayControl(DateTime date) : this()
        {
            _calendarDay = new CalendarDay(date);
        }

        /// <summary>
        ///     Календарный день
        /// </summary>
        public CalendarDay CalendarDay
        {
            get { return _calendarDay; }
            set
            {
                if (_calendarDay != value)
                {
                    _calendarDay = value;
                    Invalidate();
                }
            }
        }

        public override Color BackColor
        {
            get
            {
                return _backColor;
            }
            set
            {
                if(_backColor!= value)
                {
                    _backColor = value;
                    Invalidate();
                }
            }
        }
        public override Font Font
        {
            get { return _font; }
            set
            {
                if (Equals(value, _font)) return;
                _font = value;
                Invalidate();
            }
        }

        public void DrawDate(Graphics gfx)
        {
            var sizef = gfx.MeasureString(CalendarDay.CalendarDayDate.Date.ToString("dd"), Font);
            gfx.DrawString(CalendarDay.CalendarDayDate.Date.ToString("dd"), Font, new SolidBrush(Color.AliceBlue), new PointF(0, 0));
        }

        public void DrawMarker(Graphics gfx)
        {
            throw new NotImplementedException();
        }

        public void DrawBg(Graphics gfx)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Свойство, показывающее выделен ли компонент
        /// </summary>
        public bool IsSelected
        {
            get { return _isSelected; }

            set
            {
                // Если свойство меняется, то присваеваем новое значение и перерисовываем контрол 
                if (Equals(_isSelected, value)) return;
                _isSelected = value;
                Invalidate();
            }
        }

        public Color BgLeaveColor { get; set; }

        public Color OrdinaryFontColor
        {
            get { return _ordinaryDayFontColor; }
            set
            {
                if (_ordinaryDayFontColor == value) return;
                _ordinaryDayFontColor = value;
                Invalidate();
            }
        }

        public Color HollydaysAndWeekendsDayColor
        {
            get { return _hollydaysAndWeekendsDayColor; }
            set
            {
                if (_hollydaysAndWeekendsDayColor == value) return;
                _hollydaysAndWeekendsDayColor = value;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawDate(e.Graphics);
        }

        #region Поля

        /// <summary>
        ///     структура календарный день
        /// </summary>
        private CalendarDay _calendarDay;
        private bool _isSelected;
        private Color _ordinaryDayFontColor;
        private Color _backColor;
        private Font _font ;
        private Color _hollydaysAndWeekendsDayColor;

        #endregion
    }
}