using AnimeAPI.Domain.ValueObjects;
using AnimeAPI.Domain.Shared.Entities;

namespace AnimeAPI.Domain.Entities;

public sealed class Anime : Entity
{
    #region Constructors

    public Anime() : base(Guid.CreateVersion7())
    {
        
    }
    
    private Anime(
        string name,
        string director,
        string summary) : base(Guid.CreateVersion7())
    {
        Name = ValueObjects.Name.Create(name);
        Director = ValueObjects.Director.Create(director);
        Summary = ValueObjects.Summary.Create(summary);
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

    public Name Name { get; private set; } = null!;
    public Director Director { get; private set; } = null!;
    public Summary Summary { get; private set; } = null!;

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
    
    public void UpdateName(Name name)
    {
        Name = name;
    }
    public void UpdateName(string name)
    {
        Name = ValueObjects.Name.Create(name);
    }
    public void UpdateDirector(Director director)
    {
        Director = director;
    }
    public void UpdateDirector(string director)
    {
        Director = ValueObjects.Director.Create(director);
    }
    public void UpdateSummary(Summary summary)
    {
        Summary = summary;
    }
    public void UpdateSummary(string summary)
    {
        Summary = ValueObjects.Summary.Create(summary);
    }
    
    #endregion
}