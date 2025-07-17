using AnimeAPI.Domain.Shared.Exceptions;

namespace AnimeAPI.Domain.ValueObjects.Exceptions.NameExceptions;

public class NullNameException(string message) : DomainException(message);