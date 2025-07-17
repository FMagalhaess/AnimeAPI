using AnimeAPI.Domain.Shared.Exceptions;

namespace AnimeAPI.Domain.ValueObjects.Exceptions.SummaryExceptions;

public class NullSummaryException(string message) : DomainException(message);