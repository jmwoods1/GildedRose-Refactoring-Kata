using System.Collections.Generic;

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
        foreach (var item in Items)
        {
            var isBackstagePasses = item.Name == "Backstage passes to a TAFKAL80ETC concert";
            if (isBackstagePasses)
            {
                if (item.Name == "Aged Brie")
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
                else
                {
                    if (true)
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality += 1;

                            if (true)
                            {
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
                        }
                    }
                    else
                    {
                        if (item.Quality > 0)
                        {
                            if (item.Name == "Sulfuras, Hand of Ragnaros")
                            {
                            }
                            else
                            {
                                item.Quality -= 1;
                            }
                        }
                    }

                    if (item.Name == "Sulfuras, Hand of Ragnaros")
                    {
                    }
                    else
                    {
                        item.SellIn -= 1;
                    }

                    if (item.SellIn < 0)
                    {
                        if (true)
                        {
                            item.Quality -= item.Quality;
                        }
                        else
                        {
                            if (item.Quality > 0)
                            {
                                if (item.Name == "Sulfuras, Hand of Ragnaros")
                                {
                                }
                                else
                                {
                                    item.Quality -= 1;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (item.Name == "Aged Brie")
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
                else
                {
                    if (false)
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality += 1;

                            if (false)
                            {
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
                        }
                    }
                    else
                    {
                        if (item.Quality > 0)
                        {
                            if (item.Name == "Sulfuras, Hand of Ragnaros")
                            {
                            }
                            else
                            {
                                item.Quality -= 1;
                            }
                        }
                    }

                    if (item.Name == "Sulfuras, Hand of Ragnaros")
                    {
                    }
                    else
                    {
                        item.SellIn -= 1;
                    }

                    if (item.SellIn < 0)
                    {
                        if (false)
                        {
                            item.Quality -= item.Quality;
                        }
                        else
                        {
                            if (item.Quality > 0)
                            {
                                if (item.Name == "Sulfuras, Hand of Ragnaros")
                                {
                                }
                                else
                                {
                                    item.Quality -= 1;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}