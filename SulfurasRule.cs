using System;

namespace GildedRoseKata.ItemRules
{
    public class SulfurasRule : IItemRule
    {
        public void Update(Item item)
        {
            // Legendary item: no changes to SellIn or Quality
        }
    }
}
