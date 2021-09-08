using FeedManager.Task1.FeedImporters;
using FeedManager.Task2.Feeds;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeedManager.Task1.FeedValidators
{
    public class BaseValidator<T> : IFeedValidator<T>
        where T : TradeFeed
    {
        public virtual ValidateResult Validate(T feed)
        {
            var result = new ValidateResult
            {
                IsValid = false
            };

            if (feed.CounterpartyId < 1)
            {
                result.Errors.Add(ErrorCode.InvalidCounterpartyId);
            }

            if (feed.PrincipalId < 1)
            {
                result.Errors.Add(ErrorCode.InvalidPrincipalId);
            }

            if (feed.SourceAccountId < 1)
            {
                result.Errors.Add(ErrorCode.InvalidSourceAccountId);
            }

            if (feed.StagingId < 1)
            {
                result.Errors.Add(ErrorCode.InvalidStagingId);
            }

            if (feed.CurrentPrice < 0
                || feed.CurrentPrice * 1000 % 10 != 0)
            {
                result.Errors.Add(ErrorCode.PriceIsNotValid);
            }

            return result;
        }
    }
}
