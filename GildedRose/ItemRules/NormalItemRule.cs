using System;

namespace GildedRoseKata.ItemRules
{
    public class NormalItemRule : IItemRule
    {
        /// <summary>
        /// Default behaviour for standard items: quality drops each day,
        /// and drops faster once the sell-by date has passed.
        /// </summary>
        public void Update(Item item)
        {
            // Normal items reduce their sell-in value each day.
            item.SellIn--;

            // After the sell-by date, quality falls twice as fast.
            int amount = item.SellIn < 0 ? 2 : 1;

            // Quality can't go below zero.
            item.Quality = Math.Max(0, item.Quality - amount);
        }
    }
}

