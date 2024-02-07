using Database.Configuracao;
using Database.Repositorio.Generics;
using Dominio.Interfaces.IBanco;
using Entidades.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repositorio
{
    public class RepositorioBanco : RepositoryGgenerics<Banco>, InterfaceBanco
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositorioBanco() 
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();   
        }
        public async Task<List<Banco>> ListarBanco(int IdBanco)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await
                    (from b in banco.Banco
                     where b.Id.Equals(IdBanco)
                     select b).AsNoTracking().ToListAsync();
            }
        }

        public async Task<List<Banco>> ListarTodosBancos()
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await
                    (from b in banco.Banco
                     select b).AsNoTracking().ToListAsync();
            }
        }
    }
}
