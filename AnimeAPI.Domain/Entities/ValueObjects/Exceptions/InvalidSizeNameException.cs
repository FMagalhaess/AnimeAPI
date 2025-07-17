using AnimeAPI.Domain.Shared.Exceptions;

namespace AnimeAPI.Domain.Entities.ValueObjects.Exceptions;

public class InvalidSizeNameException(string message) : DomainException(message);