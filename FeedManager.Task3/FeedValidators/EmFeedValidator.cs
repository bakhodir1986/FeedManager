using FeedManager.Task2.Feeds;
using FeedManager.Task1.FeedValidators;

namespace FeedManager.Task1.FeedImporters
{
    public class EmFeedValidator :  BaseValidator<EmFeed>
    {
        public override ValidateResult Validate(EmFeed feed)
        {
            var result = base.Validate(feed);


                if (feed.Sedol < 0 || feed.Sedol > 100)
                {
                    result.Errors.Add(ErrorCode.InvalidSedol);
                }

                if (feed.AssetValue < 0 || feed.Sedol < feed.AssetValue)
                {
                    result.Errors.Add(ErrorCode.InvalidAssetValue);
                }

                if (result.Errors.Count == 0)
                {
                    result.IsValid = true;
                }


            return result;
        }

    }
}
