using System;
using System.Drawing;
using System.Windows.Forms;
using AGSoft.WorkCalendar.CoreLibrary;
using AGSoft.WorkCalendarControl.Interfaces;

namespace AGSoft.WorkCalendarControl
{
    public partial class WorkCalendarDayControl : UserControl, IWorkCalendarDayControlProperty,
        IWorkCalendarDayControlPaint
    {
        public WorkCalendarDayControl()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     Календарный день
        /// </summary>
        public CalendarDay CalendarDay
        {
            get { return _calendarDay; }
            set { _calendarDay = value; }
        }

        public override Color BackColor { get; set; }
        public override Font Font { get; set; }

        public void DrawDate(Graphics gfx)
        {
            throw new NotImplementedException();
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

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        #region Поля

        /// <summary>
        ///     структура календарный день
        /// </summary>
        private CalendarDay _calendarDay;

        private bool _isSelected;

        #endregion
    }
}