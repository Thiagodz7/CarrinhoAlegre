using CarrinhoAlegre.Core.Interfaces.Produtos;

namespace CarrinhoAlegre.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IProdutoRepository Produtos { get; }

        Task<int> CommitAsync();
    }
}
