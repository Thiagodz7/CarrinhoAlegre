using CarrinhoAlegre.Core.Models.Produtos;

namespace CarrinhoAlegre.Core.Interfaces.Produtos
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> ObterProdutosPrecificados(decimal valor);
    }
}
