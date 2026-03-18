
using System;

namespace GildedRoseKata.ItemRules
{
    /// <summary>
    /// Handles the behaviour for Aged Brie, which increases in quality as it ages.
    /// The rate of increase doubles once the sell-by date has passed.
    /// </summary>
    public class AgedBrieRule : IItemRule
    {
        public void Update(Item item)
        {
            // Aged Brie still counts down its sell-in value each day.
            item.SellIn--;

            // After the sell-by date, Brie improves twice as fast.
            int amount = item.SellIn < 0 ? 2 : 1;

            // Quality is capped at 40 to prevent it exceeding the allowed maximum.
            item.Quality = Math.Min(40, item.Quality + amount);
        }
    }
}

