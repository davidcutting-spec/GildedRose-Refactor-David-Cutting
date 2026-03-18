using System;
using System.Collections.Generic;

namespace GildedRoseKata;

/// <summary>
/// Console runner used to show how items change over a number of days.
/// Output format and behaviour match the original code.
/// </summary>
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("OMGHAI!");

        // Sample inventory used for the demonstration run.
        IList<Item> items = new List<Item>
        {
            new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
            new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
            new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
            new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
            new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
            new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20},
            new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 49},
            new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 49},
            new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}};


        // Create the app instance that will apply the daily update rules.
        // Pass in List of items in inventory to be updated.
        var app = new GildedRose(items);

        // Default number of iterations for the demo output.
        // The original code prints the initial state (day 0) and one updated day,
        // so the loop runs twice by default.
        int days = 2;

        // Allow a custom number of days to be passed in from the command line.
        if (args.Length > 0)
        {
            days = int.Parse(args[0]) + 1;
        }

        // Simulate each day: Write to Console the current state, then apply the daily update.
        for (var i = 0; i < days; i++)
        {
            Console.WriteLine("-------- day " + i + " --------");
            Console.WriteLine("name, sellIn, quality");
            for (var j = 0; j < items.Count; j++)
            {
                Console.WriteLine(items[j].Name + ", " + items[j].SellIn + ", " + items[j].Quality);
            }
            Console.WriteLine("");
            app.UpdateQuality();
        }
    }
}