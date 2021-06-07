using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceServices
{
    public interface IServiceUsuario
    {
        Task<List<ApplicationUser>> ListarUsuariosSomenteParaAdministradores(string userID);
    }
}
