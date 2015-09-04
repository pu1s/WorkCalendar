/**********************************************************
 Базовые классы, перечисления и интерфейсы для работы 
 с производственным календарем 
 MS Framework .Net 4.5
==========================================================
Этот файл является частью программы WorkCalendar
отображения календаря для использования на производстве и 
в бухгалтерском учете
==========================================================
Автор кода программы: Горин Александр pu1s@outlook.com
Copyright © Alex Gorin Software 2015 All rights reserved
==========================================================
Программа является иннтеллектуальной собственностью 
автора. Изменения в исходном коде программы должны
согласовыватьяс с автором.
Программа распостраняется в соответствии с
GNU GENERAL PUBLIC LICENSE
Версия 2, июнь 1991г.
Copyright (C) 1989, 1991 Free Software Foundation, Inc.
59 Temple Place - Suite 330, Boston, MA 02111-1307, USA
==========================================================
*/
using System;

namespace AGSoft.WorkCalendar.CoreLibrary
{
    /// <summary>
    ///     Интерфейс, определяющий календарный день
    /// </summary>
    public interface ICalendarDay
    {
        /// <summary>
        ///     Дата, соответствующая календарному дню
        /// </summary>
        DateTime CalendarDayDate { get; }

        /// <summary>
        ///     Свойство, определяющее аттрибуты дня в производственном календаре
        /// </summary>
        WorkDayAttribute CalendarDayAttribute { get; }

        /// <summary>
        ///     Свойство, определяюшее состояние календарного дня
        /// </summary>
        CalendarDayDescription CalendarDayDescription { get; }

        /// <summary>
        ///     Комментарий для календарного дня
        /// </summary>
        string CalendarDayComment { get; set; }

        /// <summary>
        ///     Уникальный индентификатор календарного дня
        /// </summary>
        int CalendarDayHandle { get; }
    }
}