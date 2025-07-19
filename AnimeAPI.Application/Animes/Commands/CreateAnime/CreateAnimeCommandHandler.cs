using AnimeAPI.Domain.Entities;
using AnimeAPI.Domain.Shared.Repositories;
using AnimeAPI.Domain.ValueObjects;
using MediatR;

namespace AnimeAPI.Application.Animes.Commands.CreateAnime;

public class CreateAnimeCommandHandler(IAnimeRepository repository) : IRequestHandler<CreateAnimeCommand, Guid>
{
    public async Task<Guid> Handle(CreateAnimeCommand request, CancellationToken cancellationToken)
    {
        var name = Name.Create(request.NameTittle);
        var director = Director.Create(request.DirectorName);
        var summary = Summary.Create(request.SummaryText);
        
        var anime = Anime.Create(name, director, summary);
        
        await repository.AddAsync(anime);
        
        return anime.Id;
    }
}