﻿using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.InterfaceServicos
{
    public interface IBancoServico
    {
        Task AdicionarBanco(Banco banco);
        Task AtualizarBanco(Banco banco);
    }
}
