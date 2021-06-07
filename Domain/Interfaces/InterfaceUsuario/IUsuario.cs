﻿using Domain.Interfaces.Generics;
using Entities.Entities;
using Entities.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceUsuario
{
    public interface IUsuario : IGeneric<ApplicationUser>
    {
        Task<ApplicationUser> ObterUsuarioPeloId(string userID);

        Task AtualizarTipoUsuario(string userID, TipoUsuario tipoUsuario);
    }
}
