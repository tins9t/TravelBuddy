namespace TravelBuddy.UnitTest.TestData;

public static class TestDataDates
{
    public static IEnumerable<object[]> ValidDates =>
        new List<object[]>
        {
            new object[] { DateTime.Today.AddDays(1) },
            new object[] { DateTime.Today.AddDays(2) },
            new object[] { DateTime.Today.AddMonths(6).AddDays(-1) },
            new object[] { DateTime.Today.AddMonths(6) }
        };

    public static IEnumerable<object[]> InvalidDates =>
        new List<object[]>
        {
            new object[] { DateTime.Today },
            new object[] { DateTime.Today.AddMonths(6).AddDays(1) },
            new object[] { DateTime.Today.AddMonths(12) }
        };
}