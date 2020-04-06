
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Acai.Api.Domain.Repositories;
using Acai.Api.Domain.Services;
using Acai.Api.Persistence.Contexts;
using Acai.Api.Persistence.Repositories;
using Acai.Api.Services;
using Acai.Api.Business.Interface;
using Acai.Api.Business;

namespace Acai.Api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<AppDbContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IPedidoService, PedidoService>();
            services.AddScoped<IPedidoBusiness, PedidoBusiness>();

            services.AddScoped<ISaborRepository, SaborRepository>();
            services.AddScoped<ISaborService, SaborService>();

            services.AddScoped<ITamanhoRepository, TamanhoRepository>();
            services.AddScoped<ITamanhoService, TamanhoService>();    

            services.AddScoped<IAdicionalRepository, AdicionalRepository>();
            services.AddScoped<IAdicionalService, AdicionalService>();   
            
            services.AddScoped<IPedidoAdicionalRepository, PedidoAdicionalRepository>();
            services.AddScoped<IPedidoAdicionalService, PedidoAdicionalService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(config => {
                config.AllowAnyHeader();
                config.AllowAnyMethod();
                config.AllowAnyOrigin();
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
