using MediatR;

namespace AnimeAPI.Application.Animes.Commands.CreateAnime;

public record CreateAnimeCommand : IRequest<Guid>
{
    public string NameTittle { get; init; }
    public string DirectorName { get; init; }
    public string SummaryText { get; init; }
}