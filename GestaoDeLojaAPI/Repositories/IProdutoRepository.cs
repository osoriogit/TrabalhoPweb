using GestaoDeLojaAPI.Entities;

namespace GestaoDeLojaAPI.Repositories
{
    public interface IProdutoRepository
    {
        Task <IEnumerable<Produto>> ObterProdutosPorCategoriaAsync ( int categoriaId);

        Task<IEnumerable<Produto>> ObterProdutosPromocaoAsync();

        Task<IEnumerable<Produto>> ObterProdutosMaisVendidosAsync();

        Task<Produto> ObterDetalheProdutoAsync(int id);

        Task<IEnumerable<Produto>> ObterTodosProdutosAsync();

        Task<Produto> AdicionarProdutoAsync(Produto produto);   

        Task<bool> ApagarProdutoAsync(int id);

        Task<Produto> AtualizarProdutoAsync(Produto produto);

    }
}
