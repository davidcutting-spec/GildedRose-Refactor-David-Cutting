using System;

namespace GildedRoseKata.ItemRules
{
    /// <summary>
    /// Centralises the logic for selecting the correct rule for each item type.
    /// This keeps GildedRose free of branching logic and makes the system easy to extend:
    /// adding a new item type only requires creating a new rule class and adding a match here.
    /// Exact or prefix matching is used depending on how item names are defined in the requirements.
    /// </summary>
    public static class ItemRuleSelector
    {
        /// <summary>
        /// Determines which rule applies to the given item based on its name.
        /// This keeps the selection logic explicit and makes it easy to introduce new item types.
        /// </summary>
        public static IItemRule Select(Item item)
        {
            // Exact match: Aged Brie has a unique behaviour and a fixed name.
            if (item.Name == "Aged Brie")
                return new AgedBrieRule();

            // Prefix match: Backstage passes always start with this phrase, 
            // but the full name may include the concert title.
            if (item.Name.StartsWith("Backstage passes"))
                return new BackstagePassRule();

            // Prefix match: All conjured items begin with "Conjured", 
            // and the rest of the name varies (e.g., "Conjured Mana Cake").
            if (item.Name.StartsWith("Conjured"))
                return new ConjuredItemRule();

            // Exact match: Sulfuras has a unique behaviour with a fixed name.
            if (item.Name == "Sulfuras, Hand of Ragnaros")
                return new SulfurasRule();

            // Any item not matched above is treated as a normal item.
            return new NormalItemRule();
        }
    }
}
