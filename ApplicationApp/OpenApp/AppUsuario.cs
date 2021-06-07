using ApplicationApp.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Domain.Interfaces.InterfaceUsuario;
using Entities.Entities;
using Entities.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationApp.OpenApp
{
    public class AppUsuario : InterfaceUsuarioApp
    {
        private readonly IUsuario _iUsuario;
        private readonly IServiceUsuario _iServiceUsuario;

        public AppUsuario(IUsuario IUsuario, IServiceUsuario IServiceUsuario)
        {
            _iUsuario = IUsuario;
            _iServiceUsuario = IServiceUsuario;
        }
        public async Task AtualizarTipoUsuario(string userID, TipoUsuario tipoUsuario)
        {
            await _iUsuario.AtualizarTipoUsuario(userID, tipoUsuario);
        }
        public async Task<ApplicationUser> ObterUsuarioPeloId(string userID)
        {
            return await _iUsuario.ObterUsuarioPeloId(userID);
        }

        public async Task<List<ApplicationUser>> ListarUsuariosSomenteParaAdministradores(string userID)
        {
            return await _iServiceUsuario.ListarUsuariosSomenteParaAdministradores(userID);
        }

        public async Task Add(ApplicationUser Objeto)
        {
            await _iUsuario.Add(Objeto);
        }

        public async Task Delete(ApplicationUser Objeto)
        {
            await _iUsuario.Delete(Objeto);
        }

        public async Task<ApplicationUser> GetEntityById(int Id)
        {
            return await _iUsuario.GetEntityById(Id);
        }

        public async Task<List<ApplicationUser>> List()
        {
            return await _iUsuario.List();
        }

        public async Task Update(ApplicationUser Objeto)
        {
            await _iUsuario.Update(Objeto);
        }
    }
}
