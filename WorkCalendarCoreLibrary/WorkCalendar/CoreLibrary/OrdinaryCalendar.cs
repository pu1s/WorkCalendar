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
