using System;

namespace GildedRoseKata.ItemRules
{
    /// <summary>
    /// Handles the behaviour for Backstage passes, which increase in value as the concert approaches.
    /// The rate of increase accelerates as the sell-in window gets smaller, but drops to zero once the event has passed.
    /// </summary>
    public class BackstagePassRule : IItemRule
    {
        public void Update(Item item)
        {
            // Backstage passes still count down their sell-in value each day.
            item.SellIn--;

            // Once the concert date has passed, quality drops to zero.
            if (item.SellIn < 0)
            {
                item.Quality = 0;
                return;
            }

            // The closer we get to the concert, the faster the quality increases.
            //  - Last 2 days: biggest jump
            //  - Last week: moderate jump
            //  - Otherwise: normal increase
            int increase =
                item.SellIn <= 2 ? 4 :
                item.SellIn <= 7 ? 3 :
                1;

            // Quality is capped to avoid exceeding the allowed maximum.
            item.Quality = Math.Min(40, item.Quality + increase);
        }
    }
}
