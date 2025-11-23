using System.Collections.Generic;

namespace GildedRoseKata;

public class NormalItemStrategy
{
    public void Update(Item item)
    {
        if (item.Quality > 0)
        {
            item.Quality -= 1;
        }

        item.SellIn -= 1;

        if (item.SellIn < 0)
        {
            if (item.Quality > 0)
            {
                item.Quality -= 1;
            }
        }
    }
}

public class AgedBrieStrategy
{
    public void Update(Item item)
    {
        if (item.Quality < 50)
        {
            item.Quality += 1;
        }

        item.SellIn -= 1;

        if (item.SellIn < 0)
        {
            if (item.Quality < 50)
            {
                item.Quality += 1;
            }
        }
    }
}

public class BackstagePassesStrategy
{
    public void Update(Item item)
    {
        if (item.Quality < 50)
        {
            item.Quality += 1;

            if (item.SellIn < 11)
            {
                if (item.Quality < 50)
                {
                    item.Quality += 1;
                }
            }

            if (item.SellIn < 6)
            {
                if (item.Quality < 50)
                {
                    item.Quality += 1;
                }
            }
        }

        item.SellIn -= 1;

        if (item.SellIn < 0)
        {
            item.Quality -= item.Quality;
        }
    }
}

public class SulfurasStrategy
{
    public void Update()
    {
    }
}

public class GildedRose
{
    IList<Item> Items;

    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }

    public void UpdateQuality()
    {
        foreach (var item in Items)
        {
            if (item.Name == "Sulfuras, Hand of Ragnaros")
            {
                new SulfurasStrategy().Update();
            }
            else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                new BackstagePassesStrategy().Update(item);
            }
            else if (item.Name == "Aged Brie")
            {
                new AgedBrieStrategy().Update(item);
            }
            else
            {
                new NormalItemStrategy().Update(item);
            }
        }
    }
}