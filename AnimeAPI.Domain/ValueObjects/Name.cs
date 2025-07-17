using AnimeAPI.Domain.Shared.ValueObjects;
using AnimeAPI.Domain.ValueObjects.Exceptions.NameExceptions;

namespace AnimeAPI.Domain.ValueObjects;

public sealed record Name : ValueObject
{
    #region Constants

    public const int MaxLength = 100;
    public const int MinLength = 2;

    #endregion

    #region Constructors

    private Name(string tittle)
    {
        Tittle = tittle;
    }

    #endregion

    #region Properties

    public string Tittle { get; }

    #endregion

    #region Factories

    public static Name Create(string tittle)
    {
        if (string.IsNullOrWhiteSpace(tittle))
            throw new NullNameException("Name cannot be null or empty.");
        if (tittle.Length is < MinLength or > MaxLength)
            throw new InvalidNameSizeException($"Name must be between {MinLength} and {MaxLength} characters long.");
        return new Name(tittle);
    }

    #endregion
    
    #region implicit operators
    
    public static implicit operator string(Name name) => name.ToString();
    
    public static implicit operator Name(string nome) => Create(nome);
    
    #endregion
    
    #region Overrides
    
    public override string ToString() => Tittle;
    
    #endregion
}