using AnimeAPI.Domain.Entities;
using AnimeAPI.Domain.Shared.Repositories;
using MediatR;

namespace AnimeAPI.Application.Animes.Commands.UpdateAnime;

public class UpdateAnimeCommandHandler(IAnimeRepository animeRepository) : IRequestHandler<UpdateAnimeCommand, bool>
{
    public async Task<bool> Handle(UpdateAnimeCommand request, CancellationToken cancellationToken)
    {
        Anime? anime = await animeRepository.GetByIdAsync(request.Id);
        if (anime == null)
            return false;

        anime.UpdateName(request.NameTittle);
        anime.UpdateDirector(request.DirectorName);
        anime.UpdateSummary(request.SummaryText);
        
        await animeRepository.UpdateAsync(anime);
        
        return true;
    }
}