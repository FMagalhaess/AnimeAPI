using AnimeAPI.Domain.ValueObjects.Exceptions.DirectorExceptions;
using AnimeAPI.Domain.Shared.ValueObjects;

namespace AnimeAPI.Domain.ValueObjects;

public sealed record Director : ValueObject
{
    #region Constants

    public const int MaxLength = 100;
    public const int MinLength = 2;

    #endregion
    
    #region Constructors

    private Director(string director)
    {
        DirectorName = director;
    }

    #endregion

    #region Properties

    public string DirectorName { get; }

    #endregion

    #region Factories

    public static Director Create(string director)
    {
        if (string.IsNullOrWhiteSpace(director))
            throw new NullDirectorException("Director name cannot be null or empty.");
        if (director.Length is < MinLength or > MaxLength)
            throw new InvalidDirectorSizeException($"Director name must be between {MinLength} and {MaxLength} characters long.");
        return new Director(director);
    }

    #endregion

    #region Implicit Operators

    public static implicit operator string(Director director) => director.ToString();
    public static implicit operator Director(string director) => Create(director);

    #endregion
}