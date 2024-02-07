using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Entidades;
using Microsoft.EntityFrameworkCore;
using Entities.Entidades;

namespace Database.Configuracao
{
    public class ContextBase : IdentityDbContext<ApplicationUsers>
    {
        public ContextBase( DbContextOptions options) : base(options) 
        { 
        }

        public DbSet<Boleto> Boleto { get; set; }  
        public DbSet<Banco> Banco { get; set;}
        public DbSet<UsuarioBanco> UsuarioBanco { get; set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUsers>().ToTable("AspNetUsers").HasKey(t => t.Id);
            base.OnModelCreating(builder);
        }

        public string ObterStringConexao()
        {
            return "Server = localhost; Port = 5432; Database = conta; User Id = postgres; Password = masterkey"; // "Host={localhost};Username={postgres};Password={masterkey};Database={conta}";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(ObterStringConexao());
                base.OnConfiguring(optionsBuilder);
            }
        }
    }
}
