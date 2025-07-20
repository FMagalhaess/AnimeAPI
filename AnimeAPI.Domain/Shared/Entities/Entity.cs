namespace AnimeAPI.Domain.Shared.Entities;

public abstract class Entity(Guid id)
{
    #region Properties

    public Guid Id { get; } = id;

    #endregion
}