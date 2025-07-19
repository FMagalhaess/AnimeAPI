using AnimeAPI.Application.DTOs;
using MediatR;

namespace AnimeAPI.Application.Animes.Queries.GetAnimeById;

public record GetAnimeByIdQuery : IRequest<AnimeDto>
{
    public Guid Id { get; init; }
}