using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RestApi.Domain.Services;
using RestApi.Domain.Interfaces;
using RestApi.Persistence.Memory;
using RestApi.Persistence.PostgreEF;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace RestApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddDbContext<UsuarioContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("postgresql")));
            services.AddScoped<IUsuarioRepository, UsuarioRepositoryEF>();

            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddDbContext<ProdutoContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("postgresql")));
            services.AddScoped<IProdutoRepository, ProdutoRepositoryEF>();

            services.AddScoped<ICarroService, CarroService>();
            services.AddDbContext<CarroContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("postgresql")));
            services.AddScoped<ICarroRepository, CarroRepositoryEF>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
