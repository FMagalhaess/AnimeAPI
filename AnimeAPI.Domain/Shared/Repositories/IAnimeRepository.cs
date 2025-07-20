using AnimeAPI.Domain.Entities;

namespace AnimeAPI.Domain.Shared.Repositories;

public interface IAnimeRepository
{
    Task<PaginatedList<Anime>> GetAllAsync(int pageNumber, int pageSize);
    Task<Anime?> GetByIdAsync(Guid id);
    Task<IEnumerable<Anime>> GetByDirectorOrNameAsync(string? director, string? name);
    Task AddAsync(Anime anime);
    Task UpdateAsync(Anime anime);
    Task DeleteAsync(Guid id);
    Task<int> SaveChangesAsync();
}