using FeedManager.Task1.FeedImporters;
using FeedManager.Task1.FeedValidators;
using FeedManager.Task2.Feeds;
using FeedManager.Task2.Matchers;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeedManager.Task3.Factory
{
    public class Delta1FeedVMFactory<T> : ValidatorsAndMatchersFactory<Delta1Feed>
    {
        public override IFeedMatcher<Delta1Feed> CreateMatcher()
        {
            return new Delta1FeedMatcher();
        }

        public override IFeedValidator<Delta1Feed> CreateValidator()
        {
            return new Delta1FeedValidator();
        }
    }
}
