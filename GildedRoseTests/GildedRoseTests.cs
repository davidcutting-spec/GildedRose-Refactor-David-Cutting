using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests;

public class GildedRoseTests
{
    /// <summary>
    /// Tests covering the core behaviour of standard (non-special) items.
    /// Normal items lose 1 quality per day, or 2 once expired, and their
    /// quality must never fall below zero. These tests confirm that the
    /// baseline rules for everyday items are applied correctly.
    /// </summary>
    #region NormalItemTests

    // This test covers the basic behaviour for a normal item:
    // quality should drop by 1 each day and SellIn should decrease by 1.
    [Fact]
    public void NormalItem_QualityDegradesByOneEachDay()
    {
        // Arrange (set up the scenario)
        IList<Item> items = new List<Item>
    {
        new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 }
    };
        var app = new GildedRose(items);

        // Action (perform the update)
        app.UpdateQuality();

        // Assert (verify the outcome)
        Assert.Equal(6, items[0].Quality);
        Assert.Equal(4, items[0].SellIn);
    }


    // This test checks the behaviour once a normal item has expired:
    // quality should drop by 2 instead of 1.
    [Fact]
    public void NormalItem_QualityDegradesTwiceAsFastAfterSellIn()
    {
        // Arrange (set up the scenario)
        IList<Item> items = new List<Item>
    {
        new Item { Name = "Elixir of the Mongoose", SellIn = 0, Quality = 7 }
    };
        var app = new GildedRose(items);

        // Action (perform the update)
        app.UpdateQuality();

        // Assert (verify the outcome)
        Assert.Equal(5, items[0].Quality);   // dropped by 2
        Assert.Equal(-1, items[0].SellIn);   // SellIn still decreases by 1
    }


    // This test ensures a normal item's quality never becomes negative,
    // even if it would normally degrade.
    [Fact]
    public void NormalItem_QualityNeverGoesBelowZero()
    {

        // Arrange (set up the scenario)
        IList<Item> items = new List<Item>
    {
        new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 0 }
    };
        var app = new GildedRose(items);

        // Action (perform the update)
        app.UpdateQuality();

        // Assert (verify the outcome)
        Assert.Equal(0, items[0].Quality);   // stays at zero
    }
    #endregion


    /// <summary>
    /// Tests covering the behaviour of Aged Brie, which becomes more valuable as it ages. 
    /// Brie gains quality each day, increases faster after expiry,
    /// and must always remain capped at the maximum quality limit of 40.
    /// </summary>
    #region AgedBrieTests

    // This test verifies that Aged Brie gains 1 quality point each day as it ages before SellIn date has passed.
    [Fact]
    public void AgedBrie_QualityIncreasesEachDay()
    {
        // Arrange (set up the scenario)
        IList<Item> items = new List<Item>
    {
        new Item { Name = "Aged Brie", SellIn = 5, Quality = 10 }
    };
        var app = new GildedRose(items);

        // Action (perform the update)
        app.UpdateQuality();

        // Assert (verify the outcome)
        Assert.Equal(11, items[0].Quality);
        Assert.Equal(4, items[0].SellIn);
    }


    // This test verifies that Aged Brie gains quality twice as fast once the SellIn date has passed.
    [Fact]
    public void AgedBrie_QualityIncreasesTwiceAsFastAfterSellIn()
    {
        // Arrange (set up the scenario)
        IList<Item> items = new List<Item>
    {
        new Item { Name = "Aged Brie", SellIn = 0, Quality = 10 }
    };
        var app = new GildedRose(items);

        // Action (perform the update)
        app.UpdateQuality();

        // Assert (verify the outcome)
        Assert.Equal(12, items[0].Quality);   // increased by 2
        Assert.Equal(-1, items[0].SellIn);
    }


    // This test verifies that Aged Brie quality should never exceed the maximum value of 40.
    [Fact]
    public void AgedBrie_QualityNeverExceedsForty()

    {
        // Arrange (set up the scenario)
        IList<Item> items = new List<Item>
    {
        new Item { Name = "Aged Brie", SellIn = 5, Quality = 40 }
    };
        var app = new GildedRose(items);

        // Action (perform the update)
        app.UpdateQuality();

        // Assert (verify the outcome)
        Assert.Equal(40, items[0].Quality);   // stays capped at 40
    }

    #endregion


    /// <summary>
    /// Tests covering the behaviour of Backstage Passes. 
    /// Value increases as the concert approaches. 
    /// Quality rises at different rates depending on how many days remain, but drops to zero immediately after the event.
    /// </summary>
    #region BackstagePassTests

    // This test verifies that Backstage Passes increase in quality by 1 when SellIn is above 7.
    [Fact]
    public void BackstagePass_QualityIncreasesByOneWhenMoreThanSevenDaysLeft()
    {
        // Arrange (set up the scenario)
        IList<Item> items = new List<Item>
    {
        new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 }
    };
        var app = new GildedRose(items);

        // Action (perform the update)
        app.UpdateQuality();

        // Assert (verify the outcome)
        Assert.Equal(21, items[0].Quality);
        Assert.Equal(14, items[0].SellIn);
    }

    // This test verifies that Backstage Passes increase in quality by 3 when SellIn is 7 days or less.
    [Fact]
    public void BackstagePass_QualityIncreasesByThreeWhenSevenDaysOrLess()
    {
        // Arrange (set up the scenario)
        IList<Item> items = new List<Item>
    {
        new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 7, Quality = 20 }
    };
        var app = new GildedRose(items);

        // Action (perform the update)
        app.UpdateQuality();

        // Assert (verify the outcome)
        Assert.Equal(23, items[0].Quality);   // +3
        Assert.Equal(6, items[0].SellIn);
    }

    // This test verifies that Backstage Passes increase in quality by 4 when SellIn is 2 days or less.
    [Fact]
    public void BackstagePass_QualityIncreasesByFourWhenTwoDaysOrLess()
    {
        // Arrange (set up the scenario)
        IList<Item> items = new List<Item>
    {
        new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 2, Quality = 20 }
    };
        var app = new GildedRose(items);

        // Action (perform the update)
        app.UpdateQuality();

        // Assert (verify the outcome)
        Assert.Equal(24, items[0].Quality);   // +4
        Assert.Equal(1, items[0].SellIn);
    }

    // This test verifies that Backstage Passes drop to zero quality after the concert.
    [Fact]
    public void BackstagePass_QualityDropsToZeroAfterConcert()
    {
        // Arrange (set up the scenario)
        IList<Item> items = new List<Item>
    {
        new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 20 }
    };
        var app = new GildedRose(items);

        // Action (perform the update)
        app.UpdateQuality();

        // Assert (verify the outcome)
        Assert.Equal(0, items[0].Quality);
        Assert.Equal(-1, items[0].SellIn);
    }

    // This test verifies that Backstage Pass quality should never exceed the maximum value of 40.
    [Fact]
    public void BackstagePass_QualityNeverExceedsForty()
    {
        // Arrange (set up the scenario)
        IList<Item> items = new List<Item>
    {
        new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 40 }
    };
        var app = new GildedRose(items);

        // Action (perform the update)
        app.UpdateQuality();

        // Assert (verify the outcome)
        Assert.Equal(40, items[0].Quality);   // stays capped at 40
    }

    #endregion


    /// <summary>
    /// Test covering Sulfuras. 
    /// Unlike all other items, Sulfuras is a legendary item that never degrades in quality and never needs to be sold.
    /// Sulfuras never decreases in quality and its SellIn value never changes.
    /// This test confirm that its immutable behaviour is preserved.
    /// </summary>
    #region SulfurasTests

    // This test verifies that Sulfuras is a legendary item: its quality never changes and it never needs to be sold.
    [Fact]
    public void Sulfuras_QualityAndSellInNeverChange()
    {
        // Arrange (set up the scenario)
        IList<Item> items = new List<Item>
    {
        new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 40 }
    };
        var app = new GildedRose(items);

        // Action (perform the update)
        app.UpdateQuality();

        // Assert (verify the outcome)
        Assert.Equal(40, items[0].Quality);   // quality stays constant
        Assert.Equal(5, items[0].SellIn);     // sell-in stays constant
    }

    #endregion


    /// <summary>
    /// Tests covering Conjured items.
    /// Conjured items degrade in quality faster than standard items. 
    /// Conjured items lose quality at twice the normal rate, and this acceleration doubles again after the SellIn date has passed.
    /// These tests confirm both degradation rates and the quality floor.
    #region ConjuredItemTests

    // This test verifies that Conjured items degrade in quality twice as fast as normal items.
    [Fact]
    public void ConjuredItem_QualityDegradesTwiceAsFastAsNormalItems()
    {
        // Arrange (set up the scenario)
        IList<Item> items = new List<Item>
    {
        new Item { Name = "Conjured Mana Cake", SellIn = 5, Quality = 10 }
    };
        var app = new GildedRose(items);

        // Action (perform the update)
        app.UpdateQuality();

        // Assert (verify the outcome)
        Assert.Equal(8, items[0].Quality);   // dropped by 2
        Assert.Equal(4, items[0].SellIn);
    }

    // This test verifies that Conjured items degrade twice as fast again once the SellIn date has passed.
    [Fact]
    public void ConjuredItem_QualityDegradesFourTimesAsFastAfterSellIn()
    {
        // Arrange (set up the scenario)
        IList<Item> items = new List<Item>
    {
        new Item { Name = "Conjured Mana Cake", SellIn = 0, Quality = 10 }
    };
        var app = new GildedRose(items);

        // Action (perform the update)
        app.UpdateQuality();

        // Assert (verify the outcome)
        Assert.Equal(6, items[0].Quality);   // dropped by 4
        Assert.Equal(-1, items[0].SellIn);
    }


    // This test verifies that Conjured item quality should never become negative.
    [Fact]
    public void ConjuredItem_QualityNeverGoesBelowZero()
    {
        // Arrange (set up the scenario)
        IList<Item> items = new List<Item>
    {
        new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 1 }
    };
        var app = new GildedRose(items);

        // Action (perform the update)
        app.UpdateQuality();

        // Assert (verify the outcome)
        Assert.Equal(0, items[0].Quality);   // stays at zero
    }

    #endregion


}
