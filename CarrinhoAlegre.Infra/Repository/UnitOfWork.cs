using CarrinhoAlegre.Core.Interfaces;
using CarrinhoAlegre.Core.Interfaces.Produtos;
using CarrinhoAlegre.Infra.Data;
using CarrinhoAlegre.Infra.Repository.Produtos;

namespace CarrinhoAlegre.Infra.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IProdutoRepository Produtos { get; private set; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;

            Produtos = new ProdutoRepository(_context);
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
