using CarrinhoAlegre.Core.Models.Produtos;
using CarrinhoAlegre.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace CarrinhoAlegre.Infra.ProdutoServices
{
    public class ProdutoService : IProdutoService
    {
        private readonly AppDbContext _context;
        public ProdutoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Produto>> ObterProdutosAsync()
        {
            var produtos = await _context.Produtos.ToListAsync();
            return produtos;
        }
    }
}
