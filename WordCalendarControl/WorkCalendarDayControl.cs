using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AGSoft.WorkCalendar.CoreLibrary;
using AGSoft.WorkCalendarControl.Interfaces;

namespace AGSoft.WorkCalendarControl
{
    public partial class WorkCalendarDayControl : UserControl
    {
        public WorkCalendarDayControl()
        {
            InitializeComponent();
        }

        public CalendarDay CalendarDay { get; }
        public override Color BackColor { get; set; }
        public override Font Font { get; set; }
    }
}
