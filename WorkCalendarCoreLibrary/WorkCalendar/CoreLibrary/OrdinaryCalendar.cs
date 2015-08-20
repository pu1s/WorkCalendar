//**********************************************************
// Базовые классы, перечисления и интерфейсы для работы 
// с производственным календарем 
// MS Framework .Net 4.5
// С# version 6.0
// Горин Александр 19.08.2015
// Alex Gorin Software 2015
//*********************************************************
using System.Collections.Generic;

namespace AGSoft.WorkCalendar.CoreLibrary
{
    public static class OrdinaryCalendar
    {
        public static Dictionary<string, string> GetCalendar()
        {
            
             return new Dictionary<string, string>
            {
                {"01.01", "Новый год"},
                {"23.02", "День защитника отечества"},
                {"08.03", "Международный женский день"},
                {"01.05", "Первое мая" },
                {"09.05", "День победы" }
            };
        }
        
        
    }
}
