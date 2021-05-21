using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationApp.Interfaces;
using Domain.Interfaces;
using Domain.Interfaces.InterfaceCompraUsuario;
using Entities.Entities;

namespace ApplicationApp.OpenApp
{
    public class AppCompraUsuario : InterfaceCompraUsuarioApp
    {
        private readonly ICompraUsuario _iCompraUsuario;

        public AppCompraUsuario(ICompraUsuario ICompraUsuario)
        {
            _iCompraUsuario = ICompraUsuario;
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
    }
}
