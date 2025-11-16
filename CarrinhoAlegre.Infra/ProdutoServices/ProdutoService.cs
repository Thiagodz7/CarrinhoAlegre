using CarrinhoAlegre.Core.Interfaces;
using CarrinhoAlegre.Core.Interfaces.Produtos;
using CarrinhoAlegre.Core.Models.Produtos;
using CarrinhoAlegre.Infra.Data;
using CarrinhoAlegre.Infra.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CarrinhoAlegre.Infra.ProdutoServices
{
    public class ProdutoService : IProdutoService
    {
        private readonly IRepository<Produto> _repository;
        private readonly IUnitOfWork _uow;
        public ProdutoService(IRepository<Produto> repository, IUnitOfWork uow)
        {
            _repository = repository;
            _uow = uow;
        }
        public async Task<IEnumerable<Produto>> ObterProdutosAsync()
        {
            var produtos = await _uow.Produtos.GetAllAsync();
            return produtos;
        }
    }
}
