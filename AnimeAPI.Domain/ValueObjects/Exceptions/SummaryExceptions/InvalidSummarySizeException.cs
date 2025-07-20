using AnimeAPI.Domain.Shared.Exceptions;

namespace AnimeAPI.Domain.ValueObjects.Exceptions.SummaryExceptions;

public class InvalidSummarySizeException(string message) : DomainException(message);
