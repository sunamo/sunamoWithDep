namespace sunamo.Tests.Helpers.DT
{
    
    public class DTHelperGeneralTests
    {
        [Fact]
        public void StartOfWeekTest()
        {
            var today = new DateTime(2022, 5, 4);

            // this week before aowWhenCalculateAsStartNextWeek
            Assert.Equal(new DateTime(2022, 5, 2), DTHelperGeneral.StartOfWeekMonday(today, DayOfWeek.Thursday));
            // Same day
            Assert.Equal(new DateTime(2022, 5, 9), DTHelperGeneral.StartOfWeekMonday(new DateTime(2022, 5, 9), DayOfWeek.Thursday));
            // next week before aowWhenCalculateAsStartNextWeek
            Assert.Equal(new DateTime(2022, 5, 9), DTHelperGeneral.StartOfWeekMonday(new DateTime(2022, 5, 10), DayOfWeek.Thursday));
            // this week after aowWhenCalculateAsStartNextWeek
            Assert.Equal(new DateTime(2022, 5, 9), DTHelperGeneral.StartOfWeekMonday(new DateTime(2022, 5, 7), DayOfWeek.Thursday));
        }
    }
}
