using Database.Configuracao;
using Database.Repositorio.Generics;
using Dominio.Interfaces.IUsuarioBanco;
using Entidades.Entidades;
using Entities.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repositorio
{
    public class RepositorioUsuarioBanco : RepositoryGgenerics<UsuarioBanco>, InterfaceUsuarioBanco
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositorioUsuarioBanco()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<List<UsuarioBanco>> ListarTodosUsuariosBanco()
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await
                    (from b in banco.UsuarioBanco
                     select b).AsNoTracking().ToListAsync();
            }
        }

        public async Task<List<UsuarioBanco>> ListarUsuarioBanco(int IdBanco)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await
                    (from b in banco.UsuarioBanco
                     where b.BancoId.Equals(IdBanco)
                     select b).AsNoTracking().ToListAsync();
            }
        }

        public async Task RemoveUsuarios(List<UsuarioBanco> usuarios)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                banco.UsuarioBanco
                .RemoveRange(usuarios);

                await banco.SaveChangesAsync();
            }
        }
    }
}
