using FeedManager.Task1.FeedImporters;
using FeedManager.Task2.Database;
using FeedManager.Task2.Feeds;
using FeedManager.Task2.Matchers;
using System;
using System.Collections.Generic;

namespace FeedManager.Task2.Importers
{
    public class Delta1FeedImporter
    {
        private readonly Importer<Delta1Feed> importerHelper;

        public Delta1FeedImporter(IDatabaseRepository database)
        {
            importerHelper = new Importer<Delta1Feed>(database, new Delta1FeedValidator(), new Delta1FeedMatcher());
        }

        public void Import(IEnumerable<Delta1Feed> feeds)
        {
            importerHelper.Import(feeds);
        }
    }
}