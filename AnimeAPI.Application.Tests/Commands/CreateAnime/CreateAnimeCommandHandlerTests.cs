using AnimeAPI.Application.Animes.Commands.CreateAnime;
using AnimeAPI.Domain.Entities;
using AnimeAPI.Domain.Shared.Repositories;
using AnimeAPI.Domain.ValueObjects.Exceptions.NameExceptions;
using Moq;

namespace AnimeAPI.Application.Tests.Commands.CreateAnime;

public class CreateAnimeCommandHandlerTests
{
    private readonly Mock<IAnimeRepository> _mockAnimeRepository;
    private readonly CreateAnimeCommandHandler _handler;

    public CreateAnimeCommandHandlerTests()
    {
        _mockAnimeRepository = new Mock<IAnimeRepository>();
        _handler = new CreateAnimeCommandHandler(_mockAnimeRepository.Object);
    }

    [Fact]
    public async Task Handle_GivenValidCommand_ShouldCreateAnimeAndReturnId()
    {
        var command = new CreateAnimeCommand
        {
            NameTittle = "Jujutsu Kaisen",
            DirectorName = "Shota Goshozono",
            SummaryText = "Um estudante do ensino médio se envolve no mundo dos espíritos amaldiçoados."
        };
        
        _mockAnimeRepository.Setup(r => r.AddAsync(It.IsAny<Anime>()))
                            .Returns(Task.CompletedTask);
        
        var resultId = await _handler.Handle(command, CancellationToken.None);
        
        Assert.NotEqual(Guid.Empty, resultId);
        
        _mockAnimeRepository.Verify(r => r.AddAsync(It.IsAny<Anime>()), Times.Once);
        
        _mockAnimeRepository.Verify(r => r.AddAsync(
            It.Is<Anime>(a => 
                a.Name.Tittle == command.NameTittle &&
                a.Director.DirectorName == command.DirectorName
            )
        ), Times.Once);
    }

    [Fact]
    public async Task Handle_GivenInvalidTitleInCommand_ShouldThrowArgumentException()
    {
        var command = new CreateAnimeCommand
        {
            NameTittle = "",
            DirectorName = "Valid Director",
            SummaryText = "Valid Summary"
        };
        
        await Assert.ThrowsAsync<NullNameException>(() => _handler.Handle(command, CancellationToken.None));
        
        _mockAnimeRepository.Verify(r => r.AddAsync(It.IsAny<Anime>()), Times.Never);
    }
}
