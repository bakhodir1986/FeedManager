using FeedManager.Task1.FeedImporters;
using FeedManager.Task1.FeedValidators;
using FeedManager.Task2.Database;
using FeedManager.Task2.Feeds;
using FeedManager.Task2.Matchers;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeedManager.Task2.Importers
{
    public abstract class Importer<T> where T : TradeFeed
    {
        public void Import(IEnumerable<T> feeds)
        {
            foreach (var feed in feeds)
            {
                var resultOfValidation = Validate(feed);

                if (resultOfValidation.IsValid)
                {
                    var listOfEmFeeds = LoadFeeds();

                    if (listOfEmFeeds.Count == 0)
                    {
                        SaveFeed(feed);
                    }
                    else
                    {
                        foreach (var repoFeed in listOfEmFeeds)
                        {
                            if (!Match(feed, repoFeed))
                            {
                                SaveFeed(feed);
                            }
                        }
                    }
                }
                else
                {
                    SaveErrors(feed.StagingId, resultOfValidation.Errors);
                }
            }
        }

        public abstract ValidateResult Validate(T feed);

        public abstract List<T> LoadFeeds();

        public abstract void SaveFeed(T feed);

        public abstract bool Match(T current, T other);

        public abstract void SaveErrors(int feedStagingId, List<String> errors);
    }
}
