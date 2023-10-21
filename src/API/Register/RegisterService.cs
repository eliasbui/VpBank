using System.Reflection;
using Application.Service;
using Application.Service.IService;
using Common.Filter;
using Common.Mapping;
using Common.Settings;
using Infrastructure.Context;
using Infrastructure.Contract;
using Infrastructure.Repository;
using Infrastructure.Repository.IRepository;
using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace API.Register;

public static class RegisterService
{
    public static void RegisterServices(this IServiceCollection service)
    {
        service.Configure<DbSettings>(service.BuildServiceProvider().GetRequiredService<IConfiguration>()
            .GetSection("DbSettings"));
        service.AddScoped<DataContext>();
        service.AddScoped<IUnitOfWork, UnitOfWork>();
        service.AddScoped<IVpBankService, VpBankService>();
        service.AddScoped<IVpBankRepository, VpBankRepository>();
        service.AddApiVersioning(setup =>
        {
            setup.DefaultApiVersion = new ApiVersion(1, 0);
            setup.AssumeDefaultVersionWhenUnspecified = true;
            setup.ReportApiVersions = true;
            setup.ApiVersionReader = new UrlSegmentApiVersionReader();
            setup.ApiVersionReader = ApiVersionReader.Combine(
                new UrlSegmentApiVersionReader(),
                new HeaderApiVersionReader("api-version"),
                new QueryStringApiVersionReader("x-version"),
                new MediaTypeApiVersionReader("ver"));
        });
        service.AddVersionedApiExplorer(setup =>
        {
            setup.GroupNameFormat = "'v'VVV";
            setup.SubstituteApiVersionInUrl = true;
        });
        service.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("Bearer",
                new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT"
                });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                    },
                    new List<string>()
                }
            });
            options.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title = "VpBank Service Api version 1", Version = "v1", Description = "VpBank Service Api"
                });
            options.SwaggerDoc("v2",
                new OpenApiInfo
                {
                    Title = "VpBank Service Api version  2", Version = "v2",
                    Description = " VpBank Service Description"
                });
            options.OperationFilter<SwaggerParameterFilters>();
            options.DocumentFilter<SwaggerVersionMapping>();

            options.DocInclusionPredicate((version, desc) =>
            {
                if (!desc.TryGetMethodInfo(out var methodInfo))
                {
                    return false;
                }

                var versions = methodInfo.DeclaringType.GetCustomAttributes(true).OfType<ApiVersionAttribute>()
                    .SelectMany(attr => attr.Versions);
                var maps = methodInfo.GetCustomAttributes(true).OfType<MapToApiVersionAttribute>()
                    .SelectMany(attr => attr.Versions).ToArray();
                version = version.Replace("v", "");
                var any = false;
                foreach (var v in maps)
                {
                    if (v.ToString() == version)
                    {
                        any = true;
                        break;
                    }
                }

                return versions.Any(v => v.ToString() == version && any);
            });
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            options.IncludeXmlComments(xmlPath);
        });

        service.AddCors(setup =>
        {
            setup.AddDefaultPolicy(policy =>
            {
                policy.SetIsOriginAllowed(origin => true);
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
                policy.AllowCredentials();
            });
        });


        service.AddControllers();

        service.AddEndpointsApiExplorer();
    }
}