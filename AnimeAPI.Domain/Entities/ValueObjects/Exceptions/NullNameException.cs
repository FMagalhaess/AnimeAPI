using AnimeAPI.Domain.Shared.Exceptions;

namespace AnimeAPI.Domain.Entities.ValueObjects.Exceptions;

public class NullNameException(string message) : DomainException(message);