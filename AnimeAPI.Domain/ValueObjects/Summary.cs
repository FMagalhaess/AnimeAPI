using AnimeAPI.Domain.ValueObjects.Exceptions.SummaryExceptions;

namespace AnimeAPI.Domain.ValueObjects;

public sealed record Summary
{
    #region Constants

    public const int MaxLength = 500;
    public const int MinLength = 10;

    #endregion

    #region Constructors

    private Summary(string summaryText)
    {
        SummaryText = summaryText;
    }

    #endregion

    #region Properties

    public string SummaryText { get; }

    #endregion

    #region Factories

    public static Summary Create(string summary)
    {
        if (string.IsNullOrWhiteSpace(summary))
            throw new NullSummaryException("Summary cannot be null or empty.");
        if (summary.Length is < MinLength or > MaxLength)
            throw new InvalidSummarySizeException($"Summary must be between {MinLength} and {MaxLength} characters long.");
        return new Summary(summary);
    }

    #endregion
    
    #region Implicit Operators
    
    public static implicit operator string(Summary summary) => summary.ToString();
    public static implicit operator Summary(string summary) => Create(summary);
    
    #endregion
    
    #region Overrides
    
    public override string ToString() => SummaryText;
    
    #endregion
}