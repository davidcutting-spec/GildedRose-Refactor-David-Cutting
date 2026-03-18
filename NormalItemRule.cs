namespace GildedRoseKata.ItemRules
{
    public class NormalItemRule : IItemRule
    {
        public void Update(Item item)
        {
            item.SellIn--;

            int amount = item.SellIn < 0 ? 2 : 1;
            item.Quality = Math.Max(0, item.Quality - amount);
        }
    }
}

