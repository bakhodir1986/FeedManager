using FeedManager.Task1.FeedValidators;
using FeedManager.Task2.Database;
using FeedManager.Task2.Feeds;
using FeedManager.Task2.Matchers;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeedManager.Task2.Importers
{
    public class Importer<T> where T : TradeFeed
    {
        private readonly IFeedValidator<T> feedValidator;
        private readonly IFeedMatcher<T> feedMatcher;
        private readonly IDatabaseRepository database;

        public Importer(IDatabaseRepository repository , IFeedValidator<T> validator, IFeedMatcher<T> matcher)
        {
            feedValidator = validator;
            database = repository;
            feedMatcher = matcher;
        }

        public void Import(IEnumerable<T> feeds)
        {
            foreach (var feed in feeds)
            {
                var resultOfValidation = feedValidator.Validate(feed);

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
                            if (!feedMatcher.Match(feed, repoFeed))
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
    }
}
