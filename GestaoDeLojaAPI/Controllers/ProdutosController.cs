using GestaoDeLojaAPI.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestaoDeLojaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly Repositories.IProdutoRepository _produtoRepository;

        public ProdutosController(Repositories.IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        //ObterProdutosPorCategoriaAsync
        [HttpGet("Categoria/{categoriaId}")]
        public async Task<IEnumerable<Produto>> ObterProdutosPorCategoriaAsync(int categoriaId)
        {
            return await _produtoRepository.ObterProdutosPorCategoriaAsync(categoriaId);
        }
        //ObterProdutosPromocaoAsync
        [HttpGet("Promocao")]
        public async Task<IEnumerable<Produto>> ObterProdutosPromocaoAsync()
        {
            return await _produtoRepository.ObterProdutosPromocaoAsync();
        }
        //ObterProdutosMaisVendidosAsync
        [HttpGet("MaisVendidos")]
        public async Task<IEnumerable<Produto>> ObterProdutosMaisVendidosAsync()
        {
            return await _produtoRepository.ObterProdutosMaisVendidosAsync();
        }
        //ObterDetalheProdutoAsync
        [HttpGet("{id}")]
        public async Task<Produto> ObterDetalheProdutoAsync(int id)
        {
            return await _produtoRepository.ObterDetalheProdutoAsync(id);
        }
        //ObterTodosProdutosAsync
        [HttpGet]
        public async Task<IEnumerable<Produto>> ObterTodosProdutosAsync()
        {
            return await _produtoRepository.ObterTodosProdutosAsync();
        }

        
        //// GET: api/<ProdutoController>
        //[HttpGet]
        //public async Task<IEnumerable<Produto>> ObterTodosProdutosAsync()
        //{
        //    return await _produtoRepository.ObterTodosProdutosAsync();
        //}

        //// GET api/<ProdutoController>/5
        //[HttpGet("{id}")]
        //public async Task<Produto> ObterDetalheProdutoAsync(int id)
        //{
        //    return await _produtoRepository.ObterDetalheProdutoAsync(id);
        //}

        //// POST api/<ProdutoController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<ProdutoController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ProdutoController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

        //Metodo para adicionar novo produto
        [HttpPost]
        public async Task<Produto> AdicionarProdutoAsync( Produto produto)
        {
            return await _produtoRepository.AdicionarProdutoAsync(produto);
        }
        //Metodo para apagar produto
        [HttpDelete("{id}")]
        public async Task<bool> ApagarProdutoAsync(int id)
        {
            return await _produtoRepository.ApagarProdutoAsync(id);
        }
        //Metodo para atualizar produto
        [HttpPut("{id}")]
        public async Task<Produto> AtualizarProdutoAsync(int id, [FromBody] Produto produto)
        {
            if (id != produto.Id)
            {
                throw new ArgumentException("ID do produto não corresponde ao ID fornecido na URL.");
            }
            return await _produtoRepository.AtualizarProdutoAsync(produto);
        }
    }
}
