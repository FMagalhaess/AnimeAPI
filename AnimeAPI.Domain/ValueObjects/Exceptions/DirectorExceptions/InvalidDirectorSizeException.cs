using AnimeAPI.Domain.Shared.Exceptions;

namespace AnimeAPI.Domain.ValueObjects.Exceptions.DirectorExceptions;

public class InvalidDirectorSizeException(string message) : DomainException(message);
