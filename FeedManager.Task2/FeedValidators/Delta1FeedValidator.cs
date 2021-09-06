﻿using FeedManager.Task1.FeedValidators;
using FeedManager.Task2.Feeds;

namespace FeedManager.Task1.FeedImporters
{
    public class Delta1FeedValidator : BaseValidator, IFeedValidator<Delta1Feed>
    {
        public ValidateResult Validate(Delta1Feed feed)
        {
            var result = base.Validate(feed);

            if (feed.Isin.Length != 12)
            {
                result.Errors.Add(ErrorCode.NotValidIsin);
            }

            var firstTwoChars = feed.Isin.Substring(0, 2);

            foreach (var ch in firstTwoChars)
            {
                if (!char.IsLetter(ch) || !char.IsUpper(ch))
                {
                    result.Errors.Add(ErrorCode.NotValidIsin);
                    break;
                }
            }

            var lastDigitChars = feed.Isin.Substring(2, feed.Isin.Length - 2);

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

            if (feed.MaturityDate < feed.ValuationDate)
            {
                result.Errors.Add(ErrorCode.NotValidIsin);
            }

            if (result.Errors.Count == 0)
            {
                result.IsValid = true;
            }

            return result;
        }
    }
}
