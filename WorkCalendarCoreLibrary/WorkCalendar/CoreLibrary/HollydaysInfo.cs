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
    public static class HollydaysInfo
    {
        /// <summary>
        ///     получение аттрибутов, расшифровки и комментариев из календаря по умолчанию
        /// </summary>
        /// <param name="date">Дата</param>
        /// <param name="calendarDay">Ссылка на объект календарного дня</param>
        public static void GetCalendarDayDescriptionAndAttribute(DateTime date, ref CalendarDay calendarDay)
        {
            // Преобразуем дату в строку без года
            var str = date.ToString("dd") + "." + date.ToString("MM");
            // получаем календарь
            var dic = OrdinaryCalendar.GetCalendar();
            // проверяем на наличие в календаре текущей даты
            if (!dic.ContainsKey(str)) return;
            // если она есть, меняеем аттрибуты
            calendarDay.ChangeCalendarDayAttribute(WorkDayAttribute.UnWorkDay);
            // описание
            calendarDay.ChangeCaledarDayDescription(CalendarDayDescription.HollyDay);
            string value;
            dic.TryGetValue(str, out value);
            // и комментарий
            calendarDay.CalendarDayComment = value;
        }
    }
}