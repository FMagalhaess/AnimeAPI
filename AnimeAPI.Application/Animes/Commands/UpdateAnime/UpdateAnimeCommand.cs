using MediatR;

namespace AnimeAPI.Application.Animes.Commands.UpdateAnime;

public record UpdateAnimeCommand : IRequest<bool>
{
    public Guid Id { get; init; }
    public string NameTittle { get; init; }
    public string DirectorName { get; init; }
    public string SummaryText { get; init; }
}