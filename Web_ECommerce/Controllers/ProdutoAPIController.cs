using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationApp.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Web_ECommerce.Controllers
{

    [Authorize]
    [LogActionFilter]
    public class ProdutoAPIController : BaseController
    {

        public readonly InterfaceProductApp _InterfaceProductApp;
        public readonly InterfaceCompraUsuarioApp _InterfaceCompraUsuarioApp;


        public ProdutoAPIController(InterfaceProductApp InterfaceProductApp, UserManager<ApplicationUser> userManager, InterfaceCompraUsuarioApp InterfaceCompraUsuarioApp, ILogger<ProdutoAPIController> logger, InterfaceLogSistemaApp InterfaceLogSistemaApp)
            : base(logger, userManager, InterfaceLogSistemaApp)
        {
            _InterfaceProductApp = InterfaceProductApp;
            _InterfaceCompraUsuarioApp = InterfaceCompraUsuarioApp;
        }


        [HttpGet("/api/ListaProdutos")]
        public async Task<JsonResult> ListaProdutos(string descricao)
        {
            return Json(await _InterfaceProductApp.ListarProdutosComEstoque(descricao));
        }

    }
}
