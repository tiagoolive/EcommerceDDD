using Domain.Interfaces.InterfaceServices;
using Domain.Interfaces.InterfaceUsuario;
using Entities.Entities;
using Entities.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceUsuario : IServiceUsuario
    {
        private readonly IUsuario _iUsuario;

        public ServiceUsuario(IUsuario IUsuario)
        {
            _iUsuario = IUsuario;
        }
        public async Task<List<ApplicationUser>> ListarUsuariosSomenteParaAdministradores(string userID)
        {
            var usuario = await _iUsuario.ObterUsuarioPeloId(userID);
            if(usuario != null && usuario.Tipo == TipoUsuario.Adminstrador)
            {
                return await _iUsuario.List();
            }
            return new List<ApplicationUser>();
        }
    }
}
