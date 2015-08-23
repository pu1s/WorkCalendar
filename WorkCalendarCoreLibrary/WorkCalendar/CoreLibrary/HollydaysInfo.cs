//**********************************************************
// Базовые классы, перечисления и интерфейсы для работы 
// с производственным календарем 
// MS Framework .Net 4.5
// С# version 6.0
// Горин Александр 19.08.2015
// Alex Gorin Software 2015
//*********************************************************

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