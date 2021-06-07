using Domain.Interfaces.InterfaceUsuario;
using Entities.Entities;
using Entities.Entities.Enums;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryUsuario : RepositoryGenerics<ApplicationUser>, IUsuario
    {

        private readonly DbContextOptions<ContextBase> _optionsBuilder;
        public RepositoryUsuario()
        {
            _optionsBuilder = new DbContextOptions<ContextBase>();
        }
        public async Task AtualizarTipoUsuario(string userID, TipoUsuario tipoUsuario)
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                var usuario = await banco.ApplicationUser.FirstOrDefaultAsync(u => u.Id.Equals(userID));
                if(usuario != null)
                {
                    usuario.Tipo = tipoUsuario;
                    banco.ApplicationUser.Update(usuario);
                    await banco.SaveChangesAsync();
                }
            }
        }

        public async Task<ApplicationUser> ObterUsuarioPeloId(string userID)
        {
            using(var banco = new ContextBase(_optionsBuilder))
            {
                return await banco.ApplicationUser.FirstOrDefaultAsync(u => u.Id.Equals(userID));
            }
        }
    }
}
