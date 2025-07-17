using AnimeAPI.Domain.ValueObjects;
using AnimeAPI.Domain.ValueObjects.Exceptions.SummaryExceptions;

namespace AnimeAPI.Domain.Tests.ValueObjects;

public class SummaryTest
{
    #region Constants

    private const string ValidSummary = "This is a valid summary for an anime.";
    
    private const string SummaryLongText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod " +
                                          "tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam," +
                                          " quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo" +
                                          " consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse" +
                                          " cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat" +
                                          "tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam," +
                                          " non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
    

    #endregion
    
    [Theory]
    [InlineData(ValidSummary)]
    public void ShouldCreateASummary(string summaryText)
    {
        var summary = Summary.Create(ValidSummary);
        Assert.Equal(summaryText, summary.SummaryText);
    }
    
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void ShouldFailToCreateSummaryIfEmptyOrWhiteSpaces(string summaryText)
    {
        Assert.Throws<NullSummaryException>(() => Summary.Create(summaryText));
    }
    
    [Theory]
    [InlineData("Short")]
    [InlineData("bit")]
    [InlineData("Too short")]
    [InlineData(SummaryLongText)]
    public void ShouldFailToCreateSummaryIfSizeIsIncorrect(string summaryText)
    {
        Assert.Throws<InvalidSummarySizeException>(() => Summary.Create(summaryText));
    }
}
