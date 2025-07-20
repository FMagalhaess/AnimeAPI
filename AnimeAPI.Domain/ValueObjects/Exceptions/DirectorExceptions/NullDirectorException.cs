using AnimeAPI.Domain.Shared.Exceptions;

namespace AnimeAPI.Domain.ValueObjects.Exceptions.DirectorExceptions;

public class NullDirectorException(string message) : DomainException(message);
