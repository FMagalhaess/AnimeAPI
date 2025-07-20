using MediatR;

namespace AnimeAPI.Application.Animes.Commands.DeleteAnime;

public record DeleteAnimeCommand(Guid id) : IRequest<bool>;