namespace GildedRoseKata.ItemRules
{
    public class ConjuredItemRule : IItemRule
    {
        public void Update(Item item)
        {
            item.SellIn--;

            int amount = item.SellIn < 0 ? 4 : 2;
            item.Quality = Math.Max(0, item.Quality - amount);
        }
    }
}
