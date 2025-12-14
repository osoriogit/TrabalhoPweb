using Microsoft.EntityFrameworkCore;

namespace GestaoDeLojaAPI.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly Data.ApplicationDbContext dbContext;
        public CategoriaRepository(Data.ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<Entities.Categoria>> GetCategorias()
        {
            return await dbContext.Categorias
                .Where(x => x.Imagem.Length > 0)
                .OrderBy(x => x.Ordem)
                .ThenBy(x => x.Nome)
                .ToListAsync();
        }

    }
}
