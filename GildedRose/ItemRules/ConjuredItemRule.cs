using System;

namespace GildedRoseKata.ItemRules
{
    /// <summary>
    /// Handles the rules for Conjured items, which degrade in quality twice as fast as normal items.
    /// Once the sell-by date has passed, the rate doubles again.
    /// </summary>
    public class ConjuredItemRule : IItemRule
    {
        public void Update(Item item)
        {
            // Conjured items still reduce their sell-in value each day.
            item.SellIn--;

            // Conjured items lose quality at twice the normal rate,
            // and twice that again once they're past their sell-by date.
            int amount = item.SellIn < 0 ? 4 : 2;

            // Quality can't drop below zero.
            item.Quality = Math.Max(0, item.Quality - amount);
        }
    }
}
