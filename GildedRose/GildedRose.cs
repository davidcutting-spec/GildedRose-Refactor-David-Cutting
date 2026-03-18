using GildedRoseKata.ItemRules;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;

namespace GildedRoseKata;

public class GildedRose
{
    IList<Item> Items;

    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }

    public void UpdateQuality()
    {
        /*
        * Commented Out: 
        * This was the placeholder test.
        * I kept original code commented out for reference and to show improvement.
        */
        #region OriginalPlaceholderTest
        //for (var i = 0; i < Items.Count; i++)
        //{
        //    if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
        //    {
        //        if (Items[i].Quality > 0)
        //        {
        //            if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
        //            {
        //                Items[i].Quality = Items[i].Quality - 1;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        if (Items[i].Quality < 50)
        //        {
        //            Items[i].Quality = Items[i].Quality + 1;

        //            if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
        //            {
        //                if (Items[i].SellIn < 11)
        //                {
        //                    if (Items[i].Quality < 50)
        //                    {
        //                        Items[i].Quality = Items[i].Quality + 1;
        //                    }
        //                }

        //                if (Items[i].SellIn < 6)
        //                {
        //                    if (Items[i].Quality < 50)
        //                    {
        //                        Items[i].Quality = Items[i].Quality + 1;
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
        //    {
        //        Items[i].SellIn = Items[i].SellIn - 1;
        //    }

        //    if (Items[i].SellIn < 0)
        //    {
        //        if (Items[i].Name != "Aged Brie")
        //        {
        //            if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
        //            {
        //                if (Items[i].Quality > 0)
        //                {
        //                    if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
        //                    {
        //                        Items[i].Quality = Items[i].Quality - 1;
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                Items[i].Quality = Items[i].Quality - Items[i].Quality;
        //            }
        //        }
        //        else
        //        {
        //            if (Items[i].Quality < 50)
        //            {
        //                Items[i].Quality = Items[i].Quality + 1;
        //            }
        //        }
        //    }
        //}
        #endregion

        // Loop through all item in stock.
        foreach (var item in Items)
        {
            //Apply the matching rule to each item.
            var rule = ItemRuleSelector.Select(item);

            //Update each item's quality and sellIn values based on the selected rule.
            rule.Update(item);
        }
    }
}