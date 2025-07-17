using AnimeAPI.Domain.ValueObjects;
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
        Name = Name.Create(name);
        Director = Director.Create(director);
        Summary = Summary.Create(summary);
    }
    
    private Anime(
        Name name,
        Director director,
        Summary summary) : base(Guid.CreateVersion7())
    {
        Name = name;
        Director = director;
        Summary = summary;
    }

    #endregion

    #region Properties

    public Name Name { get; }
    public Director Director { get; }
    public Summary Summary { get; }

    #endregion

    #region Factories

    public static Anime Create(Name name, Director director, Summary summary)
    {
        return new Anime(name, director, summary);
    }

    public static Anime Create(string name, string director, string summary)
    {
        return new Anime(name, director, summary);
    }
    
    #endregion
}