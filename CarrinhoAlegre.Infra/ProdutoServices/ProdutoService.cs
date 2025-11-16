using CarrinhoAlegre.Core.Models.Produtos;
using CarrinhoAlegre.Infra.Data;

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
            var produtos = _context.Produtos.AsEnumerable();

            return await Task.FromResult(produtos);
        }
    }
}
