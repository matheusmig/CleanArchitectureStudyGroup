using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApi.Modules;
using WebApi.Modules.Common;
using WebApi.Modules.Common.Swagger;

namespace CleanArch
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services                    
                   //.AddFeatureFlags(this.Configuration) // should be the first one.
                   //.AddInvalidRequestLogging()
                   //.AddCurrencyExchange(this.Configuration)
                   .AddMySql(Configuration)
                   //.AddHealthChecks(this.Configuration)
                   //.AddAuthentication(Configuration)
                   .AddVersioning()
                   .AddSwagger()
                   .AddUseCases();
                    //.AddCustomControllers()
                    //.AddCustomCors()
                    //.AddProxy()
                    //.AddCustomDataProtection();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting()
               .UseVersionedSwagger(provider, Configuration, env)
               .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
        }
    }
}
