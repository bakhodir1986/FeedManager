using FeedManager.Task1.FeedImporters;
using FeedManager.Task1.FeedValidators;
using FeedManager.Task2.Database;
using FeedManager.Task2.Feeds;
using FeedManager.Task2.Matchers;
using System;
using System.Collections.Generic;

namespace FeedManager.Task2.Importers
{
    public class Delta1FeedImporter : Importer<Delta1Feed>
    {
        private readonly IDatabaseRepository databaseRepository;
        private readonly IFeedValidator<Delta1Feed> feedValidator;
        private readonly IFeedMatcher<Delta1Feed> feedMatcher;


        public Delta1FeedImporter(IDatabaseRepository database) : base(database)
        {
            feedValidator = new Delta1FeedValidator();
            feedMatcher = new Delta1FeedMatcher();
        }

        protected override bool Match(Delta1Feed current, Delta1Feed other)
        {
            return feedMatcher.Match(current, other);
        }

        protected override ValidateResult Validate(Delta1Feed feed)
        {
            return feedValidator.Validate(feed);
        }
    }
}