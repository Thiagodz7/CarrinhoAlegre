using CarrinhoAlegre.Core.Models.Produtos;
using CarrinhoAlegre.Infra.ProdutoServices;
using Microsoft.AspNetCore.Mvc;

namespace CarrinhoAlegre.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProdutos()
        {
            var produtos = await _produtoService.ObterProdutosAsync();

            if (produtos.Count() != 0) 
                return Ok(produtos.ToList());
            else
                return NotFound("Nenhum produto encontrado");
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduto([FromBody] Produto produto)
        {
            if (produto == null)
            {
                return BadRequest("Produto inválido.");
            }

            var novoProduto = await _produtoService.InserirProduto(produto);

            return CreatedAtAction(
                nameof(GetProdutoById), 
                new { id = novoProduto.Id }, 
                novoProduto                
            );
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProdutoById(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Id inválido.");
            }

            var produto = await _produtoService.ObterProdutoByIdAsync(id);

            if(produto == null)
            {
               return NotFound("Produto não encontrado.");
            }

            return Ok(produto);
        }
    }
}
