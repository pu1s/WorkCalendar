using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AGSoft.WorkCalendar.CoreLibrary.Tests
{
    [TestClass]
    public class HollydaysInfoTests
    {
        [TestMethod]
        public void GetCalendarDayDescriptionAndAttributeTest()
        {
            //var calendarday = new CalendarDay(DateTime.Now);
            var calendarday1 = new CalendarDay(DateTime.Now);

            HollydaysInfo.GetCalendarDayDescriptionAndAttribute(DateTime.Now, ref calendarday1);
            Assert.AreEqual(calendarday1, new CalendarDay(DateTime.Now));
        }
    }
}