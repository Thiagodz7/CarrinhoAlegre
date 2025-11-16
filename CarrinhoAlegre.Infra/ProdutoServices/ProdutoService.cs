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
        private readonly IUnitOfWork _uow;
        public ProdutoService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<IEnumerable<Produto>> ObterProdutosAsync()
        {
            var produtos = await _uow.Produtos.GetAllAsync();
            return produtos;
        }

        public async Task<Produto> InserirProduto(Produto request)
        {
            await _uow.Produtos.AddAsync(request);
            await _uow.CommitAsync();
            return request;
        }

        public async Task<Produto> ObterProdutoByIdAsync(Guid id)
        {
            var produto = await _uow.Produtos.GetByIdAsync(id);
            return produto;
        }
    }
}
