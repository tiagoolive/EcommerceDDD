using Domain.Interfaces.InterfaceProduct;
using Domain.Interfaces.InterfaceServices;
using Domain.Services;
using Entities.Entities;
using Infrastructure.Repository.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Internal;

namespace UnitTestEcommerceDDD
{
    [TestClass]
    public class UnitTestEcomerce
    {

        [TestMethod]
        public async Task AddProductComSucesso()
        {
            try
            {
                IProduct _IProduct = new RepositoryProduct();
                IServiceProduct _serviceProduct = new ServiceProduct(_IProduct);

                var produto = new Produto { 
                Descricao = string.Concat("Descrição Test TDD", DateTime.Now.ToString()),
                QtdEstoque = 10,
                Nome = string.Concat("Nome Test TDD", DateTime.Now.ToString()),
                Valor = 20,
                UserId = "83e61c23-2976-4c22-9355-d7732f26a53a"
                };

                await _serviceProduct.AddProduct(produto);

                Assert.IsFalse(produto.Notitycoes.Any());

            }
            catch (Exception)
            {

                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task AddProductComValidacaoCampoObrigatorio()
        {
            try
            {
                IProduct _IProduct = new RepositoryProduct();
                IServiceProduct _serviceProduct = new ServiceProduct(_IProduct);

                var produto = new Produto
                {
                    
                };

                await _serviceProduct.AddProduct(produto);

                Assert.IsTrue(produto.Notitycoes.Any());

            }
            catch (Exception)
            {

                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task ListarProdutosUsuario()
        {
            try
            {
            IProduct _IProduct = new RepositoryProduct();

            var listaProdutos = await _IProduct.ListarProdutosUsuario("83e61c23-2976-4c22-9355-d7732f26a53a");

            Assert.IsTrue(listaProdutos.Any());
            }
            catch (Exception)
            {

                Assert.Fail();
            }

        }
            

        [TestMethod]
        public async Task GetEntityById()
        {
            try
            {
                IProduct _IProduct = new RepositoryProduct();

                var listaProdutos = await _IProduct.ListarProdutosUsuario("83e61c23-2976-4c22-9355-d7732f26a53a");

                var produto = await _IProduct.GetEntityById(listaProdutos.LastOrDefault().Id);

                Assert.IsTrue(listaProdutos.Any());
            }
            catch (Exception)
            {

                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task Delete()
        {
            try
            {
                IProduct _IProduct = new RepositoryProduct();
                var listaProdutos = await _IProduct.ListarProdutosUsuario("83e61c23-2976-4c22-9355-d7732f26a53a");
                var ultimoProduto = listaProdutos.LastOrDefault();

                await _IProduct.Delete(ultimoProduto);

                Assert.IsTrue(true);
            }
            catch (Exception)
            {

                Assert.Fail();
            }
        }
    }
}
