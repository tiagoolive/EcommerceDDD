using ApplicationApp.Interfaces;
using Domain.Interfaces.InterfaceProduct;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationApp.OpenApp
{
    public class AppProduct : InterfaceProductApp
    {
        private readonly IProduct _iProduct;
        private readonly IServiceProduct _iServiceProduct;

        public AppProduct(IProduct IProduct, IServiceProduct IServiceProduct)
        {
            _iProduct = IProduct;
            _iServiceProduct = IServiceProduct;
        }

        public async Task<List<Produto>> ListarProdutosCarrinhoUsuario(string userId)
        {
            return await _iProduct.ListarProdutosCarrinhoUsuario(userId);
        }

        public async Task<Produto> ObterProdutoCarrinho(int idProdutoCarrinho)
        {
            return await _iProduct.ObterProdutoCarrinho(idProdutoCarrinho);
        }


        public async Task AddProduct(Produto produto)
        {
            await _iServiceProduct.AddProduct(produto);
        }
        public async Task UpdateProduct(Produto produto)
        {
            await _iServiceProduct.UpdateProduct(produto);
        }

        public async Task<List<Produto>> ListarProdutosUsuario(string userId)
        {
            return await _iProduct.ListarProdutosUsuario(userId);
        }

        public async Task Add(Produto Objeto)
        {
            await _iProduct.Add(Objeto);
        }

        public async Task Delete(Produto Objeto)
        {
            await _iProduct.Delete(Objeto);
        }

        public async Task<Produto> GetEntityById(int Id)
        {
            return await _iProduct.GetEntityById(Id);
        }

        public async Task<List<Produto>> List()
        {
            return await _iProduct.List();
        }

        public async Task Update(Produto Objeto)
        {
            await _iProduct.Update(Objeto);
        }

        public async Task<List<Produto>> ListarProdutosComEstoque()
        {
            return await _iServiceProduct.ListarProdutosComEstoque();
        }

    }
}
