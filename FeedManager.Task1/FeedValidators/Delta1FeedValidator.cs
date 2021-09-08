using FeedManager.Task1.Feeds;
using FeedManager.Task1.FeedValidators;

namespace FeedManager.Task1.FeedImporters
{
    public class Delta1FeedValidator : BaseValidator, IFeedValidator<Delta1Feed>
    {
        public override ValidateResult Validate(TradeFeed feed)
        {
            var result = base.Validate(feed);

            if (feed is Delta1Feed)
            {
                if ((feed as Delta1Feed).Isin.Length != 12)
                {
                    result.Errors.Add(ErrorCode.NotValidIsin);
                }

                var firstTwoChars = (feed as Delta1Feed).Isin.Substring(0, 2);

                foreach (var ch in firstTwoChars)
                {
                    if (!char.IsLetter(ch) || !char.IsUpper(ch))
                    {
                        result.Errors.Add(ErrorCode.NotValidIsin);
                        break;
                    }
                }

                var lastDigitChars = (feed as Delta1Feed).Isin.Substring(2, (feed as Delta1Feed).Isin.Length - 2);

                if (lastDigitChars.Length != 10)
                {
                    result.Errors.Add(ErrorCode.NotValidIsin);
                }

                foreach (var ch in lastDigitChars)
                {
                    if (!char.IsDigit(ch))
                    {
                        result.Errors.Add(ErrorCode.NotValidIsin);
                        break;
                    }
                }

                if ((feed as Delta1Feed).MaturityDate < feed.ValuationDate)
                {
                    result.Errors.Add(ErrorCode.NotValidIsin);
                }

                if (result.Errors.Count == 0)
                {
                    result.IsValid = true;
                }

                return result;
            }

            return result;
        }

        public ValidateResult Validate(Delta1Feed feed)
        {
            return Validate(feed as TradeFeed);
        }
    }
}
