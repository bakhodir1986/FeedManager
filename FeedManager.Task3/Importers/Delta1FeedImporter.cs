using FeedManager.Task1.FeedImporters;
using FeedManager.Task2.Database;
using FeedManager.Task2.Feeds;
using FeedManager.Task2.Matchers;
using FeedManager.Task3.Factory;
using System;
using System.Collections.Generic;

namespace FeedManager.Task2.Importers
{
    public class Delta1FeedImporter
    {
        private readonly Importer<Delta1Feed> importerHelper;
        private ValidatorsAndMatchersFactory<Delta1Feed> validatorsAndMatchers;

        public Delta1FeedImporter(IDatabaseRepository database)
        {
            validatorsAndMatchers = new Delta1FeedVMFactory<Delta1Feed>();
            importerHelper = new Importer<Delta1Feed>(database
                , validatorsAndMatchers.CreateValidator()
                , validatorsAndMatchers.CreateMatcher());
        }

        public void Import(IEnumerable<Delta1Feed> feeds)
        {
            importerHelper.Import(feeds);
        }
    }
}