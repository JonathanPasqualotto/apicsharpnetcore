using Database.Configuracao;
using Database.Repositorio;
using Database.Repositorio.Generics;
using Dominio.Interfaces.Generics;
using Dominio.Interfaces.IBanco;
using Dominio.Interfaces.IBoleto;
using Dominio.Interfaces.InterfaceServicos;
using Dominio.Interfaces.IUsuarioBanco;
using Dominio.Servicos;
using Entidades.Entidades;
using Entities.Entidades;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Net;
using WebApi.Token;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ContextBase>(options =>
                options.UseNpgsql(
                    builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDefaultIdentity<ApplicationUsers>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ContextBase>();



//INTERFACE E REPOSITORIO
builder.Services.AddSingleton(typeof(InterfaceGeneric<>), typeof(RepositoryGgenerics<>));
builder.Services.AddSingleton< InterfaceBanco, RepositorioBanco>();
builder.Services.AddSingleton< InterfaceBoleto, RepositorioBoleto>();
builder.Services.AddSingleton<InterfaceUsuarioBanco, RepositorioUsuarioBanco>();



// SERVICOS DOMINIO
builder.Services.AddSingleton<IBancoServico, BancoServico>();
builder.Services.AddSingleton<IBoletoServico, BoletoServico>();
builder.Services.AddSingleton<IUsuarioBanco, UsuarioBancoServico>();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(option =>
    {
        option.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,

            ValidIssuer = "Teste.Securiry.Bearer",
            ValidAudience = "Teste.Securiry.Bearer",
            IssuerSigningKey = JwtSecurityKey.Create("Secrect_Key-12345678")
        };

        option.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = context =>
            {
                Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                return Task.CompletedTask;
            },
            OnTokenValidated = context =>
            {
                Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                return Task.CompletedTask;
            }

        };

    });



builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "API Banco", Version = "v1" });

    /*
     // FOI TENTANDOD IMPLEMENTAR O BOT�O DE AUTORIZA��O, MAS ESTAVA OCORRENDO ERRO QUE EU DESCONHE�O 
     c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                //Reference = new OpenApiReference
                //{
                //    Type = ReferenceType.SecurityScheme,
                //    Id = "Bearer"
                //}
            Name = "Bearer",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Reference = new OpenApiReference
            {
                Id = "Bearer",
                Type = ReferenceType.SecurityScheme
            }
            },
            new string[] {}
        }
    });*/
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var devClient = "http://localhost:4200";
app.UseCors(x =>
x.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader()
.WithOrigins(devClient));

app.UseHttpsRedirection();

// NEW
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
