using AnimeAPI.Domain.Entities;

namespace AnimeAPI.Domain.Tests.Entities;

public class AnimeTest
{
    #region Constants

    private const string ValidTitle = "Attack on Titan";
    private const string ValidSummary = "A story about humanity's struggle against giant humanoid creatures.";
    private const string ValidDirector = "Hajime Isayama";

    #endregion
    
    [Fact]
    public void ShouldCreateAnime()
    {
        var anime = Anime.Create(ValidTitle, ValidDirector, ValidSummary);
        Assert.Equal(ValidTitle, anime.Name);
        Assert.Equal(ValidSummary, anime.Summary);
        Assert.Equal(ValidDirector, anime.Director);
    }
    
}