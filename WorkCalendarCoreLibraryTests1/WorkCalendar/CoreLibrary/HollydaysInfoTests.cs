using System;
using AGSoft.WorkCalendar.CoreLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WorkCalendarCoreLibraryTests1.WorkCalendar.CoreLibrary
{
    [TestClass()]
    public class HollydaysInfoTests
    {
        [TestMethod()]
        public void GetCalendarDayDescriptionAndAttributeTest()
        {
           var a1 = new CalendarDay(DateTime.Now);
            HollydaysInfo.GetCalendarDayDescriptionAndAttribute(new DateTime(DateTime.Now.Year, 01, 01), ref a1);
            Assert.AreEqual<CalendarDay>(a1, new CalendarDay(new DateTime(DateTime.Now.Year, 01, 01)));
        }
    }
}