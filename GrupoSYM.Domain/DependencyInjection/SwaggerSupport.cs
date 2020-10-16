using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrupoSYM.Domain.DependencyInjection
{
    public static class SwaggerSupport
    {
        public static void AddSwaggerSupport(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Grupo SYM",
                        Version = "1.0.0",
                        Description = "API de teste Grupo SYM",
                    });
            });
        }

        public static void UseSwaggerSupport(this IApplicationBuilder app)
        {
            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });
            app.UseSwaggerUI(options => options
               .SwaggerEndpoint("/swagger/v1/swagger.json", "Grupo SYM API v1"));
        }
    }
}
