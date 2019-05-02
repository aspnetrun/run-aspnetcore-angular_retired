using System;
using System.Reflection;
using AspnetRunAngular.Core.Configuration;
using AspnetRunAngular.Infrastructure.Data;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AspnetRunAngular.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            AspnetRunSettings = configuration.Get<AspnetRunSettings>();
        }

        public IConfiguration Configuration { get; }
        public AspnetRunSettings AspnetRunSettings { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            return
            services
                .AddCustomMvc()
                .AddCustomDbContext(AspnetRunSettings)
                .AddCustomSwagger()
                .AddCustomConfiguration(Configuration)
                .AddCustomIntegrations();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("CorsPolicy");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            app.UseSwaggerUi3();

            app.UseMiddleware<LoggingMiddleware>();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
        }
    }

    static class CustomExtensionsMethods
    {
        public static IServiceCollection AddCustomMvc(this IServiceCollection services)
        {
            // Add framework services.
            services
                .AddMvc()
                .AddFluentValidation(fv =>
                {
                    fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                })
                .AddControllersAsServices();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                    .SetIsOriginAllowed((host) => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            return services;
        }

        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, AspnetRunSettings aspnetRunSettings)
        {
            // use in-memory database
            //services.AddDbContext<ExpertiseContext>(c => c.UseInMemoryDatabase("AspnetRun"));

            // Add Expertise DbContext
            services
                .AddEntityFrameworkSqlServer()
                .AddDbContext<AspnetRunContext>(options =>
                        options.UseSqlServer(aspnetRunSettings.ConnectionString,
                        sqlOptions =>
                        {
                            sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                        }
                    ),
                    ServiceLifetime.Scoped
                 );

            return services;
        }

        public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {
            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "AspnetRun HTTP API";
                    document.Info.Description = "The AspnetRun Service HTTP API";
                    document.Info.TermsOfService = "Terms Of Service";
                    document.Info.Contact = new NSwag.SwaggerContact
                    {
                        Name = "AspnetRun",
                        Email = string.Empty,
                        Url = string.Empty
                    };
                    document.Info.License = new NSwag.SwaggerLicense
                    {
                        Name = "Use under LICX",
                        Url = "https://example.com/license"
                    };
                };
            });

            return services;
        }

        public static IServiceCollection AddCustomConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();
            services.Configure<AspnetRunSettings>(configuration);

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Instance = context.HttpContext.Request.Path,
                        Status = StatusCodes.Status400BadRequest,
                        Detail = "Please refer to the errors property for additional details."
                    };

                    return new BadRequestObjectResult(problemDetails)
                    {
                        ContentTypes = { "application/problem+json", "application/problem+xml" }
                    };
                };
            });

            return services;
        }

        public static IServiceProvider AddCustomIntegrations(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();

            //configure autofac
            var container = new ContainerBuilder();
            container.Populate(services);

            //container.RegisterModule(new MediatorModule());
            //container.RegisterModule(new ApplicationModule());

            var scope = container.Build();

            return new AutofacServiceProvider(scope);
        }
    }


    //public class Startup
    //{
    //    public Startup(IConfiguration configuration)
    //    {
    //        Configuration = configuration;
    //    }

    //    public IConfiguration Configuration { get; }

    //    // This method gets called by the runtime. Use this method to add services to the container.
    //    public void ConfigureServices(IServiceCollection services)
    //    {
    //        services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
    //    }

    //    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    //    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    //    {
    //        if (env.IsDevelopment())
    //        {
    //            app.UseDeveloperExceptionPage();
    //        }
    //        else
    //        {
    //            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //            app.UseHsts();
    //        }

    //        app.UseHttpsRedirection();
    //        app.UseMvc();
    //    }
    //}
}
