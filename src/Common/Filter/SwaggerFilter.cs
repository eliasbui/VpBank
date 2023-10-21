﻿using Common.Config;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Common.Filter;

public class SwaggerParameterFilters : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        try
        {
            var maps = context.MethodInfo.GetCustomAttributes(true).OfType<MapToApiVersionAttribute>()
                .SelectMany(attr => attr.Versions).ToList();
            var version = maps[0].MajorVersion;
            if (context.ApiDescription.RelativePath != null &&
                SwaggerConfig.CurrentVersioningMethod == SwaggerConfig.VersioningType.CustomHeader &&
                !context.ApiDescription.RelativePath.Contains("{version}"))
            {
                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = SwaggerConfig.CustomHeaderParam,
                    In = ParameterLocation.Header,
                    Required = false,
                    Schema = new OpenApiSchema { Type = "String", Default = new OpenApiString(version.ToString()) }
                });
            }
            else if (context.ApiDescription.RelativePath != null &&
                     SwaggerConfig.CurrentVersioningMethod == SwaggerConfig.VersioningType.QueryString &&
                     !context.ApiDescription.RelativePath.Contains("{version}"))
            {
                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = SwaggerConfig.QueryStringParam,
                    In = ParameterLocation.Query,
                    Schema = new OpenApiSchema { Type = "String", Default = new OpenApiString(version.ToString()) }
                });
            }
            else if (context.ApiDescription.RelativePath != null &&
                     SwaggerConfig.CurrentVersioningMethod == SwaggerConfig.VersioningType.AcceptHeader &&
                     !context.ApiDescription.RelativePath.Contains("{version}"))
            {
                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = "Accept",
                    In = ParameterLocation.Header,
                    Required = false,
                    Schema = new OpenApiSchema
                    {
                        Type = "String",
                        Default = new OpenApiString($"application/json;{SwaggerConfig.AcceptHeaderParam}=" +
                                                    version)
                    }
                });
            }

            var versionParameter = operation.Parameters.Single(p => p.Name == "version");

            if (versionParameter != null)
            {
                operation.Parameters.Remove(versionParameter);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

