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
    }
}
