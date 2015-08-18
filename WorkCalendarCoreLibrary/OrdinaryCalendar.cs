using System.Collections.Generic;

namespace AGSoft
{
    public static class OrdinaryCalendar
    {
        public static void GetCalendar()
        {
            Dictionary<string, string> yearDictionary;
            yearDictionary = new Dictionary<string, string>();
            yearDictionary.Add("01.01", "Новый год!");
            yearDictionary.Add("23.02", "День защитника отечества");
            yearDictionary.Add("08.03", "Международный женский день");
        }
        
        
    }
}
