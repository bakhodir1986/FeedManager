using FeedManager.Task1.FeedImporters;
using FeedManager.Task1.FeedValidators;
using FeedManager.Task2.Feeds;
using FeedManager.Task2.Matchers;


namespace FeedManager.Task3.Factory
{
    public class EmFeedVMFactory<T> : ValidatorsAndMatchersFactory<EmFeed>
    {
        public override IFeedMatcher<EmFeed> CreateMatcher()
        {
            return new EmFeedMatcher();
        }

        public override IFeedValidator<EmFeed> CreateValidator()
        {
            return new EmFeedValidator();
        }
    }
}
