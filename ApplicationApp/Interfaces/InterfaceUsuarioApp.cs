using Entities.Entities;
using Entities.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationApp.Interfaces
{
    public interface InterfaceUsuarioApp : InterfaceGenericaApp<ApplicationUser>
    {
        Task<ApplicationUser> ObterUsuarioPeloId(string userID);
        Task AtualizarTipoUsuario(string userID, TipoUsuario tipoUsuario);
        Task<List<ApplicationUser>> ListarUsuariosSomenteParaAdministradores(string userID);
    }
}
