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
    private readonly NormalItemStrategy _normalItemStrategy;
    private readonly AgedBrieStrategy _agedBrieStrategy;
    private readonly BackstagePassesStrategy _backstagePassesStrategy;
    private readonly SulfurasStrategy _sulfurasStrategy;

    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
        _normalItemStrategy = new NormalItemStrategy();
        _agedBrieStrategy = new AgedBrieStrategy();
        _backstagePassesStrategy = new BackstagePassesStrategy();
        _sulfurasStrategy = new SulfurasStrategy();
    }

    public void UpdateQuality()
    {
        foreach (var item in Items)
        {
            if (item.Name == "Sulfuras, Hand of Ragnaros")
            {
                _sulfurasStrategy.Update();
            }
            else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                _backstagePassesStrategy.Update(item);
            }
            else if (item.Name == "Aged Brie")
            {
                _agedBrieStrategy.Update(item);
            }
            else
            {
                _normalItemStrategy.Update(item);
            }
        }
    }
}