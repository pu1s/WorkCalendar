namespace TestApp
{
    partial class Form1
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.workCalendarDayControl1 = new AGSoft.WorkCalendarControl.WorkCalendarDayControl();
            this.SuspendLayout();
            // 
            // workCalendarDayControl1
            // 
            this.workCalendarDayControl1.BgLeaveColor = System.Drawing.Color.Empty;
            this.workCalendarDayControl1.CalendarDay = ((AGSoft.WorkCalendar.CoreLibrary.CalendarDay)(resources.GetObject("workCalendarDayControl1.CalendarDay")));
            this.workCalendarDayControl1.HollydaysAndWeekendsDayColor = System.Drawing.Color.Crimson;
            this.workCalendarDayControl1.IsSelected = false;
            this.workCalendarDayControl1.Location = new System.Drawing.Point(323, 60);
            this.workCalendarDayControl1.MaximumSize = new System.Drawing.Size(20, 20);
            this.workCalendarDayControl1.Name = "workCalendarDayControl1";
            this.workCalendarDayControl1.OrdinaryDayFontColor = System.Drawing.Color.Black;
            this.workCalendarDayControl1.Size = new System.Drawing.Size(20, 20);
            this.workCalendarDayControl1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 410);
            this.Controls.Add(this.workCalendarDayControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private AGSoft.WorkCalendarControl.WorkCalendarDayControl workCalendarDayControl1;
    }
}

