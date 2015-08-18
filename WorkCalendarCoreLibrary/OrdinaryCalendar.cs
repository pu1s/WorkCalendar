using System.Collections.Generic;

namespace AGSoft
{
    public static class OrdinaryCalendar
    {
        public static void GetCalendar()
        {
            // ReSharper disable once JoinDeclarationAndInitializer
            // ReSharper disable once ObjectCreationAsStatement
            new Dictionary<string, string>
            {
                {"01.01", "Новый год!"},
                {"23.02", "День защитника отечества"},
                {"08.03", "Международный женский день"}
            };
        }
        
        
    }
}
