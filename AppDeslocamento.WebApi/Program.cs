using AppDeslocamento.Data.Context;
using AppDeslocamento.Data.Repository;
using AppDeslocamento.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AppDeslocamento.WebApi
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //adiciona o contexto para gerar migration
            builder.Services.AddDbContext<ApplicationDbContext>(opt =>
            {

                opt.UseSqlServer(
                                builder.Configuration.GetConnectionString("ApplicationDbContext"),
                                b => b.MigrationsAssembly("AppDeslocamento.Data"));
            });

            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

            var appAssemblie = typeof(
                AppDeslocamento.Application.Clientes.Commands.AdicionarCliente.AdicionarClienteCommand).Assembly;

            builder.Services.AddMediatR(appAssemblie);

            builder.Services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}