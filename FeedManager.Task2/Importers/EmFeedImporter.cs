using FeedManager.Task1.FeedImporters;
using FeedManager.Task1.FeedValidators;
using FeedManager.Task2.Database;
using FeedManager.Task2.Feeds;
using FeedManager.Task2.Matchers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FeedManager.Task2.Importers
{
    public class EmFeedImporter: Importer<EmFeed>
    {
        private readonly IDatabaseRepository databaseRepository;
        private readonly IFeedValidator<EmFeed> feedValidator;
        private readonly IFeedMatcher<EmFeed> feedMatcher;

        public EmFeedImporter(IDatabaseRepository database)
        {
            databaseRepository = database;
            feedValidator = new EmFeedValidator();
            feedMatcher = new EmFeedMatcher();
        }

        public override List<EmFeed> LoadFeeds()
        {
            return databaseRepository.LoadFeeds<EmFeed>();
        }

        public override bool Match(EmFeed current, EmFeed other)
        {
            return feedMatcher.Match(current, other);
        }

        public override void SaveErrors(int feedStagingId, List<string> errors)
        {
            databaseRepository.SaveErrors(feedStagingId, errors);
        }

        public override void SaveFeed(EmFeed feed)
        {
            databaseRepository.SaveFeed(feed);
        }

        public override ValidateResult Validate(EmFeed feed)
        {
            return feedValidator.Validate(feed);
        }
    }
}
