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
using System;
using AGSoft.WorkCalendar.CoreLibrary;

namespace AGSoft.WorkCalendarControl
{
    /// <summary>
    ///     Описание события изменений в рабочем календаре
    /// </summary>
    public class WorkCalendarDayDataEventArgs : EventArgs
    {
        /// <summary>
        ///     Конструктор
        /// </summary>
        /// <param name="calendarDay">Календарный день</param>
        public WorkCalendarDayDataEventArgs(CalendarDay calendarDay)
        {
            CalendarDay = calendarDay;
        }

        /// <summary>
        ///     Календарный день
        /// </summary>
        private CalendarDay CalendarDay { get; set; }
    }
}