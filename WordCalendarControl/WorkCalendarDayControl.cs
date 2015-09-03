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



        public WorkCalendarDayControl(DateTime date) : this()
        {
            _calendarDay = new CalendarDay(date);
        }



        #region Свойства
        /// <summary>
        ///     Календарный день
        /// </summary> 
        public CalendarDay CalendarDay
        {
            get { return _calendarDay; }
            set
            {
                if (_calendarDay == value) return;
                // если есть изменения то вызываем событие
                OnWorkCalendarDayDataChanged();
                // присваеваем новое значение
                _calendarDay = value;
                // перерисовываем
                Invalidate();
            }
        }

        public override Color BackColor
        {
            get { return _backColor; }
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
                if (_isControlSelected)
                {
                    BackColor = _selectControlBackColor;
                }
            }
        }

        public Color LeaveControlColor
        {
            get { return _leaveControlBackColor; }
            set
            {
                if (_leaveControlBackColor == value) return;
                _leaveControlBackColor = value;
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

        public Color SelectControlBackColor
        {
            get { return _selectControlBackColor; }
            set
            {
                if (_selectControlBackColor == value) return;
                _selectControlBackColor = value;
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

        #endregion

        #region Методы
        /// <summary>
        /// инициализация цветов компанета по умолчанию
        /// </summary>
        private void InitializeColors()
        {
            _backColor = base.BackColor;
            _leaveControlBackColor = Color.Gainsboro;
            _ordinaryDayFontColor = Color.Black;
            _hollydaysAndWeekendsDayFontFontColor = Color.Crimson;
            _shortWorkDayFontColor = Color.Blue;
            _greenMarkerColor = Color.Chartreuse;
        }
        /*
        для плавной смены цвета при наведении компанента
        понадобится таймер private Timer _timer
        */
        /// <summary>
        /// запускает таймер
        /// </summary>
        private void StartTimer()
        {
            _timer = new Timer { Interval = 50, Enabled = true };
            _timer.Start();
            _timer.Tick += _timer_Tick;
            _i = 0;
        }
        /// <summary>
        /// останавливает таймер
        /// </summary>
        private void StopTimer()
        {
            if (_timer.Enabled)
                _timer.Stop();
            _timer.Dispose();
        }

        #endregion

        #region Переопределенные методы

        protected override void OnPaint(PaintEventArgs e)
        {
            var p = new Painter();
            p.DrawMarker(control: this, gfx: e.Graphics);
            p.DrawDate(control: this, gfx: e.Graphics);

        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            var bgPainter = new BgPainter();
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

        #endregion


        #region Обработчики событий

        private void _timer_Tick(object sender, EventArgs e)
        {
            if (_i == 10)
            {
                StopTimer();
            }
            else
            {
                var x = (int)25.5d * _i;
                BackColor = Color.FromArgb(x, LeaveControlColor);
                _i++;
            }

        }

        #endregion


        //protected override void OnMouseHover(EventArgs e)
        //{
        //    base.OnMouseHover(e);
        //}

        #region Методы, вызывающие события
        /// <summary>
        /// Вызывает событие при изменении данных в структуре CalendarDay
        /// </summary>
        protected virtual void OnWorkCalendarDayDataChanged()
        {
            WorkCalendarDayDataChange?.Invoke(this, new WorkCalendarDayDataEventArgs(CalendarDay));
        }
        /// <summary>
        /// Вызывает событие при выделении компанента
        /// </summary>
        protected virtual void OnWorkcalendarDayControlSelect()
        {
            WorkcalendarDayControlSelect?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region События
        /// <summary>
        /// Событие, возникающее при изменении данных в структуре CalendarDay в компоненте
        /// </summary>
        public event EventHandler<WorkCalendarDayDataEventArgs> WorkCalendarDayDataChange;
        /// <summary>
        /// Событие, возникающее при выделении компонента
        /// </summary>
        public event EventHandler WorkcalendarDayControlSelect;

        #endregion

        #region Поля

        /// <summary>
        ///     структура календарный день
        /// </summary>
        private CalendarDay _calendarDay;
        /// <summary>
        /// выделен ли компанент
        /// </summary>
        private bool _isControlSelected;
        /// <summary>
        /// цвет шрифта обычного дня
        /// </summary>
        private Color _ordinaryDayFontColor;
        /// <summary>
        /// цвет подложки
        /// </summary>
        private Color _backColor;
        /// <summary>
        /// шрифт компанента
        /// </summary>
        private Font _font;
        /// <summary>
        /// цвет шрифта выходного или празничного дня
        /// </summary>
        private Color _hollydaysAndWeekendsDayFontFontColor;
        /// <summary>
        /// цвет шрифта "короткого" рабочего дня
        /// </summary>
        private Color _shortWorkDayFontColor;
        /// <summary>
        /// цвет маркера
        /// </summary>
        private Color _greenMarkerColor;
        /// <summary>
        /// цвет подложки выделенного компанента
        /// </summary>
        private Color _selectControlBackColor;
        /// <summary>
        /// цвет подложки компанента при наведении курсора
        /// </summary>
        private Color _leaveControlBackColor;
        /// <summary>
        /// таймер
        /// </summary>
        private Timer _timer;
        /// <summary>
        /// переменная - счетчик
        /// </summary>
        private int _i; // переменная счетчик

        #endregion


    }
}