using GestaoDeLojaAPI.Entities;
using GestaoDeLojaAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace GestaoDeLojaAPI.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProdutoRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Produto> ObterDetalheProdutoAsync(int id)
        {
            var detalhe = _dbContext.Produtos
                .FirstOrDefaultAsync(p => p.Id == id);

            return await detalhe ?? throw new Exception("Produto não encontrado");   
        }
         
        public Task<IEnumerable<Produto>> ObterProdutosMaisVendidosAsync()
        {
            throw new NotImplementedException();
        }

        public async  Task<IEnumerable<Produto>> ObterProdutosPorCategoriaAsync(int categoriaId)
        {
            return await _dbContext.Produtos
                .Where(p => p.CategoriaId == categoriaId)
                .ToListAsync();
        }

        public Task<IEnumerable<Produto>> ObterProdutosPromocaoAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Produto>> ObterTodosProdutosAsync()
        {
            var produtos = await _dbContext.Produtos
                //.Where(x => x.Imagem.Length > 0)
                .OrderBy(p=>p.categoria.Ordem)
                .ThenBy(p => p.Nome)
                .ToListAsync();
            return produtos;

        }

        public async Task<Produto> AdicionarProdutoAsync(Produto produto)
        {
            await _dbContext.Produtos.AddAsync(produto);
            await _dbContext.SaveChangesAsync();
            return produto;
        }

        public async Task<bool> ApagarProdutoAsync(int id)
        {
            var produto = await _dbContext.Produtos.FindAsync(id);
            if (produto == null)
            {
                return false;
            }
            _dbContext.Produtos.Remove(produto);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Produto> AtualizarProdutoAsync(Produto produto)
        {
            _dbContext.Produtos.Update(produto);
            await _dbContext.SaveChangesAsync();
            return produto;
        }
    }
}
