using FeedManager.Task1.FeedImporters;
using FeedManager.Task2.Database;
using FeedManager.Task2.Feeds;
using FeedManager.Task2.Matchers;
using FeedManager.Task3.Factory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FeedManager.Task2.Importers
{
    public class EmFeedImporter
    {
        private readonly Importer<EmFeed> importerHelper;
        private ValidatorsAndMatchersFactory<EmFeed> validatorsAndMatchers;

        public EmFeedImporter(IDatabaseRepository database)
        {
            validatorsAndMatchers = new EmFeedVMFactory<EmFeed>();
            importerHelper = new Importer<EmFeed>(database
                , validatorsAndMatchers.CreateValidator()
                , validatorsAndMatchers.CreateMatcher());
        }

        public void Import(IEnumerable<EmFeed> feeds)
        {
            importerHelper.Import(feeds);
        }
    }
}
