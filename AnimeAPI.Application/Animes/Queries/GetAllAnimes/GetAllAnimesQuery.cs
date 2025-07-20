using AnimeAPI.Application.Animes.DTOs;
using AnimeAPI.Domain.Shared;
using MediatR;

namespace AnimeAPI.Application.Animes.Queries.GetAllAnimes;

public record GetAllAnimesQuery : IRequest<PaginatedList<AnimeDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
    public string? SearchTerm { get; init; }
    public string? SortBy { get; init; }
    public bool SortDescending { get; init; } = false;
}