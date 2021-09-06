using FeedManager.Task1.FeedImporters;
using FeedManager.Task2.Database;
using FeedManager.Task2.Feeds;
using FeedManager.Task2.Matchers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FeedManager.Task2.Importers
{
    public class EmFeedImporter
    {
        private readonly Importer<EmFeed> importerHelper;

        public EmFeedImporter(IDatabaseRepository database)
        {
            importerHelper = new Importer<EmFeed>(database, new EmFeedValidator(), new EmFeedMatcher());
        }

        public void Import(IEnumerable<EmFeed> feeds)
        {
            importerHelper.Import(feeds);
        }
    }
}
