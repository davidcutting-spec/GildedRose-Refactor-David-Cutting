namespace GildedRoseKata.ItemRules
{
    public class AgedBrieRule : IItemRule
    {
        public void Update(Item item)
        {
            item.SellIn--;

            int amount = item.SellIn < 0 ? 2 : 1;
            item.Quality = Math.Min(40, item.Quality + amount);
        }
    }
}

