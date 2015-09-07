//**********************************************************
// Базовые классы, перечисления и интерфейсы для работы 
// с производственным календарем 
// MS Framework .Net 4.5
// С# version 6.0
// Горин Александр 19.08.2015
// Alex Gorin Software 2015
//*********************************************************

using System;
using AGSoft.WorkCalendar.CoreLibrary;

namespace AGSoft.WC.CoreLibrary
{
    public static class WCHollydaysInfo
    {
        /// <summary>
        ///     получение аттрибутов, расшифровки и комментариев из календаря по умолчанию
        /// </summary>
        /// <param name="date">Дата</param>
        /// <param name="calendarDay">Ссылка на объект календарного дня</param>
        public static void GetWCDayDescriptionAndAttribute(DateTime date, ref WCDay calendarDay)
        {
            // Преобразуем дату в строку без года
            var str = date.ToString("dd") + "." + date.ToString("MM");
            // получаем календарь
            var dic = OrdinaryCalendar.GetCalendar();
            // проверяем на наличие в календаре текущей даты
            if (!dic.ContainsKey(str)) return;
            // если она есть, меняеем аттрибуты
            calendarDay.ChangeCalendarDayAttribute(WCDayAttribute.UnWorkDay);
            // описание
            calendarDay.ChangeCaledarDayDescription(WCDayDescription.HollyDay);
            string value;
            dic.TryGetValue(str, out value);
            // и комментарий
            calendarDay.WDDayComment = value;
        }
    }
}