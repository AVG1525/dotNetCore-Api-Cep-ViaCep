﻿using AspCepAPI.Domain;
using AspCepAPI.Interfaces;
using AspCepAPI.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using System.Threading.Tasks;

namespace AspCepAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration["Sqlite:ConnectionString"];
            services.AddDbContext<CepDomain>(options =>
                options.UseSqlite(connection)
                );

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
                options.TokenValidationParameters = new TokenValidationParameters {
                    ValidateIssuer = true,
                    ValidateAudience =true,
                    ValidateLifetime =true,
                    ValidateIssuerSigningKey =true,
                    ValidIssuer ="teste",
                    ValidAudience ="teste",
                    IssuerSigningKey =new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(Configuration["SecurityKey"]))
                };

                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        Console.WriteLine("Token Inválido... " + context.Exception.Message);
                        return Task.CompletedTask;
                    },

                    OnTokenValidated = context =>
                    {
                        Console.WriteLine("Token Válido... " + context.SecurityToken);
                        return Task.CompletedTask;
                    }
                };
            });

            services.AddTransient<IService, Service>();
            services.AddTransient<ICepService, CepService>();
            services.AddTransient<IApiCepService, ApiCepService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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
                app.UseHsts();
            }

            //app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}