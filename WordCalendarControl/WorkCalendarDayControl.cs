#define DEBUG
using System;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using AGSoft.WorkCalendar.CoreLibrary;
using AGSoft.WorkCalendarControl.Interfaces;

namespace AGSoft.WorkCalendarControl
{
    [ToolboxItem(true), ToolboxBitmap(typeof(Button))]
    public partial class WorkCalendarDayControl : UserControl, WorkCalendarDay, IWorkCalendarDayControlProp
    {
        public WorkCalendarDayControl()
        {
            
            InitializeComponent();
            // Параметры цветов по умолчанию
            // CLR говорит о исключениях при инициализации цвета поэтому так =>
            try
            {
                InitializeColors();
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            // Шрифты по умолчанию
            _font = base.Font;
#if DEBUG
            _calendarDay = new CalendarDay(DateTime.Now);
            _calendarDay.ChangeCalendarDayAttribute(WorkDayAttribute.ShortDay);
            _calendarDay.CalendarDayComment = "Test comment";
#endif
            //this.BorderStyle = BorderStyle.FixedSingle;
            //this.BackColor = Color.BurlyWood;
        }

        private void InitializeColors()
        {
            _backColor = base.BackColor;
            _leaveControlColor = Color.Gainsboro;
            _ordinaryDayFontColor = Color.Black;
            _hollydaysAndWeekendsDayFontFontColor = Color.Crimson;
            _shortWorkDayFontColor = Color.Blue;
            _greenMarkerColor = Color.Chartreuse;
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
                if (_backColor == value) return;
                _backColor = value;
                Invalidate();
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


        /// <summary>
        ///     Свойство, показывающее выделен ли компонент
        /// </summary>
        public bool IsControlSelected
        {
            get { return _isControlSelected; }

            set
            {
                // Если свойство меняется, то присваеваем новое значение и перерисовываем контрол 
                if (Equals(_isControlSelected, value)) return;
                _isControlSelected = value;
                Invalidate();
                //Если свойство правда, то меняем значение свойства цвета фона
                if (_isControlSelected) { BackColor = _selectControlColor; }
            }
        }

        public Color LeaveControlColor
        {
            get { return _leaveControlColor; }
            set
            {
                if (_leaveControlColor == value) return;
                _leaveControlColor = value;
                Invalidate();
            }
        }

        public Color OrdinaryDayFontColor
        {
            get { return _ordinaryDayFontColor; }
            set
            {
                if (_ordinaryDayFontColor == value) return;
                _ordinaryDayFontColor = value;
                Invalidate();
            }
        }

        public Color HollydaysAndWeekendsDayFontColor
        {
            get { return _hollydaysAndWeekendsDayFontFontColor; }
            set
            {
                if (_hollydaysAndWeekendsDayFontFontColor == value) return;
                _hollydaysAndWeekendsDayFontFontColor = value;
                Invalidate();
            }
        }

        public Color SelectControlColor
        {
            get { return _selectControlColor; }
            set
            {
                if (_selectControlColor == value) return;
                _selectControlColor = value;
                Invalidate();
            }
        }

        public Color ShortWorkDayColor
        {
            get { return _shortWorkDayFontColor; }
            set
            {
                if (_shortWorkDayFontColor == value) return;
                _shortWorkDayFontColor = value;
                Invalidate();
            }
        }

        public Color GreenMarkerColor => _greenMarkerColor;

        #region Методы

        private void StartTimer()
        {
            _timer = new Timer {Interval = 40, Enabled = true};
            _timer.Start();
            _timer.Tick += _timer_Tick;
            _i = 0;
        }

        private void StopTimer()
        {
            if (_timer.Enabled)
                _timer.Stop();
            _timer.Dispose();
        }

        #endregion


        protected override void OnPaint(PaintEventArgs e)
        {
            Painter p = new Painter();
            p.DrawMarker(control: this, gfx: e.Graphics);
            p.DrawDate(control: this, gfx: e.Graphics);
           
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            BgPainter bgPainter = new BgPainter();
            bgPainter.DrawBg(control: this, gfx: e.Graphics);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            StopTimer();
            BackColor = base.BackColor;
        }
       

        protected override void OnMouseEnter(EventArgs e)
        {
            StartTimer();
        }

       
        private void _timer_Tick(object sender, EventArgs e)
        {
            if (_i == 10)
            {
               StopTimer();
            }
            else
            {
                var x = (int)25.5d*_i;
                BackColor = Color.FromArgb(x, LeaveControlColor);
                _i++;
            }

        }

        protected override void OnMouseHover(EventArgs e)
        {
            base.OnMouseHover(e);
        }

        #region Поля

        /// <summary>
        ///     структура календарный день
        /// </summary>
        private CalendarDay _calendarDay;
        private bool _isControlSelected;
        private Color _ordinaryDayFontColor;
        private Color _backColor;
        private Font _font;
        private Color _hollydaysAndWeekendsDayFontFontColor;
        private Color _shortWorkDayFontColor;
        private Color _greenMarkerColor;
        private Color _selectControlColor;
        private Color _leaveControlColor;
        private Timer _timer;
        private int _i;

        #endregion
    }
}