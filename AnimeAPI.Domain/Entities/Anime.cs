using AnimeAPI.Domain.Shared.Entities;

namespace AnimeAPI.Domain.Entities;

public sealed class Anime : Entity
{
    #region Constructors

    private Anime(
        string nome,
        string diretor,
        string resumo) : base(Guid.CreateVersion7())
    {
        Nome = nome;
        Diretor = diretor;
        Resumo = resumo;
    }

    #endregion

    #region Properties

    public string Nome { get; }
    public string Diretor { get; }
    public string Resumo { get; }

    #endregion

    #region Factories

    public static Anime Create(string nome, string diretor, string resumo)
    {
        return new Anime(nome, diretor, resumo);
    }

    #endregion
}