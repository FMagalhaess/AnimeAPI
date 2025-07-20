using AnimeAPI.Domain.ValueObjects;
using AnimeAPI.Domain.ValueObjects.Exceptions.NameExceptions;

namespace AnimeAPI.Domain.Tests.ValueObjects;

public class NameTest
{
    #region Constants

    private const string ValidName = "Naruto";

    private const string NameLong = "ipsum dolor sit amet Lorem ipsum dolor sit amet, consectetur adipiscing elit, ipsum dolor sit amet sed do eiusmod";

    #endregion
    
    [Theory]
    [InlineData(ValidName)]
    public void ShouldCreateAName(string nameText)
    {
        var name = Name.Create(ValidName);
        Assert.Equal(nameText, name.Tittle);
    }
    
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void ShouldFailToCreateNameIfEmptyOrWhiteSpaces(string nameText)
    {
        Assert.Throws<NullNameException>(() => Name.Create(nameText));
    }
    
    [Theory]
    [InlineData("X")]
    [InlineData(NameLong)]
    public void ShouldFailToCreateNameIfSizeIsIncorrect(string nameText)
    {
        Assert.Throws<InvalidNameSizeException>(() => Name.Create(nameText));
    }
}
