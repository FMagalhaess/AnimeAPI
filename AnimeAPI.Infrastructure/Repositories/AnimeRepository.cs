using AnimeAPI.Domain.Entities;
using AnimeAPI.Domain.Shared.Repositories;
using AnimeAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AnimeAPI.Infrastructure.Repositories;

public class AnimeRepository(ApplicationDbContext context) : IAnimeRepository
{
    public async Task<IEnumerable<Anime>> GetAllAsync()
    {
        return await context.Animes.ToListAsync();
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
    }

    public async Task UpdateAsync(Anime anime)
    {
        context.Animes.Update(anime);
    }

    public async Task DeleteAsync(Guid id)
    {
        var anime = await context.Animes.FindAsync(id);
        if (anime != null)
            context.Animes.Remove(anime);
    }

    public async Task<int> SaveChangesAsync()
    {
        return await context.SaveChangesAsync();
    }
}