using AnimeAPI.Domain.Shared.Entities;

namespace AnimeAPI.Domain.Entities;

public sealed class Anime : Entity
{
    #region Constructors

    private Anime(
        string name,
        string director,
        string summary) : base(Guid.CreateVersion7())
    {
        Name = name;
        Director = director;
        Summary = summary;
    }

    #endregion

    #region Properties

    public string Name { get; }
    public string Director { get; }
    public string Summary { get; }

    #endregion

    #region Factories

    public static Anime Create(string name, string director, string summary)
    {
        return new Anime(name, director, summary);
    }

    #endregion
}