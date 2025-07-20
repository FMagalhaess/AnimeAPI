using AnimeAPI.Application.Animes.DTOs;
using AnimeAPI.Domain.Entities;
using AnimeAPI.Domain.Shared.Repositories;
using MediatR;

namespace AnimeAPI.Application.Animes.Queries.GetAnimeById;

public class GetAnimeByIdQueryHandler(IAnimeRepository animeRepository) : IRequestHandler<GetAnimeByIdQuery, AnimeDto>
{
    public async Task<AnimeDto> Handle(GetAnimeByIdQuery request, CancellationToken cancellationToken)
    {
        var anime = await animeRepository.GetByIdAsync(request.Id);

        if (anime == null)
            return null;

        return new AnimeDto
        {
            Id = request.Id,
            NameTittle = anime.Name,
            DirectorName = anime.Director,
            SummaryText = anime.Summary
        };
    }
}