using Domain.Interfaces.InterfaceCompraUsuario;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using Entities.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceCompraUsuario : IServiceCompraUsuario
    {
        private readonly ICompraUsuario _iCompraUsuario;

        public ServiceCompraUsuario(ICompraUsuario ICompraUsuario)
        {
            _iCompraUsuario = ICompraUsuario;
        }
        public async Task<CompraUsuario> CarrinhoCompras(string userId)
        {
            return await _iCompraUsuario.ProdutosCompradosPorEstado(userId, EnumEstadoCompra.Produto_Carrinho);
        }

        public async Task<CompraUsuario> ProdutosComprados(string userId)
        {
            return await _iCompraUsuario.ProdutosCompradosPorEstado(userId, EnumEstadoCompra.Produto_Comprado);
        }
    }
}
