using CarrinhoAlegre.Core.Interfaces;
using CarrinhoAlegre.Core.Interfaces.Produtos;
using CarrinhoAlegre.Core.Models.Produtos;
using CarrinhoAlegre.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarrinhoAlegre.Infra.Repository.Produtos
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(AppDbContext context) : base(context)
        {
        }

        public Task<IEnumerable<Produto>> ObterProdutosPrecificados(decimal valor)
        {
            throw new NotImplementedException();
        }
    }
}
