using System;

namespace GildedRoseKata.ItemRules
{
    /// <summary>
    /// Sulfuras is a legendary item, so its values never change.
    /// </summary>
    public class SulfurasRule : IItemRule
    {
        public void Update(Item item)
        {
            // Legendary item: no changes to SellIn or Quality
        }
    }
}
