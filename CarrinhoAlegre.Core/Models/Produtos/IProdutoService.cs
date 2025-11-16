using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrinhoAlegre.Core.Models.Produtos
{
    public interface IProdutoService
    {
       Task<IEnumerable<Produto>> ObterProdutosAsync();
    }
}
