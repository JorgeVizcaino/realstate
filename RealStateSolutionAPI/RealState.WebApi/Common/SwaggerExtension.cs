using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace RealState.WebApi.Common
{
    public static class SwaggerExtension
    {
        public static void AddSwagger(this IServiceCollection services)
        {               
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API Shell API",
                    Description = "Shell ASP.NET Core Web API",
                    TermsOfService = new System.Uri("https://www.Pevaar.com"),
                    Contact = new OpenApiContact() { Name = "Pevaar Softwre Factory", Email = "contact@pevaar.com" }
                });

                //c.SwaggerDoc("v2", new OpenApiInfo
                //{
                //    Version = "v2",
                //    Title = "New API V2",
                //    Description = "Sample Web API",
                //    TermsOfService = new System.Uri("https://www.talkingdotnet.com"),
                //    Contact = new OpenApiContact() { Name = "Talking Dotnet", Email = "contact@talkingdotnet.com" }
                //});

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                //Add Bearer
                var securitySchema = new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };

                c.AddSecurityDefinition("Bearer", securitySchema);

                var securityRequirement = new OpenApiSecurityRequirement();
                securityRequirement.Add(securitySchema, new[] { "Bearer" });
                c.AddSecurityRequirement(securityRequirement);
                //Fin Add Bearer

                //c.DescribeAllEnumsAsStrings();
                //c.DescribeStringEnumsInCamelCase();
            });
        }
        public static void UseCustomSwagger(this IApplicationBuilder app)
        {

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {                
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
                //c.SwaggerEndpoint("/swagger/v2/swagger.json", "My API V2");
                //c.Path = "/api";
                //c.DocumentPath = "/api/specification.json";
            });
        }

      
    }
}
