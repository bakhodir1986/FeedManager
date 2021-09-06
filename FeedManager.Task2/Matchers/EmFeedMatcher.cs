using FeedManager.Task2.Feeds;
using System;

namespace FeedManager.Task2.Matchers
{
    public class EmFeedMatcher : IFeedMatcher<EmFeed>
    {
        public bool Match(EmFeed current, EmFeed other)
        {
            if (current.SourceAccountId > 0
                && other.SourceAccountId > 0
                && current.SourceAccountId == other.SourceAccountId)
            {
                return true;
            }
            else if (current.StagingId == other.StagingId)
            {
                return true;
            }

            return false;
        }
    }
}
