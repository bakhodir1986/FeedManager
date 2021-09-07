using FeedManager.Task1.FeedValidators;
using FeedManager.Task2.Feeds;
using FeedManager.Task2.Matchers;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeedManager.Task3.Factory
{
    public abstract class ValidatorsAndMatchersFactory<T> where T : TradeFeed
    {
        public abstract IFeedValidator<T> CreateValidator();

        public abstract IFeedMatcher<T> CreateMatcher(); 
    }
}
