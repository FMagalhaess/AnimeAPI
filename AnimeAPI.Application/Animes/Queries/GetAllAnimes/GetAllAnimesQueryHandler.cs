using AnimeAPI.Application.DTOs;
using AnimeAPI.Domain.Shared;
using AnimeAPI.Domain.Shared.Repositories;
using MediatR;

namespace AnimeAPI.Application.Animes.Queries.GetAllAnimes;

public class GetAllAnimesQueryHandler(IAnimeRepository animeRepository)
    : IRequestHandler<GetAllAnimesQuery, PaginatedList<AnimeDto>>
{
    public async Task<PaginatedList<AnimeDto>> Handle(
        GetAllAnimesQuery request,
        CancellationToken cancellationToken = default)
    {
        var paginatedAnimes = await animeRepository.GetAllAsync(request.PageNumber, request.PageSize);
        var animeDtos = paginatedAnimes.Select(anime => new AnimeDto
        {
            Id = anime.Id,
            NameTittle = anime.Name.Tittle,
            DirectorName = anime.Director.DirectorName,
            SummaryText = anime.Summary.SummaryText,
        }).ToList();
        
        return new PaginatedList<AnimeDto>(animeDtos,
            paginatedAnimes.TotalCount,
            paginatedAnimes.PageNumber,
            paginatedAnimes.PageSize);
    }
}