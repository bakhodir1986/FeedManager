using FeedManager.Task1.Feeds;
using FeedManager.Task1.FeedValidators;

namespace FeedManager.Task1.FeedImporters
{
    public class EmFeedValidator : BaseValidator, IFeedValidator<EmFeed>
    {
        public override ValidateResult Validate(TradeFeed feed)
        {
            var result = base.Validate(feed);

            if (feed is EmFeed)
            {
                if ((feed as EmFeed).Sedol < 0 || (feed as EmFeed).Sedol > 100)
                {
                    result.Errors.Add(ErrorCode.InvalidSedol);
                }

                if ((feed as EmFeed).AssetValue < 0 || (feed as EmFeed).Sedol < (feed as EmFeed).AssetValue)
                {
                    result.Errors.Add(ErrorCode.InvalidAssetValue);
                }

                if (result.Errors.Count == 0)
                {
                    result.IsValid = true;
                }
            }

            return result;
        }

        public ValidateResult Validate(EmFeed feed)
        {
            return Validate(feed as TradeFeed);
        }
    }
}
