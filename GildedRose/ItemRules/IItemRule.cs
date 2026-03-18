using System;

namespace GildedRoseKata.ItemRules
{
    /// <summary>
    /// Contract for item rules. Each item type defines its own update behaviour.
    /// </summary>
    public interface IItemRule
    {
        void Update(Item item);
    }
}

