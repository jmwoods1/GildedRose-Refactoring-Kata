using System.Collections.Generic;

namespace GildedRoseKata;

public class NormalItemStrategy
{
    public NormalItemStrategy()
    {
    }

    public void UpdateNormalItem(Item item)
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
    public AgedBrieStrategy()
    {
    }

    public void UpdateAgedBrie(Item item)
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
    public BackstagePassesStrategy()
    {
    }

    public void UpdateBackstagePasses(Item item)
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

public class GildedRose
{
    IList<Item> Items;
    private readonly NormalItemStrategy _normalItemStrategy;
    private readonly AgedBrieStrategy _agedBrieStrategy;
    private readonly BackstagePassesStrategy _backstagePassesStrategy;

    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
        _normalItemStrategy = new NormalItemStrategy();
        _agedBrieStrategy = new AgedBrieStrategy();
        _backstagePassesStrategy = new BackstagePassesStrategy();
    }

    public void UpdateQuality()
    {
        foreach (var item in Items)
        {
            if (item.Name == "Sulfuras, Hand of Ragnaros")
            {
                UpdateSulfuras();
            }
            else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                _backstagePassesStrategy.UpdateBackstagePasses(item);
            }
            else if (item.Name == "Aged Brie")
            {
                _agedBrieStrategy.UpdateAgedBrie(item);
            }
            else
            {
                _normalItemStrategy.UpdateNormalItem(item);
            }
        }
    }

    private void UpdateSulfuras()
    {
    }
}