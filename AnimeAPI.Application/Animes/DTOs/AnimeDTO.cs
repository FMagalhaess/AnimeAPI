using AnimeAPI.Domain.ValueObjects;

namespace AnimeAPI.Application.DTOs;

public class AnimeDto
{
    public Guid Id { get; set; }
    public string NameTittle { get; set; }
    public string DirectorName { get; set; }
    public string SummaryText { get; set; }
}