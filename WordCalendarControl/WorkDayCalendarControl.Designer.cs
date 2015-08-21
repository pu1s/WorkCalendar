using System;
using System.Drawing;
using AGSoft.WorkCalendar.CoreLibrary;

namespace AGSoft.WorkCalendarControl
{
    partial class WorkDayCalendarControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        }

        #endregion

        public Color BgColor
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public Color FColor
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public Color FontColor
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public bool IsCommented
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public bool IsHintEnable
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public bool IsMouseLeave
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public CalendarDay CalendarDay
        {
            get { throw new NotImplementedException(); }
        }

        public event EventHandler ChangeAttributeDescriptionComment;
        public event EventHandler ChangeMouseLeave;
        public void OnChangeAttributeDescriptionComment()
        {
            throw new NotImplementedException();
        }

        public void OnChangeMouseLeave()
        {
            throw new NotImplementedException();
        }
    }
}
