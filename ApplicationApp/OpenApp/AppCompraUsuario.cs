using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationApp.Interfaces;
using Domain.Interfaces;
using Domain.Interfaces.InterfaceCompraUsuario;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;

namespace ApplicationApp.OpenApp
{
    public class AppCompraUsuario : InterfaceCompraUsuarioApp
    {
        private readonly ICompraUsuario _iCompraUsuario;
        private readonly IServiceCompraUsuario _iServiceCompraUsuario;

        public AppCompraUsuario(ICompraUsuario ICompraUsuario, IServiceCompraUsuario iServiceCompraUsuario)
        {
            _iCompraUsuario = ICompraUsuario;
            _iServiceCompraUsuario = iServiceCompraUsuario;
        }

        public async Task<CompraUsuario> CarrinhoCompras(string userId)
        {
            return await _iServiceCompraUsuario.CarrinhoCompras(userId);
        }

        public async Task<CompraUsuario> ProdutosComprados(string userId, int? idCompra = null)
        {
            return await _iServiceCompraUsuario.ProdutosComprados(userId, idCompra);
        }

        public async Task<bool> ConfirmaCompraCarrinhoUsuario(string userId)
        {
            return await _iCompraUsuario.ConfirmaCompraCarrinhoUsuario(userId);
        }

        public async Task<int> QuantidadeProdutoCarrinhoUsuario(string userId)
        {
            return await _iCompraUsuario.QuantidadeProdutoCarrinhoUsuario(userId);
        }

        public async Task Add(CompraUsuario Objeto)
        {
            await _iCompraUsuario.Add(Objeto);
        }

        public async Task Delete(CompraUsuario Objeto)
        {
            await _iCompraUsuario.Delete(Objeto);
        }

        public async Task<CompraUsuario> GetEntityById(int Id)
        {
            return await _iCompraUsuario.GetEntityById(Id);
        }

        public async Task<List<CompraUsuario>> List()
        {
            return await _iCompraUsuario.List();
        }

        public async Task Update(CompraUsuario Objeto)
        {
            await _iCompraUsuario.Update(Objeto);
        }

        public async Task<List<CompraUsuario>> MinhasCompras(string userId)
        {
            return await _iServiceCompraUsuario.MinhasCompras(userId);
        }

        public async Task AdicionaProdutoCarrinho(string userId, CompraUsuario compraUsuario)
        {
            await _iServiceCompraUsuario.AdicionaProdutoCarrinho(userId, compraUsuario);
        }
    }
}
