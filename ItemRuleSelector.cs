namespace GildedRoseKata.ItemRules
{
    public static class ItemRuleSelector
    {
        public static IItemRule Select(Item item)
        {
            if (item.Name == "Aged Brie")
                return new AgedBrieRule();

            if (item.Name.StartsWith("Backstage passes"))
                return new BackstagePassRule();

            if (item.Name.StartsWith("Conjured"))
                return new ConjuredItemRule();

            if (item.Name == "Sulfuras, Hand of Ragnaros")
                return new SulfurasRule();

            return new NormalItemRule();
        }
    }
}
