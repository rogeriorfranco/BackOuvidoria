using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ouvidoria.Repository;
using System;

namespace BackOuvidoria
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
            services.AddDbContext<OuvidoriaDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<IClienteDal, ClienteDal>();
            services.AddTransient<IPontosContratoDal, PontosContratoDal>();
            services.AddTransient<IProdutoPontoDal, ProdutoPontoDal>();
            services.AddTransient<IOcorrenciaDal, OcorrenciaDal>();
            services.AddTransient<IResolucaoOcorrenciaDal, ResolucaoOcorrenciaDal>();
            services.AddTransient<IHistoricoAtendimentoDal, HistoricoAtendimentoDal>();
            services.AddTransient<IHistoricoDadosAberturaDal, HistoricoDadosAberturaDal>();
            services.AddTransient<IHistoricoDadosResolucaoDal, HistoricoDadosResolucaoDal>();
            services.AddTransient<IHistoricoContatoDal, HistoricoContatoDal>();
            services.AddTransient<IFaturaDal, FaturaDal>();
            services.AddTransient<IItemFaturaDal, ItemFaturaDal>();
            services.AddTransient<IStatusClienteDal, StatusClienteDal>();
            services.AddTransient<IGrupoEncerramentoCasoDal, GrupoEncerramentoCasoDal>();
            services.AddTransient<ICausaEncerramentoCasoDal, CausaEncerramentoCasoDal>();
            services.AddTransient<IQuandoUsarEncerramentoCasoDal, QuandoUsarEncerramentoCasoDal>();
            services.AddTransient<ITipoOfensorDal, TipoOfensorDal>();
            services.AddTransient<IResultadoContatoDal, ResultadoContatoDal>();
            services.AddTransient<ISolucaoEncerramentoCasoDal, SolucaoEncerramentoCasoDal>();
            services.AddTransient<IPendenteFilaEncaminhamentoDal, PendenteFilaEncaminhamentoDal>();
            services.AddTransient<IParametrosSistemaDal, ParametrosSistemaDal>();

            services.AddCors(options =>
              {
                  options.AddPolicy("AllowAnyOrigin",
                      builder => builder
                      .AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader());
              });


            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory("AllowAnyOrigin"));
            });

            services.AddMvc();
            //services.AddMvc().AddJsonOptions(options =>
            //{
            //    options.SerializerSettings.DateFormatString = "dd/MM/yyyy";
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
        }
    }
}
