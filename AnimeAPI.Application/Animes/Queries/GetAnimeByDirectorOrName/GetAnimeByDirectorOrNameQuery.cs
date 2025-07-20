using AnimeAPI.Application.Animes.DTOs;
using MediatR;

namespace AnimeAPI.Application.Animes.Queries.GetAnimeByDirectorOrName;

public record GetAnimeByDirectorOrNameQuery(string? director, string? name) : IRequest<IEnumerable<AnimeDto>>;