namespace GildedRoseKata.ItemRules
{
    public class BackstagePassRule : IItemRule
    {
        public void Update(Item item)
        {
            item.SellIn--;

            if (item.SellIn < 0)
            {
                item.Quality = 0;
                return;
            }

            int increase =
                item.SellIn <= 2 ? 4 :
                item.SellIn <= 7 ? 3 :
                1;

            item.Quality = Math.Min(40, item.Quality + increase);
        }
    }
}
