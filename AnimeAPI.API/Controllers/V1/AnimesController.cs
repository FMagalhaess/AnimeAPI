using System.Net;
using AnimeAPI.Application.Animes.Commands.CreateAnime;
using AnimeAPI.Application.Animes.Queries.GetAllAnimes;
using AnimeAPI.Application.Animes.Queries.GetAnimeById;
using AnimeAPI.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AnimeAPI.API.Controllers.V1;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
public class AnimesController(IMediator mediator, ILogger<AnimesController> logger) : ControllerBase
{

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> CreateAnime([FromBody] CreateAnimeCommand command)
    {
        var animeId = await mediator.Send(command);
        logger.LogInformation("Anime created with ID: {AnimeId}", animeId);
        return CreatedAtAction(nameof(GetAnimeById), new { id = animeId }, null);
    }
    
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(Anime), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetAnimeById(Guid id)
    {
        var query = new GetAnimeByIdQuery { Id = id };
        var animeDto = await mediator.Send(query);

        if (animeDto == null)
        {
            logger.LogWarning("Anime com ID {AnimeId} não encontrado.", id);
            return NotFound();
        }

        return Ok(animeDto);
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Anime>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetAllAnimes(
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10
    )
    {
        var query = new GetAllAnimesQuery
        {
            PageNumber = pageNumber,
            PageSize = pageSize
        };

        var paginatedAnimes = await mediator.Send(query);
        
        if (paginatedAnimes == null || !paginatedAnimes.Any())
        {
            logger.LogInformation("Nenhum anime encontrado.");
            return Ok(new List<Anime>());
        }

        logger.LogInformation("Total de animes encontrados: {TotalCount}", paginatedAnimes.TotalCount);
        return Ok(paginatedAnimes);
    }
}