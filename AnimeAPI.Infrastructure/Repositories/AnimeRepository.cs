using AnimeAPI.Domain.Entities;
using AnimeAPI.Domain.Shared;
using AnimeAPI.Domain.Shared.Repositories;
using AnimeAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AnimeAPI.Infrastructure.Repositories;

public class AnimeRepository(ApplicationDbContext context) : IAnimeRepository
{
    public async Task<PaginatedList<Anime>> GetAllAsync(int pageNumber, int pageSize)
    {
        var source = context.Animes.AsNoTracking();
        
        var count = await source.CountAsync();
        var items = await source
            .OrderBy(a => a.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return new PaginatedList<Anime>(items, pageNumber, pageSize, count);
    }

    public async Task<Anime?> GetByIdAsync(Guid id)
    {
        return await context.Animes.FindAsync(id);
    }

    public async Task<IEnumerable<Anime>> GetByDirectorOrNameAsync(string? director, string? name)
    {
        var query = context.Animes.AsQueryable();

        if (!string.IsNullOrWhiteSpace(director))
            query = query.Where(a => a.Director.DirectorName.Contains(director));
        if (!string.IsNullOrWhiteSpace(name))
            query = query.Where(a => a.Name.Tittle.Contains(name));
        return await query.ToListAsync();
    }

    public async Task AddAsync(Anime anime)
    {
        await context.Animes.AddAsync(anime);
        await SaveChangesAsync();
    }

    public async Task UpdateAsync(Anime anime)
    {
        context.Animes.Update(anime);
        await SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var anime = await context.Animes.FindAsync(id);
        if (anime != null)
            context.Animes.Remove(anime);
        await SaveChangesAsync();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await context.SaveChangesAsync();
    }
}