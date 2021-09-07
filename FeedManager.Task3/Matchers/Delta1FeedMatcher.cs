using FeedManager.Task2.Feeds;
using System;

namespace FeedManager.Task2.Matchers
{
    public class Delta1FeedMatcher : IFeedMatcher<Delta1Feed>
    {
        public bool Match(Delta1Feed current, Delta1Feed other)
        {
            if (current.CounterpartyId == other.CounterpartyId &&
                current.PrincipalId == other.PrincipalId)
            {
                return true;
            }

            return false;
        }
    }
}
