using TravelBuddy.Core.Enums;

namespace TravelBuddy.UnitTest.TestData;

public class PriceCalculationTestData
{
    public static IEnumerable<object[]> PriceCalculationData()
    {
        // Economy, Meal.None
        yield return new object[] { TravelClass.Economy, Meal.None, 3, 1875.00 };  // availableSeats = 27/30 = 0.9 load 1.25
        yield return new object[] { TravelClass.Economy, Meal.None, 7, 1725.00 }; // availableSeats = 24/30 = 0.76 load 1.2
        yield return new object[] { TravelClass.Economy, Meal.None, 15, 1575.00 }; // availableSeats = 18/30 = 0.5 load 1.1
        yield return new object[] { TravelClass.Economy, Meal.None, 20, 1500.00 }; // availableSeats = 10/30 = 0.33 load 1.0

        yield return new object[] { TravelClass.Economy, Meal.Standard, 3, 1937.50 };
        yield return new object[] { TravelClass.Economy, Meal.Standard, 7, 1782.50 };
        yield return new object[] { TravelClass.Economy, Meal.Standard, 15, 1627.50 };
        yield return new object[] { TravelClass.Economy, Meal.Standard, 20, 1550.00 };

        yield return new object[] { TravelClass.Economy, Meal.Vegetarian, 3, 1962.50 };
        yield return new object[] { TravelClass.Economy, Meal.Vegetarian, 7, 1805.50 };
        yield return new object[] { TravelClass.Economy, Meal.Vegetarian, 15, 1648.50 };
        yield return new object[] { TravelClass.Economy, Meal.Vegetarian, 20, 1570.00 };

        yield return new object[] { TravelClass.Business, Meal.None, 3, 2500 };
        yield return new object[] { TravelClass.Business, Meal.None, 7, 2300.00 };
        yield return new object[] { TravelClass.Business, Meal.None, 15, 2100.00 };
        yield return new object[] { TravelClass.Business, Meal.None, 20, 2000.00 };

        yield return new object[] { TravelClass.Business, Meal.Standard, 3, 2562.50 };
        yield return new object[] { TravelClass.Business, Meal.Standard, 7, 2357.50 };
        yield return new object[] { TravelClass.Business, Meal.Standard, 15, 2152.50 };
        yield return new object[] { TravelClass.Business, Meal.Standard, 20, 2050.00 };

        yield return new object[] { TravelClass.Business, Meal.Vegetarian, 3, 2587.50 };
        yield return new object[] { TravelClass.Business, Meal.Vegetarian, 7, 2380.50 };
        yield return new object[] { TravelClass.Business, Meal.Vegetarian, 15, 2173.50 };
        yield return new object[] { TravelClass.Business, Meal.Vegetarian, 20, 2070.00 };

        yield return new object[] { TravelClass.First, Meal.None, 3, 3750.00 };
        yield return new object[] { TravelClass.First, Meal.None, 7, 3450.00 };
        yield return new object[] { TravelClass.First, Meal.None, 15, 3150.00 };
        yield return new object[] { TravelClass.First, Meal.None, 20, 3000.00 };

        yield return new object[] { TravelClass.First, Meal.Standard, 3, 3812.50 };
        yield return new object[] { TravelClass.First, Meal.Standard, 7, 3507.50 };
        yield return new object[] { TravelClass.First, Meal.Standard, 15, 3202.50 };
        yield return new object[] { TravelClass.First, Meal.Standard, 20, 3050.00 };

        yield return new object[] { TravelClass.First, Meal.Vegetarian, 3, 3837.50 };
        yield return new object[] { TravelClass.First, Meal.Vegetarian, 7, 3530.50 };
        yield return new object[] { TravelClass.First, Meal.Vegetarian, 15, 3223.50 };
        yield return new object[] { TravelClass.First, Meal.Vegetarian, 20, 3070.00 };
    }
}
