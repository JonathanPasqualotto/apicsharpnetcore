using Database.Configuracao;
using Database.Repositorio.Generics;
using Dominio.Interfaces.IBoleto;
using Entidades.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repositorio
{
    public class RepositorioBoleto : RepositoryGgenerics<Boleto>, InterfaceBoleto
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositorioBoleto()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<List<Boleto>> ListarBoleto(int IdBoleto)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await
                    (from b in banco.Boleto
                     where b.Id.Equals(IdBoleto)
                     select b).AsNoTracking().ToListAsync();
            }
        }

        public async Task<List<Boleto>> ListarTodosBoletos()
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await
                    (from b in banco.Boleto
                     select b).AsNoTracking().ToListAsync();
            }
        }
    }
}
