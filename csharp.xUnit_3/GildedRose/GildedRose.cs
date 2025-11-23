using System.Collections.Generic;

namespace GildedRoseKata;

public interface IItemStrategy
{
    void Update(Item item);
}

public class NormalItemStrategy :  IItemStrategy
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

public class AgedBrieStrategy :  IItemStrategy
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

public class BackstagePassesStrategy :  IItemStrategy
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

public class SulfurasStrategy : IItemStrategy
{
    public void Update(Item item)
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
            var strategy = StrategyFactory(item);
            strategy.Update(item);
        }
    }

    private IItemStrategy StrategyFactory(Item item)
    {
        IItemStrategy strategy;
        if (item.Name == "Sulfuras, Hand of Ragnaros")
        {
            strategy = new SulfurasStrategy();
        }
        else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
        {
            strategy = new BackstagePassesStrategy();
        }
        else if (item.Name == "Aged Brie")
        {
            strategy = new AgedBrieStrategy();
        }
        else
        {
            strategy = new NormalItemStrategy();
        }

        return strategy;
    }
}

