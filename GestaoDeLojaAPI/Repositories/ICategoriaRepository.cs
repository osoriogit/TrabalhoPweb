using GestaoDeLojaAPI.Entities;

namespace GestaoDeLojaAPI.Repositories
{
    public interface ICategoriaRepository
    {
        Task<List<Categoria>> GetCategorias();

    }
}
