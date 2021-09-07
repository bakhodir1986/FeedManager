namespace FeedManager.Task1.FeedValidators
{
    public class ErrorCode
    {
        public static string IdIsNotValidMessage { get; } = "Identifier should be bigger than 1";

        public static string InvalidCounterpartyId { get; } = "CounterpartyId must be valid non-negative identifiers >= 1";

        public static string InvalidPrincipalId { get; } = "PrincipalId must be valid non-negative identifiers >= 1";

        public static string InvalidSourceAccountId { get; } = "SourceAccountId must be valid non-negative identifiers >= 1";

        public static string InvalidStagingId { get; } = "StagingId must be valid non-negative identifiers >= 1";

        public static string PriceIsNotValid { get; } = "Should be positive and 2 digits after decimal point";

        public static string NotValidIsin { get; } = "Should be valid Isin";

        public static string InvalidSedol { get; } = "Sedol should be valid decimal bigger than 0 and less than 100";

        public static string InvalidAssetValue { get; } = "AssetValue should be valid decimal bigger than 0 and less than Sedol.";

        public static string PropertyRangeError(string name, decimal minVal, decimal maxVal)
        {
            return $"{name} should be between {minVal} and {maxVal}";
        }
    }
}
