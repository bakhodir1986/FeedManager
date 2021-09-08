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
        private readonly IDatabaseRepository database;
        protected Importer(IDatabaseRepository databaseRepository)
        {
            database = databaseRepository;
        }

        public void Import(IEnumerable<T> feeds)
        {
            foreach (var feed in feeds)
            {
                var resultOfValidation = Validate(feed);

                if (resultOfValidation.IsValid)
                {
                    var listOfEmFeeds = database.LoadFeeds<T>();

                    if (listOfEmFeeds.Count == 0)
                    {
                        database.SaveFeed(feed);
                    }
                    else
                    {
                        foreach (var repoFeed in listOfEmFeeds)
                        {
                            if (!Match(feed, repoFeed))
                            {
                                database.SaveFeed(feed);
                            }
                        }
                    }
                }
                else
                {
                    database.SaveErrors(feed.StagingId, resultOfValidation.Errors);
                }
            }
        }

        protected abstract ValidateResult Validate(T feed);

        protected abstract bool Match(T current, T other);
    }
}
