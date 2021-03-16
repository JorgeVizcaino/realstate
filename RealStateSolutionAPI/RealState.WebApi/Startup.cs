using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using RealState.Application;
using RealState.Application.Common.Interfaces;
using RealState.Domain.Entities;
using RealState.Infrastructure;
using RealState.Infrastructure.AppSettings;
using RealState.WebApi.Common;
using RealState.WebApi.Services;

namespace RealState.WebApi
{
    public class Startup
    {
        private readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication();
            services.AddInfrastructure(Configuration, Environment);
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddAutoMapper(typeof(Startup));

            /*Load Configuration AppSettings*/
            var appSettingsSection = Configuration.GetSection("App");
            services.Configure<AppSettings>(appSettingsSection);
            var appSettings = appSettingsSection.Get<AppSettings>();
            /*Fin Load Configuration AppSettings*/

            //Configuration GZIP
            services.Configure<GzipCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Optimal;
            });
            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = false;
                options.Providers.Add<GzipCompressionProvider>();
            });
            //Fin Configuration GZIP


            //Validate Swagger
            var EnableSwagger = Convert.ToBoolean(Configuration["App:EnableSwagger"]);
            if (EnableSwagger)
                services.AddSwaggerDocument(o => o.Title = "Core API");

            //Add jwt token
            var secretString =
                appSettings.AppAuthenticationSettings
                    .SecretString; 
            var issuerTk =
                appSettings.AppAuthenticationSettings
                    .UrlGeneraToken; 
            var audienceTK =
                appSettings.AppAuthenticationSettings
                    .AudienceToken; 
            var key = Encoding.ASCII.GetBytes(secretString);
            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        LifetimeValidator = (before, expires, token, param) => { return expires > DateTime.UtcNow; },
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = true,
                        ValidIssuer = issuerTk,
                        ValidateAudience = true,
                        ValidAudience = audienceTK
                    };
                });
            //fin add jwt token

            var urlPermitted = Configuration.GetSection("App:UrlPermitted").Get<List<string>>();
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder.WithOrigins(urlPermitted.ToArray())
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });


            //Activate Authorization all api
            services.AddControllers(
                option =>
                {
                    var policy = new AuthorizationPolicyBuilder()
                        .RequireAuthenticatedUser()
                        .Build();
                    option.Filters.Add(new AuthorizeFilter(policy));
                }
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseCustomExceptionHandler();


            //Enable Gzip
            app.UseResponseCompression();
            //Fin Enable Gzip

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            //Enable Authentication JWT
            app.UseAuthentication();
            //Fin Enable Authentication JWT

            var enableSwagger = Convert.ToBoolean(Configuration["App:EnableSwagger"]);
            if (enableSwagger)
            {
                app.UseOpenApi();
                app.UseSwaggerUi3();

                app.UseSwaggerUi3(settings =>
                {
                    settings.Path = "/api";
                    settings.DocumentPath = "/api/specification.json";
                });
            }


            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}