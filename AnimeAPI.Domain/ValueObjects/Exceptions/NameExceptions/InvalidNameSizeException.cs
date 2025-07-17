using AnimeAPI.Domain.Shared.Exceptions;

namespace AnimeAPI.Domain.ValueObjects.Exceptions.NameExceptions;

public class InvalidNameSizeException(string message) : DomainException(message);