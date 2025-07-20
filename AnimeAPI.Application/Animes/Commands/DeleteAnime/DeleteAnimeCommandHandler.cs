using AnimeAPI.Domain.Shared.Repositories;
using MediatR;

namespace AnimeAPI.Application.Animes.Commands.DeleteAnime;

public class DeleteAnimeCommandHandler(IAnimeRepository animeRepository) : IRequestHandler<DeleteAnimeCommand, bool>
{
    public async Task<bool> Handle(DeleteAnimeCommand request, CancellationToken cancellationToken)
    {
        var animeExists = await animeRepository.GetByIdAsync(request.id);
        if (animeExists == null)
            return false;

        await animeRepository.DeleteAsync(request.id);
        
        return true;
    }
}