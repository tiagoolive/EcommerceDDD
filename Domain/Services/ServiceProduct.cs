using Domain.Interfaces.InterfaceProduct;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceProduct : IServiceProduct
    {
        private readonly IProduct _iproduct;

        public ServiceProduct(IProduct iproduct)
        {
            _iproduct = iproduct;
        }
        public async Task AddProduct(Produto produto)
        {
            var validaNome = produto.ValidaPropriedadeString(produto.Nome, "Nome");

            var validaValor = produto.ValidarPropriedadeDecimal(produto.Valor, "Valor");

            var validaQtdEstoque = produto.ValidarPropriedadeInt(produto.QtdEstoque, "QtdEstoque");

            if (validaNome && validaValor && validaQtdEstoque)
            {
                produto.DataCadastro = DateTime.Now;
                produto.DataAlteracao = DateTime.Now;
                produto.Estado = true;
                await _iproduct.Add(produto);
            }
        }

        public async Task<List<Produto>> ListarProdutosComEstoque()
        {
            return await _iproduct.ListarProdutos(p => p.QtdEstoque > 0);
        }

        public async Task UpdateProduct(Produto produto)
        {
            var validaNome = produto.ValidaPropriedadeString(produto.Nome, "Nome");

            var validaValor = produto.ValidarPropriedadeDecimal(produto.Valor, "Valor");

            var validaQtdEstoque = produto.ValidarPropriedadeInt(produto.QtdEstoque, "QtdEstoque");

            if (validaNome && validaValor && validaQtdEstoque)
            {
                produto.DataAlteracao = DateTime.Now;

                await _iproduct.Update(produto);
            }
        }
    }
}
