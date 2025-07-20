using AnimeAPI.Application.Animes.DTOs;
using AnimeAPI.Domain.Shared.Repositories;
using MediatR;

namespace AnimeAPI.Application.Animes.Queries.GetAnimeByDirectorOrName;

public class GetAnimeByDirectorOrNameQueryHandler(IAnimeRepository animeRepository) : IRequestHandler<GetAnimeByDirectorOrNameQuery, IEnumerable<AnimeDto>>
{
    public async Task<IEnumerable<AnimeDto>> Handle(GetAnimeByDirectorOrNameQuery request, CancellationToken cancellationToken)
    {
        var animes = await animeRepository.GetByDirectorOrNameAsync(request.director, request.name);
        
        return animes.Select(anime => new AnimeDto
        {
            Id = anime.Id,
            NameTittle = anime.Name.Tittle,
            DirectorName = anime.Director.DirectorName,
            SummaryText = anime.Summary.SummaryText
        });
    }
}