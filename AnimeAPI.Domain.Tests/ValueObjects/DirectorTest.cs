using AnimeAPI.Domain.ValueObjects;
using AnimeAPI.Domain.ValueObjects.Exceptions.DirectorExceptions;

namespace AnimeAPI.Domain.Tests.ValueObjects;

public class DirectorTest
{
    #region Constants

    private const string ValidDirector = "Hayao Miyazaki";

    private const string DirectorLong = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";

    #endregion
    
    [Theory]
    [InlineData(ValidDirector)]
    public void ShouldCreateADirector(string directorText)
    {
        var director = Director.Create(ValidDirector);
        Assert.Equal(directorText, director.DirectorName);
    }
    
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void ShouldFailToCreateDirectorIfEmptyOrWhiteSpaces(string directorText)
    {
        Assert.Throws<NullDirectorException>(() => Director.Create(directorText));
    }
    
    [Theory]
    [InlineData("X")]
    [InlineData(DirectorLong)]
    public void ShouldFailToCreateDirectorIfSizeIsIncorrect(string directorText)
    {
        Assert.Throws<InvalidDirectorSizeException>(() => Director.Create(directorText));
    }
}